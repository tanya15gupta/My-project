using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	TextMeshProUGUI scoreText;

	private int score;
	
	private void Awake()
	{
		scoreText = gameObject.GetComponent<TextMeshProUGUI>();
	}

	private void Start()
	{
		RefreshUI();
	}

	public void RefreshUI()
	{
		scoreText.text = "Score: " + score;
	}

	public void IncreaseScore()
	{
		score++;
	}

	public void DecreaseScore()
	{
		if (score > 0)
			score--;
		else
			score = 0;
	}
}
