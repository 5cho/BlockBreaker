using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWonUI : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    private void Start()
    {
        BBGameManager.Instance.OnGameWon += BBGameManager_OnGameWon;

        restartGameButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

        Hide();
    }

    private void BBGameManager_OnGameWon(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
