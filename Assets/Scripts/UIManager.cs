using UnityEngine;
using TMPro;
using System;


namespace Tools
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _scoreText;
		[SerializeField]
		private TextMeshProUGUI _timeText;
		[SerializeField]
		private GameObject _pauseMenuPanel;
		private int _scorePoints = 0;


		private void Update()
		{
			ShowTimeFromLevelStart();
		}



		public void UpdateScoreValue(int scoreIncrement)
		{
			_scorePoints += scoreIncrement;
			_scoreText.text = "Score: " + _scorePoints;
		}


		public void ShowPauseMenu()
		{
			_pauseMenuPanel.SetActive(true);
		}


		public void HidePauseMenu()
		{
			_pauseMenuPanel.SetActive(false);
		}


		public void ShowTimeFromLevelStart()
		{
			string currentTime = ConvertTimeToDateFormat();
			_timeText.text = "Time: " + currentTime;
		}


		private string ConvertTimeToDateFormat()
		{
			int seconds = 0;
			int minutes = 0;
			int hours = 0;
			int time = Convert.ToInt32(Time.timeSinceLevelLoad);

			hours = time / 3600;
			time %= 3600;
			minutes = time / 60;
			time %= 60;
			seconds = time % 60;

			string convertedtime = hours + ":" + minutes + ":" + seconds;
			return convertedtime;
		}
	}
}
