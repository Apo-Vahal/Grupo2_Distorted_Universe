using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;

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
        // Load();
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

void Save()
    {
        JSONObject playerJson = new JSONObject();
        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);
        playerJson.Add("Position", position);

        string path = Application.persistentDataPath + "/save.json";
        File.WriteAllText(path, playerJson.ToString());
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);
        Debug.Log(playerJson["Position"].AsArray[0]);
        transform.position = new Vector3(
            playerJson["Position"].AsArray[0],
            playerJson["Position"].AsArray[1],
            playerJson["Position"].AsArray[2]
            );
    }

    void OnDisable()
    {
        Save();
    }
}
