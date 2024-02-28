using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavCharacter : MonoBehaviour
{
	public GameObject Floor;
	public GameObject[] goals;

	private GameObject currentGoal = null;
	private NavMeshAgent agent;

	private float originalSpeed;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		originalSpeed = agent.speed;
		PickRandomTarget();
	}

	// Update is called once per frame
	void Update()
	{
		agent.destination = currentGoal.transform.position;
		
		if (Vector3.Distance(Floor.transform.position, currentGoal.transform.position) < 0.2f)
		{
			PickRandomTarget();
		}

		/*if (!agent.hasPath)
		{
			Debug.LogWarning("No Path, " + currentGoal.name);
			PickRandomTarget();
		}*/
	}

	void FixedUpdate()
	{
		if (agent.isOnOffMeshLink)
		{
			if (agent.currentOffMeshLinkData.offMeshLink && agent.currentOffMeshLinkData.offMeshLink.tag == "PortalLink" && Vector3.Distance(Floor.transform.position, agent.currentOffMeshLinkData.startPos) < 0.2f)
			{
				agent.Warp(agent.currentOffMeshLinkData.endPos);
			}
			else agent.speed = originalSpeed * 0.4f;
		}
		else agent.speed = originalSpeed;
	}

	public void PickRandomTarget()
	{
		List<GameObject> newGoals = goals.ToList();
		if (currentGoal) newGoals.Remove(currentGoal);
		currentGoal = newGoals[Random.Range(0,newGoals.Count)];
		Debug.Log("PickRandomTarget, " + currentGoal.name);
	}
}
