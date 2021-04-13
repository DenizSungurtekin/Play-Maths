
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
	public class ButtonHelper : MonoBehaviour 
	{
		MenuManager _menuManager;
		public MenuManager menuManager
		{
			get 
			{
				if (_menuManager == null)
					_menuManager = FindObjectOfType<MenuManager> ();

				return _menuManager;
			}
		}

		GameManager _gameManager;
		public GameManager gameManager
		{
			get 
			{
				if (_gameManager == null)
					_gameManager = FindObjectOfType<GameManager> ();

				return _gameManager;
			}
		}


		virtual public void OnClicked(){}

		void OnEnable()
		{
			GetComponent<Button> ().onClick.AddListener (OnClicked);
		}

		void OnDisable()
		{
			RemoveListener();
		}

		public void RemoveListener()
		{
			GetComponent<Button> ().onClick.RemoveListener(OnClicked);
		}
	}
}