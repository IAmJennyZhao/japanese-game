using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    public static bool[] unlocked {get; set; }
    public static int currentLevel { get; set; }
    public static int score { get; set; }

    public static Dictionary<int, Level> foodInfo { get; set; } = new Dictionary<int, Level>(){
        {0, new Level(0, "味噌汁", 0.5f)}
    };

    // public static int coinTotal {get; set; }
}
