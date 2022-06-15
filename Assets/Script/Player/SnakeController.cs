using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class SnakeController : MonoBehaviour
    {

        //player movement
        [Range(0, 1)]
        public float speed;
        private float time;
        private Vector2 playerDirection;
        public Vector2 playerNextDirection = Vector2.left;

        //player score
        [SerializeField]
        ScoreUI scoreUpdate;

        //Power-ups
        public float speedBoost;
        bool isShieldActive = false;
        public bool isSpeedBoostActive = false;
        public bool isScoreBoostActive = false;

        //show power-ups when activated
        public GameObject shield;
        public GameObject scoreBoost;
        public GameObject speedBooster;

        //Controls
        [SerializeField]
        private KeyCode right, left, up, down;

        //snake length manipulation and body follow
        private List<Transform> snakeBody = new List<Transform>(); 
        [SerializeField]
        private Transform snakeBodyPrefab;
        private int initialSize = 3;
        private Transform snakeTailPosition;

        //spawning consumables
        [SerializeField]
        Spawner consumablesSpawn;

        //activating game over screen
        [SerializeField]
        GameOver gameOver;

        public GameObject playerWonUI;

		private void Start()
		{
            SnakeReset();
        }
		private void Update()
        {
            SnakeMovement();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Food")
			{
                SnakeGrow();
                scoreUpdate.IncreaseScore(1);
			}

            if (collision.gameObject.tag == "Poison")
			{
                scoreUpdate.DecreaseScore();
                SnakeShrink();
            }
            
            if (collision.gameObject.tag == "SnakeBody" && !isShieldActive)
			{
                gameOver.SetPanelActive();
                StopAllCoroutines();
            }
                
            if (collision.gameObject.tag == "SpeedBoost")
			{
                SpeedUp();
            }

            if (collision.gameObject.tag == "ScoreBoost")
			{
                ScoreBoost();
            }

            if(collision.gameObject.tag == "Shield")
			{
                Shield();
			}
             
            scoreUpdate.RefreshUI();
        }

        public void SnakeGrow()
        {
            snakeTailPosition = Instantiate(this.snakeBodyPrefab);
            snakeTailPosition.position = snakeBody[snakeBody.Count - 1].position;
            snakeBody.Add(snakeTailPosition);
        }

        public void SnakeShrink()
        {
            if (snakeBody.Count > 3)
			{
                Destroy(snakeBody[snakeBody.Count - 1].gameObject);
                snakeBody.RemoveAt(snakeBody.Count - 1);
            }
		}

        private void SnakeReset()
		{
            gameOver.SetPlayerWonUI(playerWonUI);
            shield.SetActive(false);
            speedBooster.SetActive(false);
            scoreBoost.SetActive(false);
            for (int i = 1; i < snakeBody.Count; i++)
			{
                Destroy(snakeBody[i].gameObject);
			}

            snakeBody.Clear();
            snakeBody.Add(this.transform);
			for (int i = 0; i < initialSize; i++)
			{
                SnakeGrow();
            }

            consumablesSpawn.Reposition(this.gameObject);
		}

        public void SnakeBodyFollowing()
		{
            for(int i = snakeBody.Count - 1; i > 0; i--)
			{
                snakeBody[i].position = snakeBody[i - 1].position;
			}
		}

        void SnakeMovement()
        {
            time += Time.deltaTime;
            PlayerDirectionInput();
            
            if (time > speed)
            {
                playerDirection = playerNextDirection;
                SnakeBodyFollowing();
                transform.position = new Vector3(Mathf.Round(transform.position.x) + playerDirection.x, Mathf.Round(transform.position.y) + playerDirection.y, 0.0f);
                time = 0;
            }
        }

		void PlayerDirectionInput()
		{
			if (Input.GetKey(right) && playerDirection != Vector2.left)
			{
				playerNextDirection = Vector2.right;
			}

			if (Input.GetKey(left) && playerDirection != Vector2.right)
			{
				playerNextDirection = Vector2.left;
			}

			if (Input.GetKey(up) && playerDirection != Vector2.down)
			{
				playerNextDirection = Vector2.up;
			}

			if (Input.GetKey(down) && playerDirection != Vector2.up)
			{
				playerNextDirection = Vector2.down;
			}
        }

        //Power-Ups
        public void SpeedUp()
		{
            speedBooster.SetActive(true);
            isSpeedBoostActive = true;
            speed -= speedBoost;
            StartCoroutine(CoolDownTime());
		}

        public void ScoreBoost()
		{
            scoreBoost.SetActive(true);
            isScoreBoostActive = true;
            scoreUpdate.SetScoreIncrease(4);
            StartCoroutine(CoolDownTime());
		}

        public void Shield()
		{
            shield.SetActive(true);
            isShieldActive = true;
            StartCoroutine(CoolDownTime());
		}

        private IEnumerator CoolDownTime()
		{
            float randomTime = Random.Range(3, 6);
            yield return new WaitForSeconds(randomTime);

            if (isSpeedBoostActive)
			{
                speedBooster.SetActive(false);
                speed += speedBoost;
                isSpeedBoostActive = false;
            }
                
            if (isScoreBoostActive)
			{
                scoreBoost.SetActive(false);
                scoreUpdate.SetScoreIncrease(0);
                isScoreBoostActive = false;
            }

            if (isShieldActive)
			{
                shield.SetActive(false);
                isShieldActive = false;
			}
        }
    }
}

