using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncreaseBonusController : BonusEffect
{
	public override void OnClickApplyBonus()
	{
		SoundManager.PlayEffectAudio();
		Constants.SPEED = Constants.SPEED + Constants.SPEED * 0.4f;
		Destroy(gameObject);
	}
}
