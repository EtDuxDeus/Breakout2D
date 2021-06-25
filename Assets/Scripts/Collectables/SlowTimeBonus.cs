using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class SlowTimeBonus : Collectables
	{
		private float _targetTimeForSlowMotion = 0.5f;


		protected override void ApplyEffect()
		{
			_gameManager.StartSlowMotion(_targetTimeForSlowMotion);
		}
	}
}
