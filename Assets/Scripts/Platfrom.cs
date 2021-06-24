using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class Platfrom : MonoBehaviour
	{
		private float _platformSpeed;


		private void Update()
		{
			MovePlatform();
		}


		public void SetThePlatformSpeed(float Speed)
		{
			_platformSpeed = Speed;
		}


		private void MovePlatform()
		{
			float movement = Input.GetAxis("Horizontal") * _platformSpeed * Time.deltaTime;
			transform.position = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
		}


		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.tag == "Ball")
			{
				Rigidbody2D ballRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
				Vector3 centerOfPlatform = transform.position;
				ballRigidBody.velocity = Vector2.zero;

				float difference = collision.transform.position.x - centerOfPlatform.x;

				ballRigidBody.AddForce(new Vector2(difference * 200, GameManager.BallSpeed));
			}
		}
	}
}
