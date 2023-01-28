using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "FullGame", fileName = "game")]
public class SaveFullGame : ScriptableObject
{
    public const string key = "SaveFullGame";

    public int CountAttempt;

    //���������� ����
    public void Save()
    {
        string json = JsonUtility.ToJson(this);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    //�������� ����
    public void Load()
    {
        if (PlayerPrefs.HasKey(key))
        {
            string json = PlayerPrefs.GetString(key);
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
