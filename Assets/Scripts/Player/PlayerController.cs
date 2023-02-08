using System.Collections;
using System.Collections.Generic;
using System.IO;
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


       // StreamReader sr = new StreamReader(Application.persistentDataPath + "Archivo.txt");


        //float x = float.Parse(sr.ReadLine());
        //float y = float.Parse(sr.ReadLine());
       // float z = float.Parse(sr.ReadLine());
       // transform.position = new Vector3(x, y, z);
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

        float auxSpeed = playerSpeed;
        if (Input.GetButton("Run"))
        {
            auxSpeed = playerSpeed * 1.7f;
        }

        if (Input.GetButton("Crouch"))
        {
            auxSpeed = playerSpeed * 0.5f;
        }

        if (Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0)//movement with "a,w,s,d" key on "y" and "x"
        {

            movement = transform.forward * z + transform.up * -gravityForce + transform.right * x;
            movement *= auxSpeed;
            movement.y /= auxSpeed;
        }
        Vector3 auxMov = movement;
        auxMov.y = 0;
        GetComponent<Animator>().SetFloat("Speed", auxMov.magnitude / (playerSpeed * 1.7f), 0.05f, Time.deltaTime);


        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            Yvelocity = 0;
            Yvelocity += 10f;
            GetComponent<Animator>().Play("Jump");
        }
        Yvelocity -= gravityForce * Time.deltaTime;
        movement.y = Yvelocity;
        movement *= Time.deltaTime;
        controller.Move(movement);
    }

    //private void OnDisable()
    //{
      //  FileStream fs = File.Create(Application.persistentDataPath + "Archivo.txt");

      //  StreamWriter sw = new StreamWriter(fs);

      //  sw.WriteLine(transform.position.x);
      //  sw.WriteLine(transform.position.y);
       // sw.WriteLine(transform.position.z);

       // sw.Close();
      //  fs.Close();
    //}
}
