using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour
{
    PlayerMovement player;
    Animator animation;
    private Transform enemyTransform;
    private Rigidbody enemyRigidbody;
    public float speed;
    float distance;
    public float minDistance;
    public float maxDistance;
    bool isMoving;
    bool isRunning;
	void Start ()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyTransform = transform;

        animation = GetComponent<Animator>();

        isMoving = false;
        isRunning = false;
	}

    void EnemyMove()
    {
        transform.LookAt(player.playerTransform);
        distance = Vector3.Distance(transform.position, player.playerTransform.position);

        if (distance >= minDistance)
        {
            isMoving = true;
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if(distance <= maxDistance)
        {
            isMoving = false;
            isRunning = true;
        }
    }

    void AnimationControl()
    {
        if(isMoving == true)
        {
            animation.SetBool("andar", true);
        }

        else
        {
            animation.SetBool("andar", false);
        }
    }

	void Update ()
    {
        EnemyMove();
        AnimationControl();
	}
}
