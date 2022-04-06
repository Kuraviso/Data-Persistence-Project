using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuHandler : MonoBehaviour
{

    public TMP_InputField playerInput;
    public TMP_Text highscoreText;

    private void Start()
    {
        highscoreText.text = $"High Score: {GameMainManager.instance.playerName} {GameMainManager.instance.score}";

    }


    public void StartGame()
    {

        SceneManager.LoadScene(1);
        GameMainManager.instance.gameName = playerInput.text;

    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();

#else
        Application.Quit();
#endif

    }
}
