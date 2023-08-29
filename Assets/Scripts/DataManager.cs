using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instant;

    public string playerName;
    public string bestplayerName;
    public int bestScore;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instant != null)
        {
            Destroy(gameObject);
            return;
        }
        LoadScoreName();
        
        instant = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestplayerName;
    }

    public void SaveScoreName()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.bestplayerName = bestplayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestplayerName = data.bestplayerName;
        }
    }
}
