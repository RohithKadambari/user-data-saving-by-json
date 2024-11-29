using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class Players
{
    public List<string> Names;
    public List<string> unlocklocations;
    public float currency;
    public List<string> otherplayers;
}

public class others : MonoBehaviour
{
    public Players Playersdata;
    private string savedplayersJSONString;

    // Start is called before the first frame update
    private void Start()
    {
        savedplayersJSONString = Path.Combine(Application.persistentDataPath,"playerdata.json");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveplayerdata();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerdata();
        }
    }
    public void saveplayerdata()
    {
        var savedplayersJSONString = JsonUtility.ToJson(Playersdata);
        File.WriteAllText(Path.Join(Application.persistentDataPath, "playerdata.json"), savedplayersJSONString);
        Debug.Log("saved data");
    }
    public void LoadPlayerdata()
    {
        var path = Path.Join(Application.persistentDataPath, "playerdata.json");
        if (File.Exists(path))
        {
            string savedplayersJSONString = File.ReadAllText(path);
            Playersdata = JsonUtility.FromJson<Players>(savedplayersJSONString);
            Debug.Log("loaded");
        }
        else
        {
            Debug.Log("can't be loaded");
        }
    }
}

