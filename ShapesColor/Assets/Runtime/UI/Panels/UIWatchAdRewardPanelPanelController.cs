using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWatchAdRewardPanelPanelController : AFScreen
{
	private UIWatchAdRewardPanelPanelComponents view;
	private AdsManager adsManager;
	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIWatchAdRewardPanelPanelComponents>();
		adsManager = FindObjectOfType<AdsManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		view.UIPanelImageCancelButton.onClick.AddListener(OnClickCancel);
		view.UIPanelImageWatchButton.onClick.AddListener(OnClickWatchAd);
		view.UIPanelImageCancelButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Cancel"];
		view.UIPanelImageWatchButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Watch"];
		view.UIPanelImagePanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Info"];
	}

	private void OnEnable()
	{
		try
		{
			view.UIPanelImageCancelButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Cancel"];
			view.UIPanelImageWatchButtonText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Watch"];
			view.UIPanelImagePanelText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-RewardAd-Info"];
		}
		catch (Exception ex)
		{
			Debug.Log("Exception ERROR in OnEnable() from UIWatchAdRewardPanelPanelController: " + ex);
		}
	}

	private void OnClickWatchAd()
	{
		adsManager.ShowRewardedAd();
		ScreenManager.ClosePanel<UIWatchAdRewardPanelPanelController>();
	}

	private void OnClickCancel()
	{
		ScreenManager.ClosePanel<UIWatchAdRewardPanelPanelController>();
		ScreenManager.ShowPanel<UIGameplayGameOverPanelPanelController>();
	}
}