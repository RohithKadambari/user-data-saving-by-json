using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
public enum inventories
{
    gold,
    items,

}
public enum items
{
    itemName,
    itemtype,
    stats,
    damage,
    effect,
    
}

[System.Serializable]
public class inventory
{
    public inventories items;
}
[System.Serializable]
public class GamePlay
{
    public List<string> PlayerIds;
    public List<string> PlayerNames;
    public List<int> stats;
    public List<inventories> items;
    public List<items> item;

}

public class particle : MonoBehaviour
{
    public GamePlay gamePlay;
    public string savepath;
    
    // Start is called before the first frame update
    void Start()
    {
        savepath = Path.Combine(Application.persistentDataPath, "particledata.json");
    }
    public void Savedplayerdata()
    {
        string alldata_jsonobject = JsonUtility.ToJson(gamePlay);
        Debug.Log(alldata_jsonobject);
        
        File.WriteAllText(savepath,alldata_jsonobject);
        Debug.Log("saved");
    }
    public void LoadPlayerData()
    {
        
        if (File.Exists(savepath))
        { 
            string jsonObject =File.ReadAllText(savepath);
            gamePlay=JsonUtility.FromJson<GamePlay>(jsonObject);
            Debug.Log("LOADED");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            Savedplayerdata();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayerData();
        }
    }
}
