
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace AppAdvisory.MathGame
{
	public class AnswerInGameButton: ButtonHelper 
	{
		Text text;

		//do the state for mobile normal on highlightened
		void Awake()
		{
			if(Application.isMobilePlatform)
				GetComponent<Button> ().animationTriggers.highlightedTrigger = "Normal";
			else
				GetComponent<Button> ().animationTriggers.highlightedTrigger = "Highlighted";
		}

		override public void OnClicked()
		{
			if(text == null)
				text = GetComponentInChildren<Text> ();

			gameManager.OnClicked (text);
		}
	}
}