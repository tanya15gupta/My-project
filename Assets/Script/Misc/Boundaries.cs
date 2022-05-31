using UnityEngine;
using Player.Movement;
public class Boundaries : MonoBehaviour
{
	BoxCollider2D boundaryCollider;

	private void Start()
	{
		boundaryCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<SnakeController>())
		{
			if (collision.transform.position.x > 21.5)
			{
				collision.transform.position = new Vector3(-boundaryCollider.size.x / 2, collision.transform.position.y, 0);
			}
			if (collision.transform.position.x < -21.5)
			{
				collision.transform.position = new Vector3(boundaryCollider.size.x / 2, collision.transform.position.y, 0);
			}
			if (collision.transform.position.y > 10.5)
			{
				collision.transform.position = new Vector3(collision.transform.position.x, -boundaryCollider.size.y / 2, 0);
			}
			if (collision.transform.position.y < -10.5)
			{
				collision.transform.position = new Vector3(collision.transform.position.x, boundaryCollider.size.y / 2, 0);
			}
		}
	}
}
