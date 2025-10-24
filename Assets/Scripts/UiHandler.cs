using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class UiHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text BestScore;
    void Start()
    {
        SaveManager.Instance.LoadGameData();
        inputField.onEndEdit.AddListener(OnEndInputEdit);
        inputField.text = SaveManager.Instance.Name;
        BestScore.text =  "Best Score : " +  SaveManager.Instance.HighScoreName + " : " +  SaveManager.Instance.HighScore;

    }

    public void StartGame()
    {
        SaveManager.Instance.SaveGameData();
        SceneManager.LoadScene(1);
    }

    public void OnEndInputEdit(string newName)
    {
        SaveManager.Instance.Name = newName;
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
