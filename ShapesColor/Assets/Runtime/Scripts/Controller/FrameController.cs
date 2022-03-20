using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameController : MonoBehaviour
{
	private string UNLOCKED = "Unlocked";
	private string SELECTED = "Selected";
	private string LOCKED = "Locked";
	private string SCORE = "Score";

	public Text ScoreText { get; set; }
	public Button SelectButton { get; set; }
	public Text SelectText { get; set; }
	public ColorRingsGameManager ColorRingsGameManager { get; set; }
	public UIShopScreenController UIShopScreenController { get; set; }

	private ColorRingsGameManager gameManager;

	private void Awake()
	{
		ScoreText = transform.Find("FrameImage/ScoreText").GetComponent<Text>();
		SelectButton = transform.Find("FrameImage/SelectButton").GetComponent<Button>();
		SelectText = transform.Find("FrameImage/SelectButton/SelectText").GetComponent<Text>();
		ColorRingsGameManager = FindObjectOfType<ColorRingsGameManager>();
		UIShopScreenController = FindObjectOfType<UIShopScreenController>();
		gameManager = FindObjectOfType<ColorRingsGameManager>();

		UNLOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Unlocked"];
		SELECTED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Selected"];
		LOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Locked"];
		SCORE = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Score"];

		var scores = ScoreText.text.Split(':');
		ScoreText.text = SCORE + ":" + scores[1];
	}

	private void Start()
	{
		SelectButton.onClick.AddListener(OnClickUpdateRingName);
	}

	private void OnEnable()
	{
		UNLOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Unlocked"];
		SELECTED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Selected"];
		LOCKED = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Locked"];
		SCORE = gameManager.Language.Words[gameManager.ColorRingsModel.Language + "-Shop-Score"];

		var scores = ScoreText.text.Split(':');
		ScoreText.text = SCORE + ":" + scores[1];
	}

	/// <summary>
	/// The function who update ScoreText.
	/// </summary>
	private void OnClickUpdateRingName()
	{
		if (SelectText.text == UNLOCKED)
		{
			foreach (var frame in UIShopScreenController.FrameControllers)
			{
				if (frame.SelectText.text == SELECTED)
					frame.SelectText.text = UNLOCKED;
			}
			SelectText.text = SELECTED;
			var text1 = "Frame(Clone)";
			var text2 = gameObject.name;
			var result = text2.Replace(text1, "");
			ColorRingsGameManager.ColorRingsModel.RingName = result;
			PersistenceManager.SaveColorRingsModelData(ColorRingsGameManager.ColorRingsModel);
		}
	}
}
