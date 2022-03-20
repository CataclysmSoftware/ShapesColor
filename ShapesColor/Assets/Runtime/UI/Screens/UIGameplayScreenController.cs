using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayScreenController : AFScreen
{
	private List<string> BONUSES = new List<string> { "ColorBonusButton", "HeartBonusButton", "ShakeBonusButton", "SpeedDecreaseBonusButton", "SpeedIncreaseBonusButton" };

	public Transform BonusObject { get; set; }

	private UIGameplayScreenScreenComponents view;
	private SphereController sphereController;
	private RingsManager ringsManager;
	private SoundManager buttonSoundManager;
	private ColorRingsGameManager gameManager;
	private AdsManager adsManager;
	private string lastBonus;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIGameplayScreenScreenComponents>();
		sphereController = FindObjectOfType<SphereController>();
		ringsManager = FindObjectOfType<RingsManager>();
		buttonSoundManager = FindObjectOfType<SoundManager>();
		sphereController.SphereModel.Lives.OnChanged += ModifyLivesText;
		sphereController.SphereModel.Score.OnChanged += ModifyScoreText;
		lastBonus = BONUSES[0];
		gameManager = FindObjectOfType<ColorRingsGameManager>();
		adsManager = FindObjectOfType<AdsManager>();
	}

	private void Start()
	{
		SetUpScreen();
		InvokeRepeating("SpawnBonus", 5f, 5f);

		view.UIHomeButton.onClick.AddListener(OnClickPauseMenu);
		view.UIColorHolderBlueButton.onClick.AddListener(OnClickBlueButton);
		view.UIColorHolderMagentaButton.onClick.AddListener(OnClickMagentaButton);
		view.UIColorHolderRedButton.onClick.AddListener(OnClickRedButton);
		view.UIColorHolderCyanButton.onClick.AddListener(OnClickCyanButton);
		view.UIColorHolderGreenButton.onClick.AddListener(OnClickGreenButton);
		view.UIColorHolderYellowButton.onClick.AddListener(OnClickYellowButton);
	}

	private void Update()
	{
		if (BonusObject != null)
		{
			BonusObject.position = new Vector3(BonusObject.position.x, BonusObject.position.y - 200 * Time.deltaTime, BonusObject.position.z);
			if (BonusObject.position.y < Screen.height / 9)
			{
				Destroy(BonusObject.gameObject);
			}
		}
	}

	private void SpawnBonus()
	{
		var bonusNumber = Random.Range(0, BONUSES.Count);

		if (Constants.SPEED < 100 && bonusNumber == 3)
		{
			bonusNumber = 0;
		}

		if (lastBonus == BONUSES[bonusNumber])
		{
			bonusNumber = (bonusNumber + 1) % (BONUSES.Count);
		}

		var prefabe = Resources.Load<Transform>("Prefabes/Bonus/" + BONUSES[bonusNumber]);

		if (BonusObject == null)
		{
			BonusObject = Instantiate(prefabe, new Vector3(Random.Range(50f, Screen.width - 50), Screen.height - 100, 0), Quaternion.identity);
			BonusObject.SetParent(transform);
			lastBonus = BONUSES[bonusNumber];
		}
	}

	private void OnEnable()
	{
		ModifyUiColorButton(true);
		SetUpScreen();
	}

	private void OnClickPauseMenu()
	{
		buttonSoundManager.PlayButtonAudio();
		ScreenManager.ShowPanel<UIGameplayPauseMenuPanelPanelController>();
		Time.timeScale = 0f;
	}

	public void ModifyUiColorButton(bool state)
	{
		view.UIColorHolderBlueButton.gameObject.SetActive(state);
		view.UIColorHolderCyanButton.gameObject.SetActive(state);
		view.UIColorHolderGreenButton.gameObject.SetActive(state);
		view.UIColorHolderMagentaButton.gameObject.SetActive(state);
		view.UIColorHolderRedButton.gameObject.SetActive(state);
		view.UIColorHolderYellowButton.gameObject.SetActive(state);

		Time.timeScale = state ? 1 : 0;
	}

	private void SetUpScreen()
	{
		view.UIHeartHolderHeartImage1.gameObject.SetActive(true);
		view.UIHeartHolderHeartImage2.gameObject.SetActive(true);
		view.UIHeartHolderHeartImage3.gameObject.SetActive(true);
		view.UIScoreText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GamePlay-Score"] + ": 0";
		view.UIColorHolderBlueButton.image.color = Constants.BLUE;
		view.UIColorHolderMagentaButton.image.color = Constants.MAGENTA;
		view.UIColorHolderYellowButton.image.color = Constants.YELLOW;
		view.UIColorHolderGreenButton.image.color = Constants.GREEN;
		view.UIColorHolderRedButton.image.color = Constants.RED;
		view.UIColorHolderCyanButton.image.color = Constants.CYAN;
	}

	private void GameOver()
	{
		if (adsManager.CanWatchRewardedAd && ringsManager.WatchRwardAdOneTime)
		{
			ScreenManager.ShowPanel<UIWatchAdRewardPanelPanelController>();
		}
		else
		{
			ScreenManager.ShowPanel<UIGameplayGameOverPanelPanelController>();
		}

		ringsManager.WatchRwardAdOneTime = false;

		//ModifyUiColorButton(false);
		if (BonusObject != null)
		{
			Destroy(BonusObject.gameObject);
		}
		Time.timeScale = 0f;
	}

	public void RestartGame()
	{
		ringsManager.NewGame();
		sphereController.Renderer.material.color = Constants.WHITE;
		ModifyUiColorButton(true);
	}

	private void ModifyLivesText(Observable<int> value)
	{
		switch (value.Value)
		{
			case 0:
				view.UIHeartHolderHeartImage1.gameObject.SetActive(false);
				view.UIHeartHolderHeartImage2.gameObject.SetActive(false);
				view.UIHeartHolderHeartImage3.gameObject.SetActive(false);
				GameOver();
				break;
			case 1:
				view.UIHeartHolderHeartImage1.gameObject.SetActive(true);
				view.UIHeartHolderHeartImage2.gameObject.SetActive(false);
				view.UIHeartHolderHeartImage3.gameObject.SetActive(false);
				break;
			case 2:
				view.UIHeartHolderHeartImage1.gameObject.SetActive(true);
				view.UIHeartHolderHeartImage2.gameObject.SetActive(true);
				view.UIHeartHolderHeartImage3.gameObject.SetActive(false);
				break;
			case 3:
				view.UIHeartHolderHeartImage1.gameObject.SetActive(true);
				view.UIHeartHolderHeartImage2.gameObject.SetActive(true);
				view.UIHeartHolderHeartImage3.gameObject.SetActive(true);
				break;

		}
	}

	private void ModifyScoreText(Observable<int> value)
	{
		view.UIScoreText.text = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-GamePlay-Score"] + ": " + value.ToString();
	}

	private void OnClickYellowButton()
	{
		sphereController.Renderer.material.color = Constants.YELLOW;
	}

	private void OnClickGreenButton()
	{
		sphereController.Renderer.material.color = Constants.GREEN;
	}

	private void OnClickRedButton()
	{
		sphereController.Renderer.material.color = Constants.RED;
	}

	private void OnClickBlueButton()
	{
		sphereController.Renderer.material.color = Constants.BLUE;
	}

	private void OnClickMagentaButton()
	{
		sphereController.Renderer.material.color = Constants.MAGENTA;
	}

	private void OnClickCyanButton()
	{
		sphereController.Renderer.material.color = Constants.CYAN;
	}

	private void OnDestroy()
	{
		view.UIHomeButton.onClick.RemoveAllListeners();
		view.UIColorHolderBlueButton.onClick.RemoveAllListeners();
		view.UIColorHolderMagentaButton.onClick.RemoveAllListeners();
		view.UIColorHolderRedButton.onClick.RemoveAllListeners();
		view.UIColorHolderCyanButton.onClick.RemoveAllListeners();
		view.UIColorHolderGreenButton.onClick.RemoveAllListeners();
		view.UIColorHolderYellowButton.onClick.RemoveAllListeners();
	}
}
