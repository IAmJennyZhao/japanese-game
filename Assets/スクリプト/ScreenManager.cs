using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public Text moneyText;

    private void Start() {
        updateMoneyText();
    }

    public void updateMoneyText() {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "メニュースクリーン") {
            Debug.Log("Updating money count");
            moneyText.text = PlayerData.coinTotal+"";
            Debug.Log(PlayerData.coinTotal+" coins");
        }
    }

    public void LoadTitleScreen() {
        SceneManager.LoadScene(0);
    }

    public void LoadRulesScreen() {
        SceneManager.LoadScene(1);
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
        SceneManager.LoadScene(5);
    }

}
