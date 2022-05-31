using UnityEngine;
using System.Collections.Generic;
namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class SnakeController : MonoBehaviour
    {
        [Range(0, 1)]
        public float speed;
        private float time;
        private Vector2 playerDirection = Vector2.up;

        private List<Transform> snakeBody; //_segments
        [SerializeField]
        private Transform snakeBodyPrefab; //segmentPrefab
        [SerializeField]
        private GameObject food;
        [SerializeField]
        private GameObject poison;
        private Transform snakeTailPosition;

		private void Start()
		{
            snakeBody = new List<Transform>();
            snakeBody.Add(this.transform);
            for(int i = 0; i < 4; i++)
			{
                SnakeGrow();
			}
        }
		private void Update()
        {
            Timer();
            SnakeBodyFollowing();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == food)
                SnakeGrow();

            if (collision.gameObject == poison)
                SnakeShrink();
        }

        public void SnakeGrow()
        {
            snakeTailPosition = Instantiate(this.snakeBodyPrefab);
            snakeTailPosition.position = snakeBody[snakeBody.Count - 1].position;
            snakeBody.Add(snakeTailPosition);
        }

		public void SnakeShrink()
		{
			snakeBody.RemoveAt(snakeBody.Count - 1);
			//Destroy(this.snakeBodyPrefab);
		}

		public void SnakeBodyFollowing()
		{
            for(int i = snakeBody.Count - 1; i > 0; i--)
			{
                snakeBody[i].position = snakeBody[i - 1].position;
			}
		}

        void Timer()
		{
            time += Time.deltaTime;
            PlayerDirection();
            if (time > speed)
			{
				transform.position = new Vector3(
				Mathf.Round(transform.position.x) + playerDirection.x,
				Mathf.Round(transform.position.y) + playerDirection.y,
				0.0f);
                time = 0;
			}
        }

		void PlayerDirection()
		{
            if (Input.GetKey(KeyCode.D))
            {
                playerDirection = Vector2.right;
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerDirection = Vector2.left;
            }

            if (Input.GetKey(KeyCode.W))
            {
                playerDirection = Vector2.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                playerDirection = Vector2.down;
            }
        }
    }
}

