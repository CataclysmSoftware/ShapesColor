using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIGameplayGameOverPanelPanelComponents : AFMonoBehaviour
{
	public Image UIBackgroundMenuImage{ get; protected set; }
	public Button UIMainMenuButton{ get; protected set; }
	public Text UIMainMenuButtonText{ get; protected set; }
	public Text UIPanelText{ get; protected set; }
	public Button UIRestartGameButton{ get; protected set; }
	public Text UIRestartGameButtonText{ get; protected set; }

	private void Awake()
	{
		UIBackgroundMenuImage = transform.Find("BackgroundMenuImage").GetComponent<Image>();
		UIMainMenuButton = transform.Find("MainMenuButton").GetComponent<Button>();
		UIMainMenuButtonText = transform.Find("MainMenuButton/Text").GetComponent<Text>();
		UIPanelText = transform.Find("PanelText").GetComponent<Text>();
		UIRestartGameButton = transform.Find("RestartGameButton").GetComponent<Button>();
		UIRestartGameButtonText = transform.Find("RestartGameButton/Text").GetComponent<Text>();
	}
}