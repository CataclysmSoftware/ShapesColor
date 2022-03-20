using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	private bool isPressed = false;
	private Vector2 start = Vector2.zero;
	private Vector2 final = Vector2.zero;


	private bool isPressedDouble = false;
	private Vector2 startDouble1 = Vector2.zero;
	private Vector2 finalDouble1 = Vector2.zero;

	private Vector2 startDouble2 = Vector2.zero;
	private Vector2 finalDouble2 = Vector2.zero;

	private bool isPressedTriple = false;
	private Vector2 startTriple1 = Vector2.zero;
	private Vector2 finalTriple1 = Vector2.zero;

	private Vector2 startTriple2 = Vector2.zero;
	private Vector2 finalTriple2 = Vector2.zero;

	private Vector2 startTriple3 = Vector2.zero;
	private Vector2 finalTriple3 = Vector2.zero;



	private void Update()
	{
		//SingleSwipe();
		//DoubleSwipe();
		TripleSwipe();
	}

	private void SingleSwipe()
	{

		if (Input.GetMouseButtonDown(0) && !isPressed)
		{
			start = Input.GetTouch(0).position;
			isPressed = true;
		}
		if (isPressed)
		{
			final = Input.GetTouch(0).position;
		}
		if (Input.GetMouseButtonUp(0))
		{
			isPressed = false;
			final = new Vector2(final.x / Screen.width, final.y / Screen.height);
			start = new Vector2(start.x / Screen.width, start.y / Screen.height);
			Debug.Log("Final: " + final);
			Debug.Log("Start: " + start);
			if ((int)(final.x * 10) == (int)(start.x * 10) && (int)(final.y * 10) == (int)(start.y * 10))
			{
				Debug.Log("Tap Touch 1");
			}
			else
			{
				var distance = (final.x - start.x) * (final.x - start.x) + (final.y - start.y) * (final.y - start.y);
				Debug.Log("Distance: " + distance + " for Touch 1");
			}
		}
	}

	private void DoubleSwipe()
	{
		if (Input.touchCount == 2 && Input.GetMouseButtonDown(1) && !isPressedDouble)
		{
			startDouble1 = Input.GetTouch(0).position;
			startDouble2 = Input.GetTouch(1).position;
			isPressedDouble = true;
		}

		if (isPressedDouble)
		{
			finalDouble1 = Input.GetTouch(0).position;
			finalDouble2 = Input.GetTouch(1).position;
		}

		if (Input.GetMouseButtonUp(1))
		{
			isPressedDouble = false;
			finalDouble1 = new Vector2(finalDouble1.x / Screen.width, finalDouble1.y / Screen.height);
			finalDouble2 = new Vector2(finalDouble2.x / Screen.width, finalDouble2.y / Screen.height);

			startDouble1 = new Vector2(startDouble1.x / Screen.width, startDouble1.y / Screen.height);
			startDouble2 = new Vector2(startDouble2.x / Screen.width, startDouble2.y / Screen.height);

			var middleStartX = (startDouble1.x + startDouble2.x) / 2;
			var middleStartY = (startDouble1.y + startDouble2.y) / 2;

			var middleFinalX = (finalDouble1.x + finalDouble2.x) / 2;
			var middleFinalY = (finalDouble1.y + finalDouble2.y) / 2;

			Debug.Log("MiddleStart: " + middleStartX + "----" + middleStartY);
			Debug.Log("MiddleFinal: " + middleFinalX + "----" + middleFinalY);


			if ((int)(middleFinalX * 10) == (int)(middleStartX * 10) && (int)(middleFinalY * 10) == (int)(middleStartY * 10))
			{
				Debug.Log("Tap Touch 2");
			}
			else
			{
				var distance = (middleFinalX - middleStartX) * (middleFinalX - middleStartX) + (middleFinalY - middleStartY) * (middleFinalY - middleStartY);
				Debug.Log("Distance: " + distance + " for Touch 2");
			}

		}
	}

	private void TripleSwipe()
	{
		if (Input.touchCount == 3 && Input.GetMouseButtonDown(2) && !isPressedTriple)
		{
			startTriple1 = Input.GetTouch(0).position;
			startTriple2 = Input.GetTouch(1).position;
			startTriple3 = Input.GetTouch(2).position;
			isPressedTriple = true;
		}
		if (isPressedTriple)
		{
			finalTriple1 = Input.GetTouch(0).position;
			finalTriple2 = Input.GetTouch(1).position;
			finalTriple3 = Input.GetTouch(2).position;
		}
		if (Input.GetMouseButtonUp(2))
		{
			isPressedTriple = false;
			finalTriple1 = new Vector2(finalTriple1.x / Screen.width, finalTriple1.y / Screen.height);
			finalTriple2 = new Vector2(finalTriple2.x / Screen.width, finalTriple2.y / Screen.height);
			finalTriple3 = new Vector2(finalTriple3.x / Screen.width, finalTriple3.y / Screen.height);

			startTriple1 = new Vector2(startTriple1.x / Screen.width, startTriple1.y / Screen.height);
			startTriple2 = new Vector2(startTriple2.x / Screen.width, startTriple2.y / Screen.height);
			startTriple3 = new Vector2(startTriple3.x / Screen.width, startTriple3.y / Screen.height);

			var middleStartTripleX = (startTriple1.x + startTriple2.x + startTriple3.x) / 2;
			var middleStartTripleY = (startTriple1.y + startTriple2.y + startTriple3.y) / 2;

			var middleFinalTripleX = (finalTriple1.x + finalTriple2.x + finalTriple3.x) / 2;
			var middleFinalTripleY = (finalTriple1.y + finalTriple2.y + finalTriple3.y) / 2;

			Debug.Log("MiddleStart: " + middleStartTripleX + "----" + middleStartTripleY);
			Debug.Log("MiddleFinal: " + middleFinalTripleX + "----" + middleFinalTripleY);

			if ((int)(middleFinalTripleX * 10) == (int)(middleStartTripleX * 10) && (int)(middleFinalTripleY * 10) == (int)(middleStartTripleY * 10))
			{
				Debug.Log("Tap Touch 3");
			}
			else
			{
				var distance = (middleFinalTripleX - middleStartTripleX) * (middleFinalTripleX - middleStartTripleX) + (middleFinalTripleY - middleStartTripleY) * (middleFinalTripleY - middleStartTripleY);
				Debug.Log("Distance: " + distance + " for Touch 3");
			}
		}
	}
}
