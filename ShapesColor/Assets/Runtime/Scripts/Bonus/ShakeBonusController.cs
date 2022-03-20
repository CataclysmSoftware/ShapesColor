using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBonusController : BonusEffect
{
	private Camera mainCamera;
	private float shakeDuration = 0.6f;
	private float shakeAmount = 1f;
	private float decreaseFactor = 1f;
	private bool start;
	private Vector3 startPosition;

	private void Awake()
	{
		base.Awake();
		mainCamera = Camera.main;
		startPosition = mainCamera.transform.localPosition;
	}

	public override void OnClickApplyBonus()
	{
		SoundManager?.PlayEffectAudio();
		start = true;
	}

	private void Update()
	{
		if (shakeDuration > 0 && start)
		{
			var x = Random.Range(-1f, 1f) * shakeAmount;
			var y = Random.Range(-1f, 1f) * shakeAmount;
			mainCamera.transform.localPosition = new Vector3(x, y, mainCamera.transform.localPosition.z);
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}

		if (shakeDuration <= 0)
		{
			mainCamera.transform.localPosition = startPosition;
			Destroy(gameObject);
		}
	}
}
