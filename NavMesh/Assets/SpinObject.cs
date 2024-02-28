using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpinObject : MonoBehaviour
{
	public float spinSpeed = 0.1f;
	public Transform axis;

	//private List<NavMeshAgent> AgentsOnPlatform = new List<NavMeshAgent>();

	void FixedUpdate()
	{
		transform.Rotate(axis.up, spinSpeed * Time.deltaTime);

		/*for (int i = 0; i < AgentsOnPlatform.Count; i++)
		{
			Vector3 rotatedDestination = Quaternion.Euler(0, spinSpeed, 0)
				* (AgentsOnPlatform[i].destination - transform.position)
				+ transform.position;

			//AgentsOnPlatform[i].destination = rotatedDestination + (platformMoveDirection * MoveSpeed);
			// for always aligned agents to platforms, you can use this but it will not allow the Agent to move while the platform is moving
			//Vector3 rotatedPosition = Quaternion.Euler(0, RotationPerFrame, 0)
			//    * (AgentsOnPlatform[i].transform.position - transform.position)
			//    + transform.position;

			//AgentsOnPlatform[i].transform.rotation = Quaternion.Euler(
			//    AgentsOnPlatform[i].transform.rotation.eulerAngles.x,
			//    AgentsOnPlatform[i].transform.rotation.eulerAngles.y + RotationPerFrame,
			//    AgentsOnPlatform[i].transform.rotation.eulerAngles.z
			//);

			//AgentsOnPlatform[i].Warp(rotatedPosition + platformMoveDirection * MoveSpeed);
		}*/
	}

	/*private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
		{
			AgentsOnPlatform.Add(agent);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
		{
			AgentsOnPlatform.Remove(agent);
		}
	}*/
}