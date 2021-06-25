using UnityEngine;


namespace Tools
{
	[CreateAssetMenu(fileName = "GameParameters", menuName = "CreateGameParametersObject")]
	public class GameParameters : ScriptableObject
	{
		public float PlayerMovementSpeed;
		public int BonusScorePointsValue;
		public int BrickStackMovementSpeed;
	}
}
