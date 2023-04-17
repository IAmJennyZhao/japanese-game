using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ゲームエンドスクリーン ゲームエンドスクリーン;
    string food = "カツ丼";
    int totalPoints = 0;

    public void GameOver() {
        ゲームエンドスクリーン.Setup(food, totalPoints);
    }

    private void Awake() {}
    void Start() {}

    public void TouchedPlatform(string name) {}
}
