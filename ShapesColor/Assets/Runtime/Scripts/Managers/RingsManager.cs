using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingsManager : MonoBehaviour
{
	private const float SPEED_MULTIPLAIER = 8f;

	public Queue<RingController> Rings { get; set; } = new Queue<RingController>();
	public ColorRingsGameManager ColorRingsGameManager { get; set; }
	public bool WatchRwardAdOneTime;

	private Dictionary<int, Color> colors = new Dictionary<int, Color>();
	private SphereController sphereController;
	private int previousColor = 0;
	private Transform brokenHeartPrefabe;
	private Transform smokePrefabe;
	private Transform brokenHeartPrefabeGO;
	private Transform smokePrefabeGO;
	private UIGameplayScreenController gameplayScreenController;
	private SoundManager soundManager;

	private void Awake()
	{
		AddColors();
		sphereController = FindObjectOfType<SphereController>();
		ColorRingsGameManager = FindObjectOfType<ColorRingsGameManager>();
		brokenHeartPrefabe = Resources.Load<Transform>("Prefabes/Effects/BrokenHeart");
		smokePrefabe = Resources.Load<Transform>("Prefabes/Effects/MagicPoof");
		gameplayScreenController = FindObjectOfType<UIGameplayScreenController>();
		soundManager = FindObjectOfType<SoundManager>();
	}

	/// <summary>
	/// This function is called when player play the game or the game start again.
	/// </summary>
	/// <param name="scale">The value for  the scale.</param>
	private void InstantiateRing(int scale)
	{
		var ringName = ColorRingsGameManager.ColorRingsModel.RingName;
		var ringPrefab = Resources.Load<RingController>("Prefabes/Objects/" + ringName);
		var ringGO = Instantiate(ringPrefab, Vector3.zero, Quaternion.identity);
		ringGO.transform.localScale = new Vector3(ringGO.transform.localScale.x * scale, ringGO.transform.localScale.y * scale, ringGO.transform.localScale.z * scale);
		ringGO.transform.SetParent(transform);
		Rings.Enqueue(ringGO);
		var random = Random.Range(0, 6);
		if (random == previousColor)
		{
			random = (random + 1) % 6;
		}
		previousColor = random;
		ringGO.Renderer.material.SetColor("_Color", colors[random]);

	}

	private void Update()
	{
		if (Rings.Count != 0)
		{
			var ringController = Rings.Peek();
			Constants.SPEED += SPEED_MULTIPLAIER * (ringController.transform.localScale.x / 100) * Time.deltaTime;
			if (ringController.transform.localScale.x <= Constants.MIN_SCALE)
			{
				soundManager.PlayRingAudio();
				if (sphereController.Renderer.material.color != ringController.Renderer.material.color)
				{
					if (sphereController.SphereModel.Lives.Value > 1)
					{
						brokenHeartPrefabeGO = Instantiate(brokenHeartPrefabe, Vector3.zero, Quaternion.identity);
					}
					sphereController.SphereModel.Lives.Value -= 1;
					Constants.SPEED -= Constants.SPEED * 0.05f;
				}
				else
				{
					smokePrefabeGO = Instantiate(smokePrefabe, Vector3.zero, Quaternion.identity);
					sphereController.SphereModel.Score.Value += 1;
				}
				Rings.Dequeue();
				Destroy(ringController.gameObject);
				InstantiateRing(10);
			}
		}
	}

	/// <summary>
	/// This function is called when the game is open and put in vector <colors> colors for the rings.
	/// </summary>
	private void AddColors()
	{
		colors[0] = Constants.RED;
		colors[1] = Constants.CYAN;
		colors[2] = Constants.MAGENTA;
		colors[3] = Constants.GREEN;
		colors[4] = Constants.YELLOW;
		colors[5] = Constants.BLUE;
	}

	/// <summary>
	/// This function is called when the game is open or the player want to restart the game.
	/// </summary>
	public void NewGame()
	{
		WatchRwardAdOneTime = true;
		Camera.main.transform.position = Constants.CAMERA_POSITION;
		Time.timeScale = 1;
		DestroryEffects();

		Constants.SPEED = 70f;
		DestroyRings();
		for (int i = 0; i < 5; i++)
		{
			InstantiateRing((i + 1) * 2);
		}
		sphereController.SphereModel.Lives.Value = 3;
		sphereController.SphereModel.Score.Value = 0;

		sphereController.Renderer.material.color = Constants.WHITE;
	}

	public void ContinueGame()
	{
		Camera.main.transform.position = Constants.CAMERA_POSITION;
		Time.timeScale = 1f;
		DestroryEffects();

		DestroyRings();
		for (int i = 0; i < 5; i++)
		{
			InstantiateRing((i + 1) * 2);
		}

		Constants.SPEED = Constants.SPEED - Constants.SPEED * 0.2f;
		sphereController.SphereModel.Lives.Value = 2;
	}

	private void DestroryEffects()
	{
		if (gameplayScreenController.BonusObject != null)
		{
			Destroy(gameplayScreenController.BonusObject.gameObject);
		}

		if (brokenHeartPrefabeGO != null)
		{
			Destroy(brokenHeartPrefabeGO.gameObject);
		}

		if (smokePrefabeGO != null)
		{
			Destroy(smokePrefabeGO.gameObject);
		}
	}

	public void DestroyRings()
	{
		Rings.Clear();
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}
}
