using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Load();
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
