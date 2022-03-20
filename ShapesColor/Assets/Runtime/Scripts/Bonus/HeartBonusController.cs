using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBonusController : BonusEffect
{
	public override void OnClickApplyBonus()
	{
		SoundManager.PlayEffectAudio();
		if (SphereController.SphereModel.Lives.Value < 3)
		{
			SphereController.SphereModel.Lives.Value += 1;
		}
		Destroy(gameObject);
	}
}
