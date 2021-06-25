using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class BallSpeedUpBonus : Collectables
	{
		private float _targetBallSpeed = 400f;


		protected override void ApplyEffect()
		{
			_gameManager.SetBallSpeed(_targetBallSpeed);
		}
	}
}
