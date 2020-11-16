using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public class GameDataController : MonoBehaviour
{

    public Action<GameData> gameDataLoaded;
    private GameData data = new GameData(0);
    private string saveFilePath;

    // Start is called before the first frame update
    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/save-file.dat";
        LoadGameData();
    }

    public void SaveHighScore (int score)
    {
        if(data.score < score)
        {
            data.score = score;
            SaveGameData();
        }
    }

    public int GetHighScore()
    {
        return data.score;
    }

    private void LoadGameData()
    {
        if (File.Exists(saveFilePath))
        {
            FileStream fs = File.OpenRead(saveFilePath);
            BinaryFormatter bf = new BinaryFormatter();

            data = (GameData) bf.Deserialize(fs);
            if(gameDataLoaded != null)
            {
                gameDataLoaded(data);
            }

            fs.Close();
        }
    }

    private void SaveGameData()
    {
        FileStream fs = File.Exists(saveFilePath)
            ? File.OpenWrite(saveFilePath)
            : File.Create(saveFilePath);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, data);

        fs.Close();
    }
}