
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;

#if APPADVISORY_ADS
using AppAdvisory.Ads;
#endif

namespace AppAdvisory.MathGame
{
	public class MoreGamesButton : ButtonHelper 
	{
		string URL = "http://app-advisory.com";

		override public void OnClicked()
		{
			print ("OnClicked : " + gameObject.name);
			#if APPADVISORY_ADS
			AdsManager.instance.ShowRewardedVideo ((bool success) => {
			print("add your own code here if you want to offer something to the player");
			});
			#endif
		}
	}
}