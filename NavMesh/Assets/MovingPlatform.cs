using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	public Transform MovePosition;
	private Vector3 StartPosition;
	private bool reverse = false;

	private float timeElapsed = 0;
	public float MoveTime = 10f;
	public float threshold = 0.01f;
	
	void Start()
	{
		StartPosition = transform.position;
	}

	void Update()
	{
		float t = timeElapsed / MoveTime;
		t = t * t * (3f - 2f * t);

		if (!reverse)
		{
			transform.position = Vector3.Lerp(StartPosition, MovePosition.position, t);
			timeElapsed += Time.deltaTime;

			if (Vector3.Distance(transform.position, MovePosition.position) < threshold)
			{
				transform.position = MovePosition.position;
				reverse = true;
				timeElapsed = 0f;
			}
		}
		else
		{
			transform.position = Vector3.Lerp(MovePosition.position, StartPosition, t);
			timeElapsed += Time.deltaTime;

			if (Vector3.Distance(transform.position, StartPosition) < threshold)
			{
				transform.position = StartPosition;
				reverse = false;
				timeElapsed = 0f;
			}
		}
	}
}
