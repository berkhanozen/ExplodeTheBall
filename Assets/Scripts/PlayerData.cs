using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int HighScore { get; private set; }
    public int Score { get; private set; }

    public PlayerData(int hiScore, int score)
    {
        this.HighScore = hiScore;
        this.Score = score;
    }

    public class SaveLoadManager
    {
        public static void Save(PlayerData data, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, data);
            fs.Close();
        }

        public static PlayerData Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();
            PlayerData pd = (PlayerData)bf.Deserialize(fs);
            fs.Close();
            return pd;
        }
    }
}
