using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private string saveFileName;

    public SaveData loadedSave { get; private set; }
    public static SaveManager Instance;
    private string actualSavePath;
    private void Awake()
    {
        if (Instance is null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        actualSavePath = Application.persistentDataPath + "/" + saveFileName;
    }

    public void LoadGame()
    {
        if (File.Exists(actualSavePath))
        {
            FileStream dataStream = new FileStream(actualSavePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            SaveData saveData = converter.Deserialize(dataStream) as SaveData;
            loadedSave = saveData;
            dataStream.Close();
        }
        else
        {
            Debug.Log("Creating new save file!");
            loadedSave = new SaveData
            {
                MaxReachedLevel = 1
            };
        }
    }
    public void SaveGame()
    {
        FileStream dataStream = new FileStream(Application.persistentDataPath + "/" + saveFileName, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, loadedSave);
        
        dataStream.Close();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
