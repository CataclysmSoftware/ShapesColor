using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuScreenScreenController : AFScreen
{
	private UIMainMenuScreenScreenComponents view;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIMainMenuScreenScreenComponents>();
	}
}