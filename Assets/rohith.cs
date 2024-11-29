using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string Name;
    public int mainhealth;
    public int secondaryhealth;
}
    

    public class rohith : MonoBehaviour
    {
        public Player Playerdata;

        private void Start()
        {
            Playerdata.Name = "Rohith";
            Playerdata.mainhealth = 100;
            Playerdata.secondaryhealth = 50;
        }
        private void Update()
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
            var savedplayerJSONString = JsonUtility.ToJson(Playerdata);
            File.WriteAllText(Path.Join(Application.persistentDataPath, "gamedata.json"), savedplayerJSONString);
            Debug.Log("saved data");
        }
        public void LoadPlayerdata()
        {
            var path = Path.Join(Application.persistentDataPath, "gamedata.json");
            if (File.Exists(path))
            {
                string savedplayerJSONString = File.ReadAllText(path);
                Playerdata = JsonUtility.FromJson<Player>(savedplayerJSONString);
                Debug.Log("loaded");
            }
            else
            {
                Debug.Log("can't be loaded");
            }
        }
    }



