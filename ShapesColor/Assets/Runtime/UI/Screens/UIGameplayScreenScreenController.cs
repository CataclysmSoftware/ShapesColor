using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class UIGameplayScreenScreenController : AFScreen
{
	private UIGameplayScreenScreenComponents view;

	private void Awake()
	{
		base.Awake();
		view = GetComponent<UIGameplayScreenScreenComponents>();
	}
}