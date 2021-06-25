using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tools
{
	public class GrowPlatformBonus : Collectables
	{
		[SerializeField]
		private Platform _platform;


		protected override void ApplyEffect()
		{
			SetPlatformReference();
			_platform.transform.localScale = new Vector3(_platform.transform.localScale.x + 0.25f, _platform.transform.localScale.y, _platform.transform.localScale.z);
		}


		public void SetPlatformReference()
		{
			_platform = _gameManager.GetPlatformReference();
		}
	}
}
