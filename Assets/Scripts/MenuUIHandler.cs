using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI tmpPlayerName;

    public void Start()
    {
        bestScoreText.text = "Best Score\n" + PersistenceManager.Instance.bestPlayer + " : " + PersistenceManager.Instance.bestScore;
    }

    public void OnNameEntered()
    {
        PersistenceManager.Instance.playerName = tmpPlayerName.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }
}
