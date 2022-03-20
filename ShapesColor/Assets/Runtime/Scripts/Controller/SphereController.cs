using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
	public Renderer Renderer { get; set; }
	public SphereModel SphereModel { get; set; }

	private void Awake()
	{
		Renderer = GetComponent<Renderer>();
		SphereModel = PersistenceManager.LoadSphereModelData();
	}

	private void Start()
	{
		SphereModel.Lives.OnChanged += ModifyHighScore;
		SphereModel.Lives.Value = 3;
		SphereModel.Score.Value = 0;
	}

	/// <summary>
	/// This function is called when player died and modify the highScoreList.
	/// </summary>
	/// <param name="value">The value of the life</param>
	private void ModifyHighScore(Observable<int> value)
	{
		SphereModel.HighScores.Sort();
		SphereModel.HighScores.Reverse();
		if (value.Value == 0)
		{
			if (SphereModel.HighScores[9] <= SphereModel.Score.Value)
			{
				SphereModel.HighScores[9] = SphereModel.Score.Value;
			}
		}
		SphereModel.HighScores.Sort();
		SphereModel.HighScores.Reverse();
		PersistenceManager.SaveSphereModelData(SphereModel);
	}

	private void OnDestroy()
	{
		SphereModel.Lives.RemoveListeners();
		SphereModel.Score.RemoveListeners();
		PersistenceManager.SaveSphereModelData(SphereModel);
	}

	private void OnApplicationQuit()
	{
		PersistenceManager.SaveSphereModelData(SphereModel);
	}
}
