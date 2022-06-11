using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuUI : MonoBehaviour
{
	public void SoloGameSelected()
	{
		SceneManager.LoadScene(1);
	}

	public void CoOpGameSelected()
	{
		SceneManager.LoadScene(2);
	}

	public void QuitApplication()
	{
		Application.Quit();
	}
}
