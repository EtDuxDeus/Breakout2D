using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class CollectablesManager : MonoBehaviour
	{
		[SerializeField]
		private GameManager _gameManager;
		[SerializeField]
		private List<Collectables> _bonuses;
		[SerializeField, Range(0, 100)]
		private float _bonusSpawnChance = 15;


		private void Awake()
		{
			foreach (Collectables bonus in _bonuses)
			{
				bonus.SetGameManager(_gameManager);
			}
		}


		public float GetBonusSpawnChance()
		{
			return _bonusSpawnChance;
		}


		public Collectables GetRandomBonus()
		{
			return _bonuses[UnityEngine.Random.Range(0, _bonuses.Count)];
		}
	}
}
