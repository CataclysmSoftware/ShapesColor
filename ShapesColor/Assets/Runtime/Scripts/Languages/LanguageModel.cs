using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageContract
{
	public Dictionary<string, string> Words { get; set; }
}

public class LanguageModel : IPersistence<LanguageContract>
{
	public Dictionary<string, string> Words = new Dictionary<string, string>();

	public LanguageModel(Dictionary<string, string> words)
	{
		Words = words;
	}

	public LanguageModel()
	{
		Words = new Dictionary<string, string>();
	}

	public LanguageContract SaveData()
	{
		return new LanguageContract
		{
			Words = Words
		};
	}

	public void LoadData(LanguageContract contract)
	{
		Words = contract.Words;
	}
}

