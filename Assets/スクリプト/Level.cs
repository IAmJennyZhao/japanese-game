using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int levelNumber;
    public string levelName;
    public string levelDescription;
    public string imageFilePath;

    public float cookingLength; // value between 0 and 1 preferrably between 0.3 and 0.7
    // public int coinCost;
    // public int coinReward;

    public Level(int levelNumber_input, string levelName_input, float cookingLength_input, string levelDescription_input = "", string imageFilePath_input = "") {
        levelNumber = levelNumber_input;
        levelName = levelName_input;
        levelDescription = levelDescription_input;
        imageFilePath = imageFilePath_input;
        cookingLength = cookingLength_input;
    }
}
