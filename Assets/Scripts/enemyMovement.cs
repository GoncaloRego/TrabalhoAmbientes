using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour
{
    PlayerMovement player;
    Animator animation;
    private Transform enemyTransform;
    private Transform target;
    private Rigidbody enemyRigidbody;
    public float speed;
    public float rotationSpeed;
    float distance;
    public float minDistance;
    public float maxDistance;
    bool isMoving;
    bool isRunning;
	void Start ()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyTransform = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        animation = GetComponent<Animator>();

        isMoving = false;
        isRunning = false;
	}

    void EnemyMove()
    {
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, Quaternion.LookRotation(target.position - enemyTransform.position),
            rotationSpeed * Time.deltaTime);

        enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;

        /*transform.LookAt(player.playerTransform);
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
        }*/
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

        if(isRunning == true)
        {
            animation.SetBool("correr", true);
        }

        else
        {
            animation.SetBool("correr", false);
        }
    }

	void Update ()
    {
        EnemyMove();
        AnimationControl();
	}
}
