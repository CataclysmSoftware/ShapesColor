using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager
{
	private static string GameDataPath => Path.Combine(Application.persistentDataPath, "GameData");

	public static void LoadPersistentData<T>(string fileName, IPersistence<T> persistent)
	{
		var filePath = Path.Combine(GameDataPath, fileName);

		if (!File.Exists(filePath))
		{
			Debug.LogWarning("Couldn't load file");
			return;
		}
		try
		{
			var json = File.ReadAllText(filePath);
			var contract = JsonConvert.DeserializeObject<T>(json);
			persistent.LoadData(contract);
		}
		catch (Exception ex)
		{
			Debug.LogWarning(ex.Message);
		}
	}

	public static void LoadLocalData<T>(string fileName, IPersistence<T> persistent)
	{
		try
		{
			var text = Resources.Load<TextAsset>(fileName).text;
			var contract = JsonConvert.DeserializeObject<T>(text);
			persistent.LoadData(contract);
		}
		catch (Exception ex)
		{
			Debug.LogWarning(ex.Message);
		}
	}

	public static void SavePersistentData(string fileName, string json)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			Debug.LogWarning("Trying to save data but fileName not set!");
			return;
		}

		var filePath = Path.Combine(GameDataPath, fileName);
		if (!Directory.Exists(GameDataPath))
		{
			Directory.CreateDirectory(GameDataPath);
		}

		File.WriteAllText(filePath, json);
	}

	public static void SaveSphereModelData(SphereModel sphereModel)
	{
		var sphereModelContract = sphereModel.SaveData();
		var jsonData = JsonConvert.SerializeObject(sphereModelContract);
		SavePersistentData("SphereData.json", jsonData);
	}

	public static SphereModel LoadSphereModelData()
	{
		var sphereModel = new SphereModel();
		LoadPersistentData("SphereData.json", sphereModel);
		return sphereModel;
	}

	public static void SaveColorRingsModelData(ColorRingsModel colorRingsModel)
	{
		var colorRingsModelContract = colorRingsModel.SaveData();
		var jsonData = JsonConvert.SerializeObject(colorRingsModelContract);
		SavePersistentData("GameData.json", jsonData);
	}

	public static ColorRingsModel LoadColorRingModelData()
	{
		var colorRingsModel = new ColorRingsModel();
		LoadPersistentData("GameData.json", colorRingsModel);
		if (colorRingsModel.RingName == null)
		{
			colorRingsModel.RingName = "CircleRingPrefabe";
		}
		return colorRingsModel;
	}

	public static void SaveLanguageModelData(LanguageModel languageModel)
	{
		var languageModelContract = languageModel.SaveData();
		var jsonData = JsonConvert.SerializeObject(languageModelContract);
		SavePersistentData("Language.json", jsonData);
	}

	public static LanguageModel LoadLanguageModelData()
	{
		var languageModel = new LanguageModel();
		LoadLocalData("Language/Language", languageModel);
		return languageModel;
	}
}
