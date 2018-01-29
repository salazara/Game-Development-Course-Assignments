using UnityEngine;
using System.Collections;

public class EnemyAPath : MonoBehaviour {

	Transform target;
	NavMeshAgent agent;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}
}
