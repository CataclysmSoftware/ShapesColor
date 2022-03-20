using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRingsContract
{
	public bool MusicStatus { get; set; }
	public bool SoundStatus { get; set; }
	public string RingName { get; set; }
	public string Language { get; set; }
}

public class ColorRingsModel : IPersistence<ColorRingsContract>
{
	public bool MusicStatus { get; set; } = true;
	public bool SoundStatus { get; set; } = true;
	public string RingName { get; set; } = "CircleRingPrefabe";
	public string Language { get; set; } = "English";


	public ColorRingsModel(bool musicStatus, bool soundStatus, string ringName, string language)
	{
		MusicStatus = musicStatus;
		SoundStatus = soundStatus;
		RingName = ringName;
		Language = language;
	}

	public ColorRingsModel()
	{
		MusicStatus = true;
		SoundStatus = true;
		RingName = "CircleRingPrefabe";
		Language = "English";
	}

	public ColorRingsContract SaveData()
	{
		return new ColorRingsContract
		{
			SoundStatus = SoundStatus,
			MusicStatus = MusicStatus,
			RingName = RingName,
			Language = Language
		};
	}

	public void LoadData(ColorRingsContract contract)
	{
		MusicStatus = contract.MusicStatus;
		SoundStatus = contract.SoundStatus;
		RingName = contract.RingName;
		Language = contract.Language;
	}
}
