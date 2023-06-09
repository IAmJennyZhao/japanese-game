using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ゲームエンドスクリーン : MonoBehaviour
{
    public Text scoreText;
    public Text recipe;
    public GameObject[] stars;

    // private int currentScore = 0;
    // private int endScore = 0;

    public void Awake() {
        RectTransform rt = GetComponent<RectTransform>();
        float canvasHeight = rt.rect.height;
        float desiredCanvasWidth = canvasHeight * Camera.main.aspect;
        float canvasWidth = rt.rect.width;
        float desiredCanvasHeight = canvasWidth / Camera.main.aspect;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
        // rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, desiredCanvasHeight);
    }

    public void Start(){
        gameObject.SetActive(true);
        // PlayerData.score = 30; // delete later
        // PlayerData.foodInfo = new Dictionary<int, Level>();
        // PlayerData.foodInfo[PlayerData.currentLevel] = new Level(0, "カツ丼", .6f);
        // PlayerData.foodInfo[PlayerData.currentLevel].levelName = "カツ丼"; // delete later
        // scoreText.text = PlayerData.score.ToString() + " POINT";
        // if (PlayerData.score != 0) 
        //     scoreText.text += "S";
        Level currentLevel = PlayerData.foodInfo[PlayerData.currentLevel];
        int addedCoins = (PlayerData.score+2) * (currentLevel.coinCost+1);
        scoreText.text = "+" + addedCoins + " Coins"; // todo later: add animation to coin text
        // scoreText.text = "25 POINTS";
        recipe.text = PlayerData.foodInfo[PlayerData.currentLevel].levelName;
        scoreText.SetAllDirty();
        PlayerData.coinTotal += addedCoins;
        if (PlayerData.score + 1 >= 1) {
            stars[0].SetActive(true);
        } if (PlayerData.score + 1 >= 2) {
            stars[1].SetActive(true);
        } if (PlayerData.score + 1 >= 3) {
            stars[2].SetActive(true);
        }
        Debug.Log("Started end screen");
    }

    void Update() {

    }
}
