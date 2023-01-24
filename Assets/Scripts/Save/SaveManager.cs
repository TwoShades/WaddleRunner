using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get { return instance; } }
    private static SaveManager instance;

    // Fields
    private const string saveFileName = "data.ss";
    public SaveState save;
    private BinaryFormatter formatter;

    // Actions
    public Action<SaveState> OnLoad;
    public Action<SaveState> OnSave;

    private void Awake()
    {
        instance = this;
        formatter = new BinaryFormatter();

        // Try and load the previous save state
        Load();
    }

    public void Load()
    {
        try
        {
            FileStream file = new FileStream(Application.persistentDataPath + saveFileName, FileMode.Open, FileAccess.Read);
            save = formatter.Deserialize(file) as SaveState;
            file.Close();
            OnLoad?.Invoke(save);
        }
        catch
        {
            Debug.Log("Save file not found, let's create a new one.");
            Save();
        }
    }

    public void Save()
    {
        // if there is no previous state found, create a new one!
        if (save == null)
            save = new SaveState();

        // set the time at which we tried saving
        save.LastSaveTime = DateTime.Now;

        // open a file on our system and write to it
        FileStream file = new FileStream(Application.persistentDataPath + saveFileName, FileMode.OpenOrCreate, FileAccess.Write);
        formatter.Serialize(file, save);
        file.Close();

        OnSave?.Invoke(save);
    }
}
