using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBonusInfoPanelPanelController : AFScreen
{
	private UIBonusInfoPanelPanelComponents view;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIBonusInfoPanelPanelComponents>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		view.UIPanelImageClosepanelButton.onClick.AddListener(OnClickClosePanel);
		buttonSoundManager = FindObjectOfType<SoundManager>();
		view.UIPanelImageBonusInfoHolderColorBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-2"];
		view.UIPanelImageBonusInfoHolderHeartBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-1"];
		view.UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-3"];
		view.UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-4"];
		view.UIPanelImageBonusInfoHolderShackeBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-5"];
	}

	private void OnEnable()
	{
		view.UIPanelImageBonusInfoHolderColorBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-2"];
		view.UIPanelImageBonusInfoHolderHeartBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-1"];
		view.UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-3"];
		view.UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-4"];
		view.UIPanelImageBonusInfoHolderShackeBonusHolderText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Bonus-5"];
	}

	private void OnClickClosePanel()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ClosePanel<UIBonusInfoPanelPanelController>();
	}

	private void OnDestroy()
	{
		view.UIPanelImageClosepanelButton.onClick.RemoveAllListeners();
	}
}