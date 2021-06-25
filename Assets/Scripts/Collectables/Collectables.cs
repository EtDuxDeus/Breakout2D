using System;
using UnityEngine;


namespace Tools
{
	public abstract class Collectables : MonoBehaviour
	{
		public static event Action OnBonusPickUp;

		[SerializeField]
		protected GameManager _gameManager;
		[SerializeField]
		private ParticleSystem _pickUpBonusEffect;


		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Platform")
			{
				ApplyEffect();
				Destroy(gameObject);
				OnBonusPickUp?.Invoke();
				Vector3 particlesSpawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
				GameObject deathEffect = Instantiate(_pickUpBonusEffect.gameObject, particlesSpawnPosition, Quaternion.identity);
				Destroy(deathEffect, _pickUpBonusEffect.main.startLifetime.constant);
			}
			if (collision.gameObject.tag == "BottomBorder")
			{
				Destroy(gameObject);
			}
		}


		public void SetGameManager(GameManager gameManager)
		{
			_gameManager = gameManager;
		}


		protected abstract void ApplyEffect();
	}
}
