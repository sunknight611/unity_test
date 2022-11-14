using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{

    public static MainManager instance;
    public Color color;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }
    [System.Serializable]
    class ColorData
    {
        public Color unitColor;
    }

    public void SaveData()
    {
        ColorData data = new ColorData();
        data.unitColor = color;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            ColorData data = JsonUtility.FromJson<ColorData>(json);

            color = data.unitColor;
        }
    }
}
