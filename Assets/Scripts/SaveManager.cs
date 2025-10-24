using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public string Name;

    public string HighScoreName;
    public int HighScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int HighScore;

        public string HighScoreName;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.HighScore = HighScore;
        data.HighScoreName = HighScoreName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Name = data.Name;
            HighScore = data.HighScore;
            HighScoreName = data.HighScoreName;
        }
    }
}
