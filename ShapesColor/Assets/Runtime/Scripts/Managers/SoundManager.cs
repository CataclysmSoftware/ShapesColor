using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : AFMonoBehaviour
{
	public AudioSource ButtonSound { get; set; }
	public AudioSource MusicSound { get; set; }
	public AudioSource RingSound { get; set; }
	public AudioSource EffectSound { get; set; }

	private ColorRingsGameManager colorRingsGameManager;

	private void Awake()
	{
		ButtonSound = transform.Find("ButtonSound").GetComponent<AudioSource>();
		MusicSound = transform.Find("MusicSound").GetComponent<AudioSource>();
		RingSound = transform.Find("RingSound").GetComponent<AudioSource>();
		EffectSound = transform.Find("EffectSound").GetComponent<AudioSource>();
	}

	private void Start()
	{
		colorRingsGameManager = FindObjectOfType<ColorRingsGameManager>();
		PlayMusicAudio();
	}

	public void PlayButtonAudio()
	{
		if (colorRingsGameManager.ColorRingsModel.SoundStatus)
		{
			ButtonSound.Play();
		}
	}

	public void PlayMusicAudio()
	{
		if (colorRingsGameManager.ColorRingsModel.MusicStatus)
		{
			MusicSound.Play();
		}
	}

	public void PlayRingAudio()
	{
		if (colorRingsGameManager.ColorRingsModel.SoundStatus)
		{
			RingSound.Play();
		}
	}

	public void PlayEffectAudio()
	{
		if (colorRingsGameManager.ColorRingsModel.SoundStatus)
		{
			EffectSound.Play();
		}
	}
}
