using UnityEngine;
using System;


namespace Tools
{
	public class AudioManager : MonoBehaviour
	{
		[SerializeField]
		private AudioSource _audioPlayer;
		[SerializeField]
		private AudioClip _deathTrack;
		[SerializeField]
		private AudioClip _bonusPickUpTrack;
		[SerializeField]
		private AudioClip _brickDestructionTrack;


		private void OnEnable()
		{
			Ball.OnBallDeath += PlayMusicOnGameOver;
			Brick.OnBrickDestroy += PlayTrackOnBrickDestroy;
			Brick.OnBrickHitingDeadthZone += PlayMusicOnGameOver;
			Collectables.OnBonusPickUp += PlayTrackOnBonusPickUp;
		}

		private void OnDisable()
		{
			Ball.OnBallDeath -= PlayMusicOnGameOver;
			Brick.OnBrickDestroy -= PlayTrackOnBrickDestroy;
			Brick.OnBrickHitingDeadthZone -= PlayMusicOnGameOver;
			Collectables.OnBonusPickUp -= PlayTrackOnBonusPickUp;
		}


		private void PlayMusicOnGameOver()
		{
			_audioPlayer.Stop();
			_audioPlayer.clip = _deathTrack;
			_audioPlayer.Play();
		}


		private void PlayTrackOnBrickDestroy()
		{
			_audioPlayer.Stop();
			_audioPlayer.clip = _brickDestructionTrack;
			_audioPlayer.Play();
		}


		private void PlayTrackOnBonusPickUp()
		{
			_audioPlayer.Stop();
			_audioPlayer.clip = _bonusPickUpTrack;
			_audioPlayer.Play();
		}
	}
}
