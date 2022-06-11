using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void SetPanelActive()
	{
        gameOverPanel.SetActive(true);
    }

}
