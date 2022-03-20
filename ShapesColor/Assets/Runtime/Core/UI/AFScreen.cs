using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFScreen : AFMonoBehaviour
{
	public ScreenManager ScreenManager { get; set; }
	public LanguageModel Language { get; set; }

	public void Awake()
	{
		ScreenManager = FindObjectOfType<ScreenManager>();
	}

	public void Start()
	{
		
	}
}
