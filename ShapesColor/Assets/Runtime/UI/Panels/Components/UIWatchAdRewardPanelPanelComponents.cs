using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIWatchAdRewardPanelPanelComponents : AFMonoBehaviour
{
	public Image UIPanelImage{ get; protected set; }
	public Text UIPanelImagePanelText{ get; protected set; }
	public Button UIPanelImageCancelButton{ get; protected set; }
	public Text UIPanelImageCancelButtonText{ get; protected set; }
	public Button UIPanelImageWatchButton{ get; protected set; }
	public Text UIPanelImageWatchButtonText{ get; protected set; }
	public Image UIPanelImageHeartImage1{ get; protected set; }
	public Image UIPanelImageHeartImage2{ get; protected set; }

	private void Awake()
	{
		UIPanelImage = transform.Find("PanelImage").GetComponent<Image>();
		UIPanelImagePanelText = transform.Find("PanelImage/PanelText").GetComponent<Text>();
		UIPanelImageCancelButton = transform.Find("PanelImage/CancelButton").GetComponent<Button>();
		UIPanelImageCancelButtonText = transform.Find("PanelImage/CancelButton/Text").GetComponent<Text>();
		UIPanelImageWatchButton = transform.Find("PanelImage/WatchButton").GetComponent<Button>();
		UIPanelImageWatchButtonText = transform.Find("PanelImage/WatchButton/Text").GetComponent<Text>();
		UIPanelImageHeartImage1 = transform.Find("PanelImage/HeartImage1").GetComponent<Image>();
		UIPanelImageHeartImage2 = transform.Find("PanelImage/HeartImage2").GetComponent<Image>();
	}
}