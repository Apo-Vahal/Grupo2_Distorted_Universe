using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPos : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.SendMessage("Load");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
