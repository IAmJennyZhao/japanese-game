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
    public int coinCost;
    public int coinReward;
    public int unlockCost;
// 0	5	0
// 2	8	10
// 3	10	20
// 6	15	30
// 10	20	40
// 15	30	70
// 18	40	100
// 20	50	150
// 30	70	280
// 40	85	350
// 50	100	425
// 60	120	500
// 65	140	750
// 70	180	1000

    private int[] coinCosts = {0, 2, 3, 6, 10, 15, 18, 20, 30, 40, 50, 60, 65, 70};
    private int[] coinRewards = {5, 10, 15, 20, 30, 40, 50, 70, 85, 100, 120, 140, 180, 250};
    private int[] unlockCosts = {0, 10, 20, 30, 40, 70, 100, 150, 280, 350, 425, 500, 750, 1000};

    public Level(int levelNumber_input, string levelName_input, float cookingLength_input, string levelDescription_input = "") {
        levelNumber = levelNumber_input;
        levelName = levelName_input;
        levelDescription = levelDescription_input;
        imageFilePath = levelName;
        cookingLength = cookingLength_input;

        coinCost = coinCosts[levelNumber];
        coinReward = coinRewards[levelNumber];
        unlockCost = unlockCosts[levelNumber];
    }
}
