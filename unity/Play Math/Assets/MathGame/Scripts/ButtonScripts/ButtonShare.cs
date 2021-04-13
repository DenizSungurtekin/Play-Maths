
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
using MenuBarouch;

namespace AppAdvisory.MathGame
{
	public class ButtonShare : ButtonHelper 
	{
		#if !VS_SHARE
		public RectTransform buttonVerySimpleShare;
		public string VerySimpleAdsURL = "http://u3d.as/oWD";
		#endif
		override public void OnClicked()
		{
			#if !VS_SHARE
			Debug.LogWarning("To take and share screenshots, you need Very Simple Share: " + VerySimpleAdsURL);
			Debug.LogWarning("Very Simple Share: " + VerySimpleAdsURL);
			Debug.LogWarning("Very Simple Share is ready to use in the game template: " + VerySimpleAdsURL);
			//		AnimVerySimpleShare(false);
			#endif
			RemoveListener();
		}
	}
}