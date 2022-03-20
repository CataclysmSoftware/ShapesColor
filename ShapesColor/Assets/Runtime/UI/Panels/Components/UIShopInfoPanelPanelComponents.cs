using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UIShopInfoPanelPanelComponents : AFMonoBehaviour
{
	public Image UIPanelImage{ get; protected set; }
	public Text UIPanelImageInfoText{ get; protected set; }
	public Button UIPanelImageExitButton{ get; protected set; }

	private void Awake()
	{
		UIPanelImage = transform.Find("PanelImage").GetComponent<Image>();
		UIPanelImageInfoText = transform.Find("PanelImage/InfoText").GetComponent<Text>();
		UIPanelImageExitButton = transform.Find("PanelImage/ExitButton").GetComponent<Button>();
	}
}