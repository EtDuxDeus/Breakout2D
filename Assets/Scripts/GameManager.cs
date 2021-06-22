using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _ballPrefab;
		[SerializeField]
		private GameObject _ball;
		[SerializeField]
		private GameObject _platform;
		private Rigidbody2D _ballRigidBody;
		private bool _gameIsStarted;

		public static float BallSpeed = 250f;


		private void Start()
		{
			CreateBall();
			_ballRigidBody = _ball.GetComponent<Rigidbody2D>();
			_gameIsStarted = false;
		}


		private void Update()
		{
			if (!_gameIsStarted)
			{
				Vector3 platformPosition = _platform.transform.position;
				Vector3 ballPosition = new Vector3(platformPosition.x, platformPosition.y + 0.35f, platformPosition.z);
				_ball.transform.position = ballPosition;
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_ballRigidBody.isKinematic = false;
				_ballRigidBody.AddForce(new Vector2(0, BallSpeed));
				_gameIsStarted = true;
			}
		}


		private void CreateBall()
		{
			_ball = Instantiate(_ballPrefab);
		}
	}
}
