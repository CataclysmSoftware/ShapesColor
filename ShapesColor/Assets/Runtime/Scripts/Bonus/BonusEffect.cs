using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BonusEffect : MonoBehaviour
{
	public Button Button { get; set; }
	public SphereController SphereController { get; set; }
	public RingsManager RingsManager { get; set; }

	protected SoundManager SoundManager;

	protected void Awake()
	{
		SphereController = FindObjectOfType<SphereController>();
		RingsManager = FindObjectOfType<RingsManager>();
		SoundManager = FindObjectOfType<SoundManager>();
	}

	private void Start()
	{
		Button = GetComponent<Button>();
		Button.onClick.AddListener(OnClickApplyBonus);
	}

	public abstract void OnClickApplyBonus();

	private void OnDestroy()
	{
		Button.onClick.RemoveAllListeners();
	}
}
