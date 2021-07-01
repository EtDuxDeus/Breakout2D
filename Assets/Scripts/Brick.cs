using UnityEngine;
using System;


namespace Tools
{
	public class Brick : MonoBehaviour
	{
		public static event Action OnBrickDestroy;
		public static event Action OnBrickHitingDeadthZone;


		[SerializeField]
		private ParticleSystem _deathEffect;


		public BricksManager _bricksManager;
		public CollectablesManager _collectablesManager;


		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.tag == "Ball")
			{
				Ball ball = collision.gameObject.GetComponent<Ball>();
				DestroyOnBallHit();
				OnBrickDestroy?.Invoke();
			}
			if (collision.gameObject.tag == "BottomBorder" | collision.gameObject.tag == "Platform")
			{
				_bricksManager.DestroyAllBricks();
				OnBrickHitingDeadthZone?.Invoke();
			}
		}


		private void DestroyOnBallHit()
		{
			Destroy(gameObject);
			_bricksManager.DeleteBrickFromList(this);
			SpawnParticlesOnDestroy();

			float bonusSpawnChance = UnityEngine.Random.Range(0, 100f);

			if (bonusSpawnChance <= _collectablesManager.GetBonusSpawnChance())
			{
				SpawnBonus();
			}
		}


		private void SpawnBonus()
		{
			Collectables newBonusPrefab = _collectablesManager.GetRandomBonus();
			Collectables newBonus = Instantiate(newBonusPrefab, transform.position, Quaternion.identity);
		}


		private void SpawnParticlesOnDestroy()
		{
			Vector3 particlesSpawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
			GameObject deathEffect = Instantiate(_deathEffect.gameObject, particlesSpawnPosition, Quaternion.identity);
			Destroy(deathEffect, _deathEffect.main.startLifetime.constant);
		}
	}
}