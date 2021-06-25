using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Tools
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private Ball _ballPrefab;
		[SerializeField]
		private Platform _platform;
		[SerializeField]
		private BricksManager _bricksManager;
		[SerializeField]
		private UIManager _uiManager;
		[SerializeField]
		private GameObject _gameOverScreen;
		[SerializeField]
		private GameParameters _gameParameters;
		private Ball _ball;
		private bool _gameIsStarted;
		private float _ballSpeed = 250f;
		private float _platformSpeed;
		private float _sessionTimeState = 1;
		private int _brickScoreCost = 100;
		private int _bonusScoreValue;
		private int _timeToBricksMoveInSeconds;


		private void Awake()
		{
			_bonusScoreValue = _gameParameters.BonusScorePointsValue;
			_platformSpeed = _gameParameters.PlayerMovementSpeed;
			_timeToBricksMoveInSeconds = _gameParameters.BrickStackMovementSpeed;
		}


		private void Start()
		{
			CreateBall();
			_gameIsStarted = false;
			_bricksManager.gameObject.SetActive(true);
			_bricksManager.CreateBricks();
			_platform.SetThePlatformSpeed(_platformSpeed);
		}


		private void OnEnable()
		{
			Ball.OnBallDeath += ShowGameOverScreen;
			Brick.OnBrickDestroy += OnBrickDestroy;
			Brick.OnBrickHitingDeadthZone += ShowGameOverScreen;
			Collectables.OnBonusPickUp += OnBonusPickUp;
		}


		private void OnDisable()
		{
			Ball.OnBallDeath -= ShowGameOverScreen;
			Brick.OnBrickDestroy -= OnBrickDestroy;
			Brick.OnBrickHitingDeadthZone -= ShowGameOverScreen;
			Collectables.OnBonusPickUp -= OnBonusPickUp;
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
				StartCoroutine(BrickMove());
			}
		}


		public void SetBallSpeed(float targetSpeed)
		{
			StartCoroutine(SetBallSpeedOnSpeedUpTimePeriod(targetSpeed));
		}


		private IEnumerator SetBallSpeedOnSpeedUpTimePeriod(float targetSpeed)
		{
			_ball.SetTheBallSpeed(targetSpeed);
			yield return new WaitForSeconds(15f);
			_ball.SetTheBallSpeed(_ballSpeed);
		}


		public Platform GetPlatformReference()
		{
			return _platform;
		}


		public void StartSlowMotion(float targetTime)
		{
			StartCoroutine(SetTimeScaleOnSlowMotionTimePeriod(targetTime));
		}


		private IEnumerator SetTimeScaleOnSlowMotionTimePeriod(float targetTime)
		{
			_sessionTimeState = targetTime;
			Time.timeScale = _sessionTimeState;
			yield return new WaitForSeconds(7);
			_sessionTimeState = 1f;
			Time.timeScale = _sessionTimeState;
		}


		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			_sessionTimeState = 1;
			Time.timeScale = _sessionTimeState;
		}


		public void PauseGame()
		{
			Time.timeScale = 0;
			_uiManager.ShowPauseMenu();
		}


		public void ContinueGame()
		{
			Time.timeScale = _sessionTimeState;
			_uiManager.HidePauseMenu();
		}


		public void AddScoreValue(int targetScore)
		{
			_uiManager.UpdateScoreValue(targetScore);
		}


		private IEnumerator BrickMove()
		{
			while (true)
			{
				yield return new WaitForSeconds(_timeToBricksMoveInSeconds);
				if (_gameIsStarted)
				{
					_bricksManager.MoveBricks();
				}
			}
		}


		private void OnBonusPickUp()
		{
			AddScoreValue(_bonusScoreValue);
		}


		private void OnBrickDestroy()
		{
			if (_bricksManager.CountRemainingBricks() == 0)
			{
				_bricksManager.CreateBricks();
			}
			AddScoreValue(_brickScoreCost);
		}


		private void HoldBallOnPlatform()
		{
			_ball.HoldBallOnPlatform(_platform);
		}


		private void StartGame()
		{
			_gameIsStarted = true;
			_ball.SetTheBallSpeed(_ballSpeed);
			_ball.PushTheBall();
		}


		private void ShowGameOverScreen()
		{
			_gameOverScreen.SetActive(true);
			Time.timeScale = 0;
		}


		private void CreateBall()
		{
			_ball = Instantiate(_ballPrefab, _platform.transform.position, Quaternion.identity);
		}
	}
}
