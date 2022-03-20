using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIGameplayScreenScreenComponents : AFMonoBehaviour
{
	public Text UIScoreText{ get; protected set; }
	public Button UIHomeButton{ get; protected set; }
	public RectTransform UIColorHolder{ get; protected set; }
	public Button UIColorHolderBlueButton{ get; protected set; }
	public Button UIColorHolderRedButton{ get; protected set; }
	public Button UIColorHolderYellowButton{ get; protected set; }
	public Button UIColorHolderCyanButton{ get; protected set; }
	public Button UIColorHolderMagentaButton{ get; protected set; }
	public Button UIColorHolderGreenButton{ get; protected set; }
	public RectTransform UIHeartHolder{ get; protected set; }
	public Image UIHeartHolderHeartImage1{ get; protected set; }
	public Image UIHeartHolderHeartImage2{ get; protected set; }
	public Image UIHeartHolderHeartImage3{ get; protected set; }

	private void Awake()
	{
		UIScoreText = transform.Find("ScoreText").GetComponent<Text>();
		UIHomeButton = transform.Find("HomeButton").GetComponent<Button>();
		UIColorHolder = transform.Find("ColorHolder").GetComponent<RectTransform>();
		UIColorHolderBlueButton = transform.Find("ColorHolder/BlueButton").GetComponent<Button>();
		UIColorHolderRedButton = transform.Find("ColorHolder/RedButton").GetComponent<Button>();
		UIColorHolderYellowButton = transform.Find("ColorHolder/YellowButton").GetComponent<Button>();
		UIColorHolderCyanButton = transform.Find("ColorHolder/CyanButton").GetComponent<Button>();
		UIColorHolderMagentaButton = transform.Find("ColorHolder/MagentaButton").GetComponent<Button>();
		UIColorHolderGreenButton = transform.Find("ColorHolder/GreenButton").GetComponent<Button>();
		UIHeartHolder = transform.Find("HeartHolder").GetComponent<RectTransform>();
		UIHeartHolderHeartImage1 = transform.Find("HeartHolder/HeartImage1").GetComponent<Image>();
		UIHeartHolderHeartImage2 = transform.Find("HeartHolder/HeartImage2").GetComponent<Image>();
		UIHeartHolderHeartImage3 = transform.Find("HeartHolder/HeartImage3").GetComponent<Image>();
	}
}