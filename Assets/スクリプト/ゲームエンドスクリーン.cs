using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ゲームエンドスクリーン : MonoBehaviour
{
    public Text scoreText;
    public Text recipe;

    public void Setup(string food, int score){
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS";
        recipe.text = food;
    }
}
