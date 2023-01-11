using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public float playerSpeed;
    public float gravityForce;
    private CharacterController controller;
    public float speed = 10f;
    public Rigidbody rb;
    public float Yvelocity = 0f;


    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Move();


    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");

        Vector3 movement = Vector3.zero;

        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)//movement with "a,w,s,d" key on "y" and "x"
        {
            movement = transform.forward * z + transform.up * -gravityForce + transform.right * x;
            movement *= playerSpeed;
            movement.y /= playerSpeed;
            //anim.Play("Idle");
            //Debug.Log(" x " + x + " z " + z);
        }
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Yvelocity = 0;
            Yvelocity += 10f;
        }
        Yvelocity -= gravityForce * Time.deltaTime;
        movement.y = Yvelocity;
        movement *= Time.deltaTime;
        controller.Move(movement);
    }
}
