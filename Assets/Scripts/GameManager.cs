using UnityEngine;
using UnityEngine.SceneManagement;


namespace Tools
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private Ball _ballPrefab;
		[SerializeField]
		private Platfrom _platform;
		private bool _gameIsStarted;
		[SerializeField]
		private BricksManager _bricksManager;
		[SerializeField]
		private GameObject _gameOverScreen;
		private Ball _ball;

		public static float BallSpeed = 250f;
		public static float PlatformSpeed = 10f;


		private void Start()
		{
			CreateBall();
			_gameIsStarted = false;
			_bricksManager.gameObject.SetActive(true);
			_bricksManager.CreateBricks();
			_platform.SetThePlatformSpeed(PlatformSpeed);
		}


		private void OnEnable()
		{
			Ball.OnBallDeath += ShowGameOverScreen;
			Brick.OnBrickDestroy += OnBrickDestroy;
		}


		private void OnDisable()
		{
			Ball.OnBallDeath -= ShowGameOverScreen;
			Brick.OnBrickDestroy -= OnBrickDestroy;
		}


		private void Update()
		{
			if (!_gameIsStarted)
			{
				HoldBallOnPlatform();
			}
			if (Input.GetKeyDown(KeyCode.Space) & !_gameIsStarted)
			{
				StartGame();
			}
		}


		private void OnBrickDestroy()
		{
			if (_bricksManager.CountRemainingBricks() == 0)
			{
				_bricksManager.CreateBricks();
			}
		}


		private void HoldBallOnPlatform()
		{
			_ball.transform.position = new Vector3(_platform.transform.position.x, _platform.transform.position.y + 0.35f, _platform.transform.position.z);
		}


		private void StartGame()
		{
			_gameIsStarted = true;
			_ball.SetTheBallSpeed(BallSpeed);
			_ball.PushTheBall();
		}


		private void ShowGameOverScreen()
		{
			_gameOverScreen.SetActive(true);
		}


		public void Restart()
		{
			_bricksManager.DestroyAllBricks();
			_bricksManager.CreateBricks();
			CreateBall();
			_gameIsStarted = false;
		}


		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}


		private void CreateBall()
		{
			_ball = Instantiate(_ballPrefab, _platform.transform.position, Quaternion.identity);
		}
	}
}
