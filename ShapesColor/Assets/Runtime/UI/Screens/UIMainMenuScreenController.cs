using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuScreenController : AFScreen
{
	private UIMainMenuScreenScreenComponents view;
	private RingsManager ringsManager;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIMainMenuScreenScreenComponents>();
		ringsManager = FindObjectOfType<RingsManager>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		view.UINewGameButton.onClick.AddListener(StartNewGame);
		view.UILeaderBoardButton.onClick.AddListener(GoToLeaderBoardScreen);
		view.UISettingButton.onClick.AddListener(GoToSettingScreen);
		view.UIShopButton.onClick.AddListener(GoToShopScreen);
		view.UICloseAppButton.onClick.AddListener(OnClickCloseApp);

		view.UINewGameButtonStartText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-MainMenu-Start"];
		view.UILeaderBoardButtonLeaderBoardText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-MainMenu-Leaderboard"];
	}

	private void OnEnable()
	{
		try
		{
			view.UINewGameButtonStartText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-MainMenu-Start"];
			view.UILeaderBoardButtonLeaderBoardText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-MainMenu-Leaderboard"];
		}
		catch (Exception ex)
		{

		}
	}

	private void OnClickCloseApp()
	{
		buttonSoundManager.PlayButtonAudio();
		Application.Quit();
	}

	private void GoToShopScreen()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UIShopScreenController>();
	}

	private void GoToSettingScreen()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UISettingsScreenController>();
	}

	private void GoToLeaderBoardScreen()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UILeaderBoardScreenController>();
	}

	private void StartNewGame()
	{
		buttonSoundManager.PlayButtonAudio();
		ringsManager.NewGame();
		ScreenManager.ShowScreen<UIGameplayScreenController>();
	}

	private void OnDestroy()
	{
		view.UINewGameButton.onClick.RemoveAllListeners();
		view.UILeaderBoardButton.onClick.RemoveAllListeners();
		view.UICloseAppButton.onClick.RemoveAllListeners();
	}
}
