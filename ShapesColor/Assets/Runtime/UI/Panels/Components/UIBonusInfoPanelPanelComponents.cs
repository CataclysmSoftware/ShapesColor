using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIBonusInfoPanelPanelComponents : AFMonoBehaviour
{
	public Image UIPanelImage{ get; protected set; }
	public Button UIPanelImageClosepanelButton{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolder{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolderHeartBonusHolder{ get; protected set; }
	public Image UIPanelImageBonusInfoHolderHeartBonusHolderImage{ get; protected set; }
	public Text UIPanelImageBonusInfoHolderHeartBonusHolderText{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolderColorBonusHolder{ get; protected set; }
	public Image UIPanelImageBonusInfoHolderColorBonusHolderImage{ get; protected set; }
	public Text UIPanelImageBonusInfoHolderColorBonusHolderText{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolder{ get; protected set; }
	public Image UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderImage{ get; protected set; }
	public Text UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderText{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolder{ get; protected set; }
	public Image UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderImage{ get; protected set; }
	public Text UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderText{ get; protected set; }
	public RectTransform UIPanelImageBonusInfoHolderShackeBonusHolder{ get; protected set; }
	public Image UIPanelImageBonusInfoHolderShackeBonusHolderImage{ get; protected set; }
	public Text UIPanelImageBonusInfoHolderShackeBonusHolderText{ get; protected set; }

	private void Awake()
	{
		UIPanelImage = transform.Find("PanelImage").GetComponent<Image>();
		UIPanelImageClosepanelButton = transform.Find("PanelImage/ClosepanelButton").GetComponent<Button>();
		UIPanelImageBonusInfoHolder = transform.Find("PanelImage/BonusInfoHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderHeartBonusHolder = transform.Find("PanelImage/BonusInfoHolder/HeartBonusHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderHeartBonusHolderImage = transform.Find("PanelImage/BonusInfoHolder/HeartBonusHolder/Image").GetComponent<Image>();
		UIPanelImageBonusInfoHolderHeartBonusHolderText = transform.Find("PanelImage/BonusInfoHolder/HeartBonusHolder/Text").GetComponent<Text>();
		UIPanelImageBonusInfoHolderColorBonusHolder = transform.Find("PanelImage/BonusInfoHolder/ColorBonusHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderColorBonusHolderImage = transform.Find("PanelImage/BonusInfoHolder/ColorBonusHolder/Image").GetComponent<Image>();
		UIPanelImageBonusInfoHolderColorBonusHolderText = transform.Find("PanelImage/BonusInfoHolder/ColorBonusHolder/Text").GetComponent<Text>();
		UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolder = transform.Find("PanelImage/BonusInfoHolder/SpeedDecreaseBonusHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderImage = transform.Find("PanelImage/BonusInfoHolder/SpeedDecreaseBonusHolder/Image").GetComponent<Image>();
		UIPanelImageBonusInfoHolderSpeedDecreaseBonusHolderText = transform.Find("PanelImage/BonusInfoHolder/SpeedDecreaseBonusHolder/Text").GetComponent<Text>();
		UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolder = transform.Find("PanelImage/BonusInfoHolder/SpeedIncreaseBonusHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderImage = transform.Find("PanelImage/BonusInfoHolder/SpeedIncreaseBonusHolder/Image").GetComponent<Image>();
		UIPanelImageBonusInfoHolderSpeedIncreaseBonusHolderText = transform.Find("PanelImage/BonusInfoHolder/SpeedIncreaseBonusHolder/Text").GetComponent<Text>();
		UIPanelImageBonusInfoHolderShackeBonusHolder = transform.Find("PanelImage/BonusInfoHolder/ShackeBonusHolder").GetComponent<RectTransform>();
		UIPanelImageBonusInfoHolderShackeBonusHolderImage = transform.Find("PanelImage/BonusInfoHolder/ShackeBonusHolder/Image").GetComponent<Image>();
		UIPanelImageBonusInfoHolderShackeBonusHolderText = transform.Find("PanelImage/BonusInfoHolder/ShackeBonusHolder/Text").GetComponent<Text>();
	}
}