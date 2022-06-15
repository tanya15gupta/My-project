using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject playerWonUI;
    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void SetPanelActive()
	{
        gameOverPanel.SetActive(true);
        playerWonUI.SetActive(true);
    }

    public void SetPlayerWonUI(GameObject _playerWonUI)
	{
        playerWonUI = _playerWonUI;
        playerWonUI.SetActive(false);
	}

    public GameObject GetPlayerWonUI()
	{
        return playerWonUI;
	}
}
