using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class UISettingsScreenScreenController : AFScreen
{
	private UISettingsScreenScreenComponents view;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UISettingsScreenScreenComponents>();
	}
}