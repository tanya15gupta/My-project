using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
	public void SoloGameSelected()
	{
		SceneManager.LoadScene(1);
	}

	public void CoOpGameSelected()
	{
		SceneManager.LoadScene(2);
	}

	public void Restart()
	{
		SceneManager.LoadScene(2);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

}
