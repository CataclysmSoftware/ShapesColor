using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRingsGameManager : MonoBehaviour
{
	public ColorRingsModel ColorRingsModel { get; set; } = new ColorRingsModel();
	public LanguageModel Language { get; set; } = new LanguageModel();
	
	private void Awake()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		ColorRingsModel = PersistenceManager.LoadColorRingModelData();
		Language = PersistenceManager.LoadLanguageModelData();
	}

	private void OnApplicationQuit()
	{
		PersistenceManager.SaveColorRingsModelData(ColorRingsModel);
	}
}