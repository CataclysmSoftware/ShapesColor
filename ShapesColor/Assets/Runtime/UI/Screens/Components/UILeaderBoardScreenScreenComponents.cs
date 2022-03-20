using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UILeaderBoardScreenScreenComponents : AFMonoBehaviour
{
	public Text UILeaderboardTitleText{ get; protected set; }
	public Button UIBackButton{ get; protected set; }
	public Text UILeaderBoardText{ get; protected set; }
	public Button UIInfoButton{ get; protected set; }
	public Text UIHightScoreText{ get; protected set; }

	private void Awake()
	{
		UILeaderboardTitleText = transform.Find("LeaderboardTitleText").GetComponent<Text>();
		UIBackButton = transform.Find("BackButton").GetComponent<Button>();
		UILeaderBoardText = transform.Find("LeaderBoardText").GetComponent<Text>();
		UIInfoButton = transform.Find("InfoButton").GetComponent<Button>();
		UIHightScoreText = transform.Find("HightScoreText").GetComponent<Text>();
	}
}