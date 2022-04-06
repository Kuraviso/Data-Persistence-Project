using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class GameMainManager : MonoBehaviour
{
    public static GameMainManager instance;
    public string gameName;


    public string playerName;
    public int score;

    [System.Serializable]
    public class SaveData
    {

        public string playerName;
        public int score;

    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);

    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            score = data.score;

        }

    }


    private void Awake()
    {
        if (instance != null)
        {

            Destroy(gameObject);
            return;

        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();

    }




}
