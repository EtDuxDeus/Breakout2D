using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class Ball : MonoBehaviour
	{
		public static event Action OnBallDeath;

		private Rigidbody2D _ballRigidBody;
		private float _ballSpeed;



		private void Awake()
		{
			_ballRigidBody = gameObject.GetComponent<Rigidbody2D>();
		}

		public void PushTheBall()
		{
			_ballRigidBody.isKinematic = false;
			_ballRigidBody.AddForce(new Vector2(0, _ballSpeed));
		}


		public void SetTheBallSpeed(float targetSpeed)
		{
			_ballSpeed = targetSpeed;
		}


		public void Die()
		{
			OnBallDeath?.Invoke();
			Destroy(gameObject, 1f);
		}
	}
}
