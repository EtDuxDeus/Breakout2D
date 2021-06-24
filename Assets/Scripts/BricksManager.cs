using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class BricksManager : MonoBehaviour
	{
		[SerializeField]
		private Brick _brickPrefab;
		[SerializeField]
		private GameObject _brickHolder;
		private List<Brick> _allBricks;
		private float _firstBrickPositionX = -6.75f;
		private float _firstBrickPositionY = 3.5f;
		private float _brickShiftX = 1.25f;
		private float _brickShiftY = 0.75f;


		private void Awake()
		{
			_allBricks = new List<Brick>();
			_brickHolder = Instantiate(_brickHolder);
		}


		public int CountRemainingBricks()
		{
			return _allBricks.Count;
		}


		public void CreateBricks()
		{
			_allBricks = new List<Brick>();
			float currentBrickSpawnPositionX = _firstBrickPositionX;
			float currentBrickSpawnPositionY = _firstBrickPositionY;
			for (int i = 0; i < 7; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					Brick newBrick = Instantiate(_brickPrefab, new Vector3(currentBrickSpawnPositionX, currentBrickSpawnPositionY, 0f), Quaternion.identity);
					newBrick._bricksManager = this;
					_allBricks.Add(newBrick);
					newBrick.gameObject.transform.SetParent(_brickHolder.transform);
					currentBrickSpawnPositionX += _brickShiftX;
					if (j == 11)
					{
						currentBrickSpawnPositionX = _firstBrickPositionX;
					}
				}
				currentBrickSpawnPositionY -= _brickShiftY;
				if (i == 6)
				{
					currentBrickSpawnPositionY = _firstBrickPositionY;
				}
			}
		}


		public void DeleteBrickFromList(Brick brickToDelete)
		{
			_allBricks.Remove(brickToDelete);
		}


		public void DestroyAllBricks()
		{
			foreach (Brick brick in _allBricks)
			{
				Destroy(brick.gameObject);
			}
		}
	}
}
