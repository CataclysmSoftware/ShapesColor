using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
	public Renderer Renderer { get; set; }

	private void Awake()
	{
		Renderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		transform.localScale = new Vector3(transform.localScale.x - Constants.SPEED * Time.deltaTime, transform.localScale.y - Constants.SPEED * Time.deltaTime, transform.localScale.z - Constants.SPEED * Time.deltaTime);
	}
}
