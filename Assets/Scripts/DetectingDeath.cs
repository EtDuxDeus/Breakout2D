using UnityEngine;


namespace Tools
{
	public class DetectingDeath : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Ball")
			{
				Ball ball = collision.GetComponent<Ball>();
				ball.Die();
			}
		}
	}
}
