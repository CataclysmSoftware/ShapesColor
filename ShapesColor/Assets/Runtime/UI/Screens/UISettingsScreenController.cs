using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettingsScreenController : AFScreen
{
	private ColorRingsGameManager colorRingsGameManager;
	private UISettingsScreenScreenComponents view;
	private Sprite musicOffImage;
	private Sprite musicOnImage;
	private Sprite soundOffImage;
	private Sprite soundOnImage;
	private SoundManager soundManager;
	private ColorRingsGameManager gameManager;
	private List<string> Languages = new List<string>() { "Arabic", "Chinese","Danish",
		"English", "French","Germany", "Hindi","Italian", "Portuguese",
		"Romanian", "Russian", "Turkish", "Spanish" };

	private void Awake()
	{
		base.Awake();
		colorRingsGameManager = FindObjectOfType<ColorRingsGameManager>();
		view = GetComponent<UISettingsScreenScreenComponents>();
		soundManager = FindObjectOfType<SoundManager>();
		musicOffImage = Resources.Load<Sprite>("UIGraphics/UIButtons/MusicOffButton");
		musicOnImage = Resources.Load<Sprite>("UIGraphics/UIButtons/MusicOnButton");
		soundOffImage = Resources.Load<Sprite>("UIGraphics/UIButtons/SoundOffButton");
		soundOnImage = Resources.Load<Sprite>("UIGraphics/UIButtons/SoundOnButton");
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	public void Start()
	{
		view.UIBackSettingButton.onClick.AddListener(BackToMainMenu);
		view.UIMusicButton.onClick.AddListener(ChangeMusicStatus);
		view.UISoundButton.onClick.AddListener(ChangeSoundStatus);
		view.UILanguageDropdown.AddOptions(Languages);
		view.UILanguageDropdown.onValueChanged.AddListener(OnValueChangedSelectLanguage);
		view.UISettingsText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Settings-Settings"];
		view.UILanguageText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Settings-Language"];
		view.UILanguageDropdown.value = Languages.IndexOf(gameManager.ColorRingsModel.Language);
	}

	private void OnEnable()
	{
		try
		{
			view.UISettingsText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Settings-Settings"];
			view.UILanguageText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Settings-Language"];
			ChangeMusicSprite();
			ChangeSoundSprite();
		}
		catch (Exception ex)
		{

		}
	}

	private void ChangeMusicStatus()
	{
		soundManager.PlayButtonAudio();
		colorRingsGameManager.ColorRingsModel.MusicStatus = !colorRingsGameManager.ColorRingsModel.MusicStatus;
		ChangeMusicSprite();

		if(colorRingsGameManager.ColorRingsModel.MusicStatus)
		{
			if(!soundManager.MusicSound.isPlaying)
			{
				soundManager.MusicSound.Play();
			}
		}
		else
		{
			soundManager.MusicSound.Stop();
		}

	}

	private void OnValueChangedSelectLanguage(int value)
	{
		gameManager.ColorRingsModel.Language = Languages[value];
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
		ScreenManager.ShowScreen<UISettingsScreenController>();
	}

	private void ChangeMusicSprite()
	{
		if (colorRingsGameManager.ColorRingsModel.MusicStatus)
		{
			view.UIMusicButton.image.sprite = musicOnImage;
		}
		else
		{
			view.UIMusicButton.image.sprite = musicOffImage;
		}
	}

	private void ChangeSoundSprite()
	{
		if (colorRingsGameManager.ColorRingsModel.SoundStatus)
		{
			view.UISoundButton.image.sprite = soundOnImage;
		}
		else
		{
			view.UISoundButton.image.sprite = soundOffImage;
		}
	}

	private void ChangeSoundStatus()
	{
		soundManager.PlayButtonAudio();
		colorRingsGameManager.ColorRingsModel.SoundStatus = !colorRingsGameManager.ColorRingsModel.SoundStatus;
		ChangeSoundSprite();
	}

	private void BackToMainMenu()
	{
		soundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
	}
}
