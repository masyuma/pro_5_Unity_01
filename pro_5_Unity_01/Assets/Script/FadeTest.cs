using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class FadeTest : MonoBehaviour{

    public string Attention,Title,Unity_02,End;
    bool isStart = true;

    public void Start()
    {
        SceneFade.FadeIn();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit") || Input.GetMouseButton(0) && SceneManager.GetActiveScene().name == "Attention")
        {
            if (isStart)
            {
                SceneFade.SwitchScene(Title);
                isStart = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //EditorApplication.isPlaying = false;
        }

        if (NameController.textNum1 == 15 || NameController.textNum1 == 19 || NameController.textNum1 == 23)
        {
            if (SceneManager.GetActiveScene().name == "Unity_01")
            {
                SceneFade.SwitchScene(Unity_02);
                NameController.textNum1 = 60;
                TextController2.textNum1 = 60;
            }
        }

        if (NameController.textNum1 == 59)
        {
            if (SceneManager.GetActiveScene().name == "Unity_02")
            {
                SceneFade.SwitchScene(End);
                NameController.textNum1 = 60;
                TextController2.textNum1 = 60;
            }
        }
    }

    public void OnButtonFadeIn()
    {
        SceneFade.FadeIn();
    }

    public void OnButtonFadeOut()
    {
        SceneFade.FadeOut();
    }

    public void OnButtonSwitchScene(string sceneName)
    {
        SceneFade.SwitchScene(sceneName);
    }

    public void OnButtonAppQuit()
    {
        Application.Quit();
        //EditorApplication.isPlaying = false;
    }
}
