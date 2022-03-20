using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
	public Dictionary<Type, AFScreen> Screens = new Dictionary<Type, AFScreen>();

	public AFScreen ActiveScreen { get; set; } = null;
	public AFScreen PreviousScreen { get; set; } = null;
	public AFScreen FirstScreen { get; set; } = null;

	private void Awake()
	{
		foreach (var screen in GetComponentsInChildren<AFScreen>())
		{
			Screens[screen.GetType()] = screen;
		}

		foreach (var keys in Screens.Keys)
		{
			Screens[keys].gameObject.GetComponent<RectTransform>().offsetMin = Vector3.zero;
			Screens[keys].gameObject.GetComponent<RectTransform>().offsetMax = Vector3.zero;
			Screens[keys].gameObject.SetActive(false);
		}
	}

	private void Start()
	{
		if (FirstScreen != null)
			ShowScreen(FirstScreen.GetType());
	}

	public void ShowScreen<T>() where T : AFScreen
	{
		ShowScreen(typeof(T));
	}

	public void ShowPanel<T>() where T : AFScreen
	{
		ShowPanel(typeof(T));
	}

	public void ShowPanel(Type type)
	{
		Screens[type].gameObject.SetActive(true);
	}

	public void ClosePanel<T>() where T : AFScreen
	{
		ClosePanel(typeof(T));
	}

	public void ClosePanel(Type type)
	{
		Screens[type].gameObject.SetActive(false);
	}

	public void ShowScreen(Type type)
	{
		PreviousScreen = ActiveScreen;
		ActiveScreen = Screens[type];

		PreviousScreen?.gameObject.SetActive(false);
		ActiveScreen.gameObject.SetActive(true);
	}

	public void SetFirstScreen<T>()
	{
		SetFirstScreen(typeof(T));
	}

	public void SetFirstScreen(Type type)
	{
		FirstScreen = Screens[type];
	}
}
