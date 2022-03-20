using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : AFScreen
{
	private void Awake()
	{
		base.Awake();
		ScreenManager?.SetFirstScreen<UIMainMenuScreenController>();
	}

	private void Start()
	{
		ScreenManager?.SetFirstScreen<UIMainMenuScreenController>();
	}
}
