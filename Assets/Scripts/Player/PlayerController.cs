using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public float jumpSpeed;
    float jump; //jumpSpeed
    public float playerSpeed;
    public float gravityForce;
    private CharacterController controller;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();

    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)//movement with "a,w,s,d" key on "y" and "x"
        {
            Vector3 movement = transform.forward * z + transform.up * -gravityForce + transform.right * x;
            movement *= Time.deltaTime * playerSpeed;
            movement.y /= playerSpeed;
            controller.Move(movement);
            //anim.Play("Idle");
            //Debug.Log(" x " + x + " z " + z);
        }

        else if (Input.GetKey(KeyCode.Space))

        {
            jump = jumpSpeed;
            //anim.Play("Jump");
        }
    }
}
