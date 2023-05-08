using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class レベルメニュー : MonoBehaviour
{
    public int level;
    public GameObject levelSelect;
    public Text levelText;
    private Transform thisTransform;
    private Image image;
    private bool levelUnlocked;

    private Sprite lockedSprite;
    private Sprite unlockedSprite;

    // Start is called before the first frame update
    void Start()
    {
        levelText = levelSelect.transform.GetChild(0).gameObject.GetComponent<Text>();
        thisTransform = levelSelect.transform;
        image = levelSelect.transform.GetChild(1).gameObject.GetComponent<Image>();

        unlockedSprite = Resources.Load<Sprite>(PlayerData.foodInfo[level].imageFilePath);
        lockedSprite = Resources.Load<Sprite>("locked");

        updateDisplay();
        // levelUnlocked = true; // TODO: remove later
    }

    private void updateDisplay() {
        levelUnlocked = PlayerData.unlocked[level];
        // levelUnlocked = true; // remove later 

        if (levelUnlocked) {
            levelText.text = PlayerData.foodInfo[level].levelName;
            image.sprite = unlockedSprite;
        } else {
            levelText.text = "-"+PlayerData.foodInfo[level].unlockCost + "円 アンロック"; // TODO: change font size 
            image.sprite = lockedSprite;
        }
        // updateMoneyText();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void buttonClicked() {
        PlayerData.justUnlocked = false;
        PlayerData.currentLevel = level;
        PlayerData.score = 0;
        if (levelUnlocked) {
            Debug.Log("Level: "+level);
        } else {
            int coins = PlayerData.coinTotal;
            int cost = PlayerData.foodInfo[level].unlockCost;
            if (cost > coins) {
                Debug.Log("Disabled Level "+level+" Clicked");
                StartCoroutine(disabledAnimation());
            }
            else {
                Debug.Log("Unlocking Level "+level);
                PlayerData.coinTotal = coins - cost;
                // levelUnlocked = true;
                PlayerData.unlocked[level] = true;
                updateDisplay();
                PlayerData.justUnlocked = true;
            }
        }
    }

    private IEnumerator disabledAnimation() {
        // TODO: wiggle not yet unlocked recipe
        // Debug.Log("Disabled Animation start");
        Transform transformToWiggle = thisTransform;
        float duration = 1f;
        float speed = 40f;
        float distance = 2f;
        float time = 0f;

        Vector3 pos = transformToWiggle.localPosition;
        Vector3 startPos = transformToWiggle.localPosition;

        while (time <= duration)
        {
            // Debug.Log(time);
            // Debug.Log(duration);
            pos.x = Mathf.Lerp(Mathf.Sin(time * speed) * distance, 0, time / duration);
            transformToWiggle.localPosition = pos;
            time += Time.deltaTime;
            yield return null;
        }
        // Debug.Log(time);
        // Debug.Log(duration);
        // Debug.Log("Disabled Animation end");

        transformToWiggle.localPosition = startPos;
    }
}
