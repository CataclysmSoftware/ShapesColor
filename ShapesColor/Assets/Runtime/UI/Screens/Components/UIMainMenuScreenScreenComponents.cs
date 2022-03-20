using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIMainMenuScreenScreenComponents : AFMonoBehaviour
{
	public Button UINewGameButton{ get; protected set; }
	public Text UINewGameButtonStartText{ get; protected set; }
	public Button UILeaderBoardButton{ get; protected set; }
	public Text UILeaderBoardButtonLeaderBoardText{ get; protected set; }
	public Button UISettingButton{ get; protected set; }
	public Button UIShopButton{ get; protected set; }
	public Image UIImage{ get; protected set; }
	public Button UICloseAppButton{ get; protected set; }

	private void Awake()
	{
		UINewGameButton = transform.Find("NewGameButton").GetComponent<Button>();
		UINewGameButtonStartText = transform.Find("NewGameButton/StartText").GetComponent<Text>();
		UILeaderBoardButton = transform.Find("LeaderBoardButton").GetComponent<Button>();
		UILeaderBoardButtonLeaderBoardText = transform.Find("LeaderBoardButton/LeaderBoardText").GetComponent<Text>();
		UISettingButton = transform.Find("SettingButton").GetComponent<Button>();
		UIShopButton = transform.Find("ShopButton").GetComponent<Button>();
		UIImage = transform.Find("Image").GetComponent<Image>();
		UICloseAppButton = transform.Find("CloseAppButton").GetComponent<Button>();
	}
}