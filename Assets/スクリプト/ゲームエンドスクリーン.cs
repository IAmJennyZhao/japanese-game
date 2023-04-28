using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ゲームエンドスクリーン : MonoBehaviour
{
    public Text scoreText;
    public Text recipe;

    public void Start(){
        gameObject.SetActive(true);
        // PlayerData.score = 30; // delete later
        // PlayerData.foodInfo = new Dictionary<int, Level>();
        // PlayerData.foodInfo[PlayerData.currentLevel] = new Level(0, "カツ丼", .6f);
        // PlayerData.foodInfo[PlayerData.currentLevel].levelName = "カツ丼"; // delete later
        scoreText.text = PlayerData.score.ToString() + " POINT";
        if (PlayerData.score != 0) 
            scoreText.text += "S";
        // scoreText.text = "25 POINTS";
        recipe.text = PlayerData.foodInfo[PlayerData.currentLevel].levelName;
        scoreText.SetAllDirty();
    }
}
