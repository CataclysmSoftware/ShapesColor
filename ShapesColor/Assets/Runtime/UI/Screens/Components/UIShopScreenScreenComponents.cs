using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIShopScreenScreenComponents : AFMonoBehaviour
{
	public Button UIMainMenuButton{ get; protected set; }
	public Button UIInformationButton{ get; protected set; }
	public ScrollRect UIScrollView{ get; protected set; }
	public Image UIScrollViewViewport{ get; protected set; }
	public RectTransform UIScrollViewViewportContent{ get; protected set; }

	private void Awake()
	{
		UIMainMenuButton = transform.Find("MainMenuButton").GetComponent<Button>();
		UIInformationButton = transform.Find("InformationButton").GetComponent<Button>();
		UIScrollView = transform.Find("Scroll View").GetComponent<ScrollRect>();
		UIScrollViewViewport = transform.Find("Scroll View/Viewport").GetComponent<Image>();
		UIScrollViewViewportContent = transform.Find("Scroll View/Viewport/Content").GetComponent<RectTransform>();
	}
}