using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void LoadTitleScreen() {
        SceneManager.LoadScene(0);
    }

    public void LoadRulesScreen() {
        SceneManager.LoadScene(1);
    }

    public void LoadGameScreen() {
        SceneManager.LoadScene(2);
    }

    public void LoadGameOverScreen() {
        SceneManager.LoadScene(3);
    }

    public void LoadInfoScreen() {
        SceneManager.LoadScene(4);
    }

    public void LoadMenuScreen() {
        SceneManager.LoadScene(5);
    }

}
