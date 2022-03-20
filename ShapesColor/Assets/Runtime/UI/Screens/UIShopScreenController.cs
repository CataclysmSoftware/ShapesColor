using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopScreenController : AFScreen
{
	private string UNLOCKED = "Unlocked";
	private string SELECTED = "Selected";
	private string LOCKED = "Locked";
	private string SCORE = "";
	public List<FrameController> FrameControllers { get; set; } = new List<FrameController>();

	private UIShopScreenScreenComponents view;
	private SphereController sphereController;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;

	private int a = 0;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIShopScreenScreenComponents>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();
	}

	private void Start()
	{
		base.Start();
		view.UIMainMenuButton.onClick.AddListener(GoToMainMenu);
		view.UIInformationButton.onClick.AddListener(OnClickOpenInfoPanel);
		sphereController = FindObjectOfType<SphereController>();

		UNLOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Unlocked"];
		SELECTED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Selected"];
		LOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Locked"];
		SCORE = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Score"];

		DestroyFrames();
		InstantiateFrame();
	}

	private void OnEnable()
	{
		try
		{
			UNLOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Unlocked"];
			SELECTED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Selected"];
			LOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Locked"];
			SCORE = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Score"];

			//DestroyFrames();
			//InstantiateFrame();

			UpdateSelectedText();
		}
		catch (Exception ex)
		{
			Debug.Log("Exception ERROR in OnEnable() from UIShopScreenController: " + ex);
		}
	}

	private void OnClickOpenInfoPanel()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowPanel<UIShopInfoPanelPanelController>();
	}

	private void DestroyFrames()
	{
		foreach (Transform child in view.UIScrollViewViewportContent.transform)
		{
			GameObject.Destroy(child.gameObject);
		}
	}

	private void InstantiateFrame()
	{
		var framesController = Resources.LoadAll<FrameController>("Prefabes/FramesPrefabes");
		for (var i = 0; i < framesController.Length; i++)
		{
			var frame = Instantiate(framesController[i], Vector3.zero, Quaternion.identity);
			frame.transform.SetParent(view.UIScrollViewViewportContent.transform);

			FrameControllers.Add(frame);
		}
		UpdateSelectedText();
	}

	private void UpdateSelectedText()
	{
		foreach (var frame in FrameControllers)
		{
			var scores = frame.ScoreText.text.Split(':');
			var result = scores[1];
			var number = int.Parse(result);
			try
			{
				if (sphereController.SphereModel.HighScores[0] < number)
				{
					frame.SelectText.text = LOCKED;
				}
				else
				{
					frame.SelectText.text = UNLOCKED;
					if (frame.gameObject.name == frame.ColorRingsGameManager.ColorRingsModel.RingName + "Frame(Clone)")
					{
						frame.SelectText.text = SELECTED;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Exception ERROR in UpdateSelectedText() from UIShopScreenController: " + ex);
			}
		}
	}

	private void GoToMainMenu()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowScreen<UIMainMenuScreenController>();
	}
}
