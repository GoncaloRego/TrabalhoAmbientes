using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    public Transform playerTransform;
    private Transform target;
    Animator animation;
    public float jumpSpeed;
    public float speed;
    public float gravity;
    public float rotationSpeed;
    public float runSpeed;
    public float distance;
    bool isMoving;
    bool isRunning;
    bool isAttacking;
    Vector3 rotate;


    void Start ()
    {
        animation = GetComponent<Animator>();

        playerRigidBody = GetComponent<Rigidbody>();
        playerTransform = transform;

        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        distance = Vector3.Distance(playerTransform.position, target.position);

        isMoving = false;
        isRunning = false;
        isAttacking = false;

        rotate = Vector3.zero;
	}
	
    void MovePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * speed * Time.deltaTime);
            isMoving = true;
        }

        if(Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * speed * Time.deltaTime);
            isMoving = true;
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            isRunning = true;
        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            isRunning = false;
            isAttacking = true;
        }
    }

    void Run()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            isRunning = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerTransform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            isRunning = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    void animationControl()
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

        if(isRunning == true)
        {
            animation.Play("Run");
        }

        else
        {
            animation.SetBool("correr", false);
        }

        if(isAttacking == true)
        {
            animation.SetBool("atacar", true);
            isAttacking = false;
        }

        else
        {
            animation.SetBool("atacar", false);
        }
    }

	void Update ()
    {
        MovePlayer();
        animationControl();
	}
}
