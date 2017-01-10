using UnityEngine;
using System.Collections;

public class EnemySpwan : MonoBehaviour {


    
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    // Use this for initialization
    void Start () {

        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    // Update is called once per frame
    void Spawn() { 

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    

}
}
