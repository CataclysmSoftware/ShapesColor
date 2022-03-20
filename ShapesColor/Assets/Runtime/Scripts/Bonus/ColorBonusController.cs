using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBonusController : BonusEffect
{
	public override void OnClickApplyBonus()
	{
		SoundManager.PlayEffectAudio();
		foreach (var a in RingsManager.Rings)
		{
			a.Renderer.material.color = Constants.MAGENTA;
		}
		Destroy(gameObject);
	}
}
