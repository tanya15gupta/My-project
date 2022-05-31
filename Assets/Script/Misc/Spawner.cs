using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	BoxCollider2D spawnBound;
	[SerializeField]
	GameObject food, antiFood;
	[SerializeField]
	ScoreUI scoreUpdate;
	
	private void Start()
	{
		Reposition(food);
		Reposition(antiFood);
		StartCoroutine(RandomizeFoodAfter());
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Food")
		{
			Reposition(food);
			scoreUpdate.IncreaseScore();
		}
		if (collision.gameObject.tag == "Poison")
		{
			Reposition(antiFood);
			scoreUpdate.DecreaseScore();
		}
		scoreUpdate.RefreshUI();
	}

	private Vector3 RandomSpawn()
	{
		Bounds spawnArea = spawnBound.bounds;
		float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
		float y = Random.Range(spawnArea.min.y, spawnArea.max.y);
		return new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
	}
	
	private void Reposition(GameObject _gameObject)
	{
		_gameObject.transform.position = RandomSpawn();
	}

	IEnumerator RandomizeFoodAfter()
	{
		yield return new WaitForSeconds(4.0f);
		Reposition(food);
		Reposition(antiFood);
		StartCoroutine(RandomizeFoodAfter());
	}
}
