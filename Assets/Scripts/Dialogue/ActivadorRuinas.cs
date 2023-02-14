using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorRuinas : MonoBehaviour
{
    public Dialogue gnomo;
    public GameObject portalRuinas;
    public void Update()
    {
        if (gnomo.converIndex == gnomo.dialogueLines.Length - 1)
        {
            portalRuinas.SetActive(true);
        }
    }
}
