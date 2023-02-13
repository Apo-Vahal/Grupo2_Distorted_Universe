using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject map;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.gameObject.activeInHierarchy);
        }
    }
}

