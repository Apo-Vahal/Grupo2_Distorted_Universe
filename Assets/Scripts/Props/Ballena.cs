using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballena : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
    }
}

