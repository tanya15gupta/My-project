using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
	TextMeshProUGUI scoreText;

	private int setScore = 0;
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

	public void SetScoreIncrease(int _score)
	{
		setScore = _score;
	}

	public void IncreaseScore(int _increase)
	{
		score = score + _increase + setScore;
	}

	public void DecreaseScore()
	{
		if (score > 0)
			score --;
		else
			score = 0;
	}
}
