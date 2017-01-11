using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewEnemyMov : MonoBehaviour {


    Transform player;               // Reference to the player's position.
    public Text lostText;
    NavMeshAgent nav;

    public AudioSource sound;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();

        lostText.text = "";
    }
	
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sound.Play();
            lostText.text = "Game Over!";
            Time.timeScale = 0;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        nav.SetDestination(player.position);
    }
}
