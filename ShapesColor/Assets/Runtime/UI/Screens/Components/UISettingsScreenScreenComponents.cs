using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UISettingsScreenScreenComponents : AFMonoBehaviour
{
	public Dropdown UILanguageDropdown{ get; protected set; }
	public Button UIBackSettingButton{ get; protected set; }
	public Text UISettingsText{ get; protected set; }
	public Button UIMusicButton{ get; protected set; }
	public Button UISoundButton{ get; protected set; }
	public Text UILanguageText{ get; protected set; }

	private void Awake()
	{
		UILanguageDropdown = transform.Find("LanguageDropdown").GetComponent<Dropdown>();
		UIBackSettingButton = transform.Find("BackSettingButton").GetComponent<Button>();
		UISettingsText = transform.Find("SettingsText").GetComponent<Text>();
		UIMusicButton = transform.Find("MusicButton").GetComponent<Button>();
		UISoundButton = transform.Find("SoundButton").GetComponent<Button>();
		UILanguageText = transform.Find("LanguageText").GetComponent<Text>();
	}
}