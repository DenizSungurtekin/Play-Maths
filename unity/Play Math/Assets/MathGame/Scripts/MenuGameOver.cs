
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace AppAdvisory.MathGame
{
	public class MenuGameOver : MonoBehaviour 
	{
		public Text level;
		public Text score;
		public Text bestScore;

		public GameObject newBestScoreLabel;


		void OnEnable(){
			level.text = ScoreManager.GetLastLevel ().ToString ();
			score.text = ScoreManager.GetLastScore ().ToString ();
			bestScore.text = ScoreManager.GetBestScore ().ToString ();

			bool isNewBest = ScoreManager.GetLastScoreIsBest ();

			if (isNewBest) {
				newBestScoreLabel.SetActive (true);
			} else {
				newBestScoreLabel.SetActive (false);
			}
		}
	}
}