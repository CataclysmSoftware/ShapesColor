using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIGameplayPauseMenuPanelPanelComponents : AFMonoBehaviour
{
	public Image UIBackgroundMenuImage{ get; protected set; }
	public Button UIResumeGameButton{ get; protected set; }
	public Text UIResumeGameButtonText{ get; protected set; }
	public Button UIMainMenuButton{ get; protected set; }
	public Text UIMainMenuButtonText{ get; protected set; }
	public Text UIPanelText{ get; protected set; }
	private void Awake()
	{
		UIBackgroundMenuImage = transform.Find("BackgroundMenuImage").GetComponent<Image>();
		UIResumeGameButton = transform.Find("ResumeGameButton").GetComponent<Button>();
		UIResumeGameButtonText = transform.Find("ResumeGameButton/Text").GetComponent<Text>();
		UIMainMenuButton = transform.Find("MainMenuButton").GetComponent<Button>();
		UIMainMenuButtonText = transform.Find("MainMenuButton/Text").GetComponent<Text>();
		UIPanelText = transform.Find("PanelText").GetComponent<Text>();
	}
}