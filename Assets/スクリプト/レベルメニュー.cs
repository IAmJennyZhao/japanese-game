using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class レベルメニュー : MonoBehaviour
{
    public int level;
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = PlayerData.foodInfo[level].levelName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
