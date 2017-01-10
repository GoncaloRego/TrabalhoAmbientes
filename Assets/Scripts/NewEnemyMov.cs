using UnityEngine;
using System.Collections;

public class NewEnemyMov : MonoBehaviour {


    Transform player;               // Reference to the player's position.
    
    NavMeshAgent nav;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
    }
}
