using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class インフォ : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        int level = PlayerData.currentLevel;
        string levelName = PlayerData.foodInfo[level].levelName;

        Sprite infoPage = Resources.Load<Sprite>("info/"+levelName+"インフォ");
        Debug.Log("info/"+levelName);
        image.sprite = infoPage;
    }

}
