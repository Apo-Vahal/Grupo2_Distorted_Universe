using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    //If the player's collider collides with the object's collider, the scene will swap to the menu(in this case)
    public string levelchange;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController detectedPlayer = other.GetComponent<PlayerController>();
        if (detectedPlayer != null)
        {
            SceneManager.LoadScene("Tavern");
        }
    }
}
