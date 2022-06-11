using UnityEngine;
public class Boundaries : MonoBehaviour
{
	[SerializeField]
	GameObject snake;
	float xPositionWarp;
	float yPositionWarp;
	Transform snakePosition;
	float addValue = 1f;
	private void Start()
	{
		xPositionWarp = 21f;
		yPositionWarp = 10f;
	}

	private void Update()
	{
		SnakeWarping();
	}

	private void SnakeWarping()
	{
		snakePosition = snake.transform;
		if (snakePosition.transform.position.x > xPositionWarp)
		{
			snakePosition.transform.position = new Vector3(-snakePosition.transform.position.x + addValue, snakePosition.transform.position.y, 0.0f);
		}

		if (snakePosition.transform.position.x < -xPositionWarp)
		{
			snakePosition.transform.position = new Vector3(-snakePosition.transform.position.x - addValue, snakePosition.transform.position.y, 0.0f);
		}

		if (snakePosition.transform.position.y > yPositionWarp)
		{
			snakePosition.transform.position = new Vector3(snakePosition.transform.position.x, -snakePosition.transform.position.y + addValue, 0.0f);
		}

		if (snakePosition.transform.position.y < -yPositionWarp)
		{
			snakePosition.transform.position = new Vector3(snakePosition.transform.position.x, -snakePosition.transform.position.y - addValue, 0.0f);
		}
	}
}