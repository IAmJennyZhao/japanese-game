using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public Text moneyText;
    public Animator transition;
    private float transitionTime = 1.0f;

    private void Start() {
        updateMoneyText();
        Debug.Log("Started screen manager");
    }

    public void updateMoneyText() {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "メニュースクリーン" || currentScene == "ゲームエンドスクリーン") {
            Debug.Log("Updating money count");
            moneyText.text = PlayerData.coinTotal+"";
            Debug.Log(PlayerData.coinTotal+" coins");
        }
    }

    public void LoadTitleScreen() {
        // SceneManager.LoadScene(0);
        StartCoroutine(LoadLevel(0));
    }

    public void LoadRulesScreen() {
        // SceneManager.LoadScene(1);
        StartCoroutine(LoadLevel(1));
    }

    public void LoadGameScreen() {
        updateMoneyText();
        if (PlayerData.unlocked[PlayerData.currentLevel] && !PlayerData.justUnlocked){
            SceneManager.LoadScene(2);
            Debug.Log("Loading game");
        }
        else 
            Debug.Log("Cannot load game");
    }

    public void LoadGameOverScreen() {
        if (PlayerData.score >-1) {
            SceneManager.LoadScene(3);
        }
    }

    public void LoadInfoScreen() {
        SceneManager.LoadScene(4);
    }

    public void LoadMenuScreen() {
        // SceneManager.LoadScene(5);
        StartCoroutine(LoadLevel(5));
    }

    IEnumerator LoadLevel(int buildIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(buildIndex);
    }
}
