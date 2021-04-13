
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
using System.Collections.Generic;

namespace AppAdvisory.MathGame
{
	public static class Util
	{
		private static System.Random Random = new System.Random();

		public static float RandomValue()
		{
			return (float)Random.NextDouble();
		}

		public static float RandomRange(float min, float max)
		{
			return min + ((float)Random.NextDouble() * (max - min));
		}

		public static int RandomRange(int min, int max)
		{
			return Random.Next(min, max);
		}
	}
}