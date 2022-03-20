using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplayPauseMenuPanelPanelController : AFScreen
{
	private UIGameplayPauseMenuPanelPanelComponents view;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIGameplayPauseMenuPanelPanelComponents>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		view.UIResumeGameButton.onClick.AddListener(OnClickResumeGame);
		view.UIMainMenuButton.onClick.AddListener(OnClickExit);
		view.UIMainMenuButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-MainMenu"];
		view.UIPanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-PauseMenu"];
		view.UIResumeGameButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-ResumeGame"];
	}

	private void OnEnable()
	{
		try
		{
			view.UIMainMenuButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-MainMenu"];
			view.UIPanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-PauseMenu"];
			view.UIResumeGameButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-PauseMenu-ResumeGame"];
		}
		catch (Exception ex)
		{
			Debug.Log("Exception ERROR in UIGameplayPauseMenuPanelPanelController: " + ex);
		}
	}

	private void OnClickResumeGame()
	{
		Constants.SPEED -= Constants.SPEED * 0.05f;
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIGameplayPauseMenuPanelPanelController>();
		Time.timeScale = 1f;
	}

	private void OnClickExit()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIGameplayPauseMenuPanelPanelController>();
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
		Time.timeScale = 0f;
	}

	private void OnDestroy()
	{
		view.UIResumeGameButton.onClick.RemoveAllListeners();
		view.UIMainMenuButton.onClick.RemoveAllListeners();
	}
}