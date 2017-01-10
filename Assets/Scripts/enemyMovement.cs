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
    public bool isMoving;
    public bool isDeath;
	void Start ()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyTransform = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        animation = GetComponent<Animator>();

        isMoving = false;
        isDeath = false;
	}

    void EnemyMove()
    {
        enemyTransform.rotation = Quaternion.Slerp(enemyTransform.rotation, Quaternion.LookRotation(target.position - enemyTransform.position),
            rotationSpeed * Time.deltaTime);

        distance = Vector3.Distance(enemyTransform.position, target.position);

        if (distance > minDistance && isDeath == false)
        {
            enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;
            isMoving = false;
        }

        else
        {
            isMoving = false;
        }
    }

    void AnimationControl()
    {
        if (isDeath == false)
        {
            if (isMoving == true)
            {
                animation.SetBool("andar", true);
                isMoving = false;
            }

            else
            {
                animation.SetBool("andar", false);
            }
        }

        else
        {
            animation.SetBool("morrer", true);
            isMoving = false;
        }
    }

	void Update ()
    {
        EnemyMove();
        AnimationControl();
	}
}
