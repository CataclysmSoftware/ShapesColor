using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopInfoPanelPanelController : AFScreen
{
	private UIShopInfoPanelPanelComponents view;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIShopInfoPanelPanelComponents>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		view.UIPanelImageExitButton.onClick.AddListener(OnClickClosePanel);
		view.UIPanelImageInfoText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-ShopInfo-Info"];
	}

	private void OnEnable()
	{
		try
		{
			view.UIPanelImageInfoText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-ShopInfo-Info"];
		}
		catch (Exception ex)
		{

		}
	}

	private void OnClickClosePanel()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIShopInfoPanelPanelController>();
	}

	private void OnDestroy()
	{
		view.UIPanelImageExitButton.onClick.RemoveAllListeners();
	}
}