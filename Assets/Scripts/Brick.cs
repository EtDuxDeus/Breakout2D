using UnityEngine;
using System;


namespace Tools
{
	public class Brick : MonoBehaviour
	{
		public static event Action OnBrickDestroy;

		[SerializeField]
		private ParticleSystem _deathEffect;


		public BricksManager _bricksManager;


		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.tag == "Ball")
			{
				Ball ball = collision.gameObject.GetComponent<Ball>();
				DestroyOnBallHit();
				OnBrickDestroy?.Invoke();
			}
		}


		private void DestroyOnBallHit()
		{
			Destroy(gameObject);
			_bricksManager.DeleteBrickFromList(this);
			SpawnParticlesOnDestroy();
		}


		private void SpawnParticlesOnDestroy()
		{
			Vector3 particlesSpawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
			GameObject deathEffect = Instantiate(_deathEffect.gameObject, particlesSpawnPosition, Quaternion.identity);
			Destroy(deathEffect, _deathEffect.main.duration);
		}
	}
}