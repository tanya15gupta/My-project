using System.Collections;
using UnityEngine;
public class Spawner : MonoBehaviour
{
	[SerializeField]
	BoxCollider2D spawnBound;
	[SerializeField]
	GameObject[] consumables;
	private void Start()
	{
		SetBoard();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Food")
			Reposition(consumables[0]);

		if (collision.gameObject.tag == "Poison")
			Reposition(consumables[1]);

		if(collision.gameObject.tag == "SpeedBoost")
			PowerUpsSpawn(2);

		if(collision.gameObject.tag == "ScoreBoost")
			PowerUpsSpawn(3);
			
		if (collision.gameObject.tag == "Shield")
			PowerUpsSpawn(4);

		if (collision.gameObject.tag == "SnakeBody")
			StopAllCoroutines();
	}

	void SetBoard()
	{
		Reposition(consumables[0]);
		Reposition(consumables[1]);
		StartCoroutine(RandomizeFoodAfter());
		for(int i = 2; i <=4; i++)
		{
			consumables[i].gameObject.SetActive(false);
			StartCoroutine(ActivatePowerUp(i));
		}
	}

	private Vector3 RandomSpawn()
	{
		Bounds spawnArea = spawnBound.bounds;
		float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
		float y = Random.Range(spawnArea.min.y, spawnArea.max.y);
		return new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
	}

	public void Reposition(GameObject _gameObject)
	{
		_gameObject.transform.position = RandomSpawn();
	}

	IEnumerator RandomizeFoodAfter()
	{
		yield return new WaitForSeconds(4.0f);
		Reposition(consumables[0]);
		Reposition(consumables[1]);
		StartCoroutine(RandomizeFoodAfter());
	}

	void PowerUpsSpawn(int _arrayIndex)
	{
		Reposition(consumables[_arrayIndex]);
		consumables[_arrayIndex].SetActive(false);
		StartCoroutine(ActivatePowerUp(_arrayIndex));
	}


	IEnumerator ActivatePowerUp(int _elementNum)
	{
		float randTime = Random.Range(5, 20);
		yield return new WaitForSeconds(randTime);
		consumables[_elementNum].gameObject.SetActive(true);
	}
}
