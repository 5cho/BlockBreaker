using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    private void Start()
    {
        BBGameManager.Instance.OnGameLost += BBGameManager_OnGameLost;

        restartGameButton.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });

        Hide();
    }

    private void BBGameManager_OnGameLost(object sender, System.EventArgs e)
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
