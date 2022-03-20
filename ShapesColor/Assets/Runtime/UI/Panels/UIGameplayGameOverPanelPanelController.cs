using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplayGameOverPanelPanelController : AFScreen
{
	private UIGameplayGameOverPanelPanelComponents view;
	private UIGameplayScreenController gameplayScreenController;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;
	private AdsManager adsManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIGameplayGameOverPanelPanelComponents>();
		gameplayScreenController = FindObjectOfType<UIGameplayScreenController>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
		adsManager = FindObjectOfType<AdsManager>();
	}

	private void Start()
	{
		view.UIRestartGameButton.onClick.AddListener(OnClickRestartGame);
		view.UIMainMenuButton.onClick.AddListener(OnClickExit);
		view.UIMainMenuButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-MainMenu"];
		view.UIPanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-GameOver"];
		view.UIRestartGameButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-RestartGame"];
	}

	private void OnEnable()
	{
		try
		{
			view.UIMainMenuButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-MainMenu"];
			view.UIPanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-GameOver"];
			view.UIRestartGameButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GameOver-RestartGame"];
		}
		catch (Exception ex)
		{

		}
	}

	private void OnClickRestartGame()
	{
		adsManager.ShowInterstitialAd();
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIGameplayGameOverPanelPanelController>();
		//gameplayScreenController.RestartGame();
	}

	private void OnClickExit()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIGameplayGameOverPanelPanelController>();
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
		Time.timeScale = 0f;
	}

	private void OnDestroy()
	{
		view.UIRestartGameButton.onClick.RemoveAllListeners();
		view.UIMainMenuButton.onClick.RemoveAllListeners();
	}
}