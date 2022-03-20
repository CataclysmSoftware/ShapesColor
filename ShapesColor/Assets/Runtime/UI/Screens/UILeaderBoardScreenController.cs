using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILeaderBoardScreenController : AFScreen
{
	private UILeaderBoardScreenScreenComponents view;
	private SphereController sphereController;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;
	private AdsManager adsManager; 

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UILeaderBoardScreenScreenComponents>();
		sphereController = FindObjectOfType<SphereController>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
		adsManager = FindObjectOfType<AdsManager>();
	}

	private void Start()
	{
		view.UIBackButton.onClick.AddListener(BackToMainMenu);
		view.UIInfoButton.onClick.AddListener(OnClickOpenInfoPanel);
		view.UILeaderboardTitleText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Leaderboard-Leaderboard"];
	}

	private void BackToMainMenu()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
	}

	private void OnClickOpenInfoPanel()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowPanel<UIBonusInfoPanelPanelController>();
	}

	private void OnEnable()
	{
		try
		{
			view.UILeaderboardTitleText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Leaderboard-Leaderboard"];
			view.UILeaderBoardText.text = "";
			if (sphereController.SphereModel != null)
			{
				for (int i = 0; i < sphereController.SphereModel.HighScores.Count; i++)
				{
					view.UILeaderBoardText.text += (i + 1) + ". " + sphereController.SphereModel.HighScores[i].ToString() + "\n";
				}
				view.UIHightScoreText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Leaderboard-HighScore"] + ": " + sphereController.SphereModel.HighScores[0].ToString();
			}
		}
		catch (Exception ex)
		{

		}
	}

	private void OnDestroy()
	{
		view.UIBackButton.onClick.RemoveAllListeners();
		view.UIInfoButton.onClick.RemoveAllListeners();
	}
}
