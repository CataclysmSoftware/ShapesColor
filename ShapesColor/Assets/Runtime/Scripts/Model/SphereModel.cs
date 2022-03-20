using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereModelContract
{
	public List<int> HighScores { get; set; }
}

public class SphereModel : IPersistence<SphereModelContract>
{
	public Observable<int> Lives { get; set; } = new Observable<int>();
	public Observable<int> Score { get; set; } = new Observable<int>();
	public List<int> HighScores { get; set; } = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

	public SphereModel(Observable<int> lives, Observable<int> score, List<int> highScores)
	{
		Lives = lives;
		Score = score;
		HighScores = highScores;
	}

	public SphereModel()
	{
		Lives.Value = 0;
		Score.Value = 0;
		HighScores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	}

	public SphereModel(List<int> highScores)
	{
		Lives.Value = 0;
		Score.Value = 0;
		HighScores = highScores;
	}

	public void LoadData(SphereModelContract contract)
	{
		HighScores = contract.HighScores;
	}

	public SphereModelContract SaveData()
	{
		return new SphereModelContract
		{
			HighScores = HighScores
		};
	}
}
