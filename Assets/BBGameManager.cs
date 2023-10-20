using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BBGameManager : MonoBehaviour
{
    public static BBGameManager Instance { get; private set; }

    public event EventHandler OnGameWon;
    public event EventHandler OnGameLost;


    [SerializeField] private Transform level;
    [SerializeField] private Transform ballPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform powerupPlus1Prefab;
    [SerializeField] private int numberOfPowerups;


    private List<Block> listOfBlocks = new List<Block>();
    private List<Ball> listOfBalls = new List<Ball>();
    private List<Ball> listOfBallsOnPlayer = new List<Ball>();

    private void Awake()
    {
        Instance = this;
        
    }
    private void Start()
    {
        Vector3 ballSpawnOffset = new Vector3(0f,0.5f,0f);
        Transform spawnedBallTransform = Instantiate(ballPrefab, player.position + ballSpawnOffset, Quaternion.identity, player);
        Ball spawnedBall = spawnedBallTransform.GetComponent<Ball>();
        listOfBalls.Add(spawnedBall);
        listOfBallsOnPlayer.Add(spawnedBall);
        spawnedBall.SetFollowPlayer();
        
        foreach (Transform child in level)
        {
            Block block = child.gameObject.GetComponent<Block>();
            listOfBlocks.Add(block);
        }

        SetPowerups();
    }
    private void Update()
    {
        if(listOfBlocks.Count == 0)
        {
            OnGameWon?.Invoke(this, EventArgs.Empty);
        }
        if(listOfBalls.Count == 0)
        {
            OnGameLost?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Ball ball in listOfBallsOnPlayer)
            {
                ball.SetUnFollowPlayer();
            }
            listOfBallsOnPlayer.Clear();
        }
    }
    public void DestroyBlock(Block blockToRemove)
    {
        listOfBlocks.Remove(blockToRemove);
    }
    public void DestroyBall(Ball ballToRemove)
    {
        listOfBalls.Remove(ballToRemove);
    }
    public void SpawnNewBall()
    {
        Vector3 spawnOffset = new Vector3(0f, 1f, 0f);
        Transform spawnedBallTransform = Instantiate(ballPrefab, listOfBalls[0].transform.position + spawnOffset, Quaternion.identity);
        Ball spawnedBall = spawnedBallTransform.GetComponent<Ball>();
        listOfBalls.Add(spawnedBall);
        spawnedBall.SpawnBallAddForce();
    }
    private void SetPowerups()
    {
        for(int i = 0; i < numberOfPowerups; i++)
        {
            Block block = listOfBlocks[UnityEngine.Random.Range(0, listOfBlocks.Count)];
            block.SetBlockToSpawnPowerup(powerupPlus1Prefab);
        }
    }
    public float GetPlayerXPosition() 
    {
        return player.position.x;
    }
}
