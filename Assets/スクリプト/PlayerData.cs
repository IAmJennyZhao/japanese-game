using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static bool[] unlocked {get; set; } = {true, false, false, false, false,
                                                false,  false, false, false, false,
                                                false,  false, false };
    public static int currentLevel { get; set; }
    public static int score { get; set; }

    public static Dictionary<int, Level> foodInfo { get; set; } = new Dictionary<int, Level>(){
        {0, new Level(0, "味噌汁",      0.5f)},
        {1, new Level(1, "餃子",        0.7f)},
        {2, new Level(2, "団子",        0.36f)},
        {3, new Level(3, "親子丼",      0.65f)},
        {4, new Level(4, "桜お茶",      0.3f)},
        {5, new Level(5, "ラーメン",    0.56f)},
        {6, new Level(6, "カレーライス", 0.44f)},
        {7, new Level(7, "お好み焼き",  0.66f)},
        {8, new Level(8, "寿司",        0.33f)},
        {9, new Level(9, "カツ丼",      0.55f)},
        {10, new Level(10, "オムライス",  0.75f)},
        {11, new Level(11, "すき焼き",    0.45f)},
        {12, new Level(12, "ハンバーガステーキ",  0.63f)},
    };

    public static int coinTotal {get; set; } = 16000;
    public static bool justUnlocked {get; set; } = false; 
}
