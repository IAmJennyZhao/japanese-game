using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using PlayerData;

public class CookingBar : MonoBehaviour
{
    private Slider slider;
    public RectTransform targetRect;
    public RectTransform handle;
    public Button stopButton;
    public Image[] fires;

    private Sprite[] consistentFireSprites;
    private int[] indexes = {0, 15, 30, 5, 20, 35, 10, 25, 40};
    private int max_index;
    private float timeAnimationGif = 0.07f;
    private float timeAnimationPassed = 0.0f;
    // private Sprite[] poofFireSprites;

    // cooking bar parameters: 
    private float targetValue = .4f;

    private float FillSpeed = 0.25f;

    private float sliderValue = 0.0f; // resets slider at 0 everytime page is loaded
    private bool moving = false;
    private float timeBeforeMoving = 1.0f;
    private float timePassed = 0.0f;

    private static float smallTargetWidth = 16.0f;
    private static float largeTargetWidth = 35.0f;
    private static float fullWidth = 175.5f;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
        slider.value = sliderValue;
        targetValue = PlayerData.foodInfo[PlayerData.currentLevel].cookingLength;
        PlayerData.score = -1;
        consistentFireSprites = new Sprite[100];
        max_index = 65;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Update position of target for cooking
        targetRect.localPosition = new Vector3(targetValue*fullWidth-fullWidth/2.0f, 0, 0);

        // Load in all the fire gif sprites
        for (int i = 0; i <= max_index; i++) {
            Sprite sprite = Resources.Load<Sprite>("consistentFireTransparent/consistentFireTransparent-frame_" + i.ToString("00") + "_delay-0.07s");
            consistentFireSprites[i] = sprite;
        }
        updateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving && sliderValue == 0) {
            timePassed += Time.deltaTime;
            if (timePassed > timeBeforeMoving){
                moving = true;
                timePassed = 0;
                // Debug.Log(Time.deltaTime);
            }
            checkDisplay();
        }
        else if (moving && sliderValue < 1) {
            // update slider value
            sliderValue += FillSpeed * Time.deltaTime;
            slider.value = sliderValue;
            
            // update display animation
            checkDisplay();
        }
        else if (moving && sliderValue >= 1) {
            // moving = false;
            // stopCooking();
            stopButton.onClick.Invoke();
        }
    }

    private void checkDisplay() {
        // update display animation
        timeAnimationPassed += Time.deltaTime;
        if (timeAnimationPassed > timeAnimationGif) {
            timeAnimationPassed -= timeAnimationGif;
            updateDisplay();
        }
    }

    private void updateDisplay() {
        // update the fire animation
        for(int i = 0 ; i<9; i++ ){
            int index = indexes[i];
            Sprite sprite = consistentFireSprites[index];
            fires[i].sprite = sprite;
            indexes[i] = (indexes[i] + 1) % (max_index+1);
        }
    }

    // called when stop cooking button is pressed
    public void stopCooking() {
        if (moving) {
            moving = false;
            int score = scoring();
            Debug.Log(score);
            PlayerData.score = score;
        }
    }

    // returns 0 if cooking stopped outside of target range, 1 in larger range, 2 in smaller range
    private int scoring() {
        Vector3[] v = new Vector3[4];
        // Quaternion q = new Quaternion(0,0,0,1);
        // targetRect.GetLocalPositionAndRotation(v, q);
        // print(v);
        // print(q);
        // print(targetRect.worldPosition);    
        // targetRect.getWorldCorners(v);
        // Debug.Log("World Corners");
        // for (var i = 0; i < 4; i++)
        // {
        //     Debug.Log("World Corner " + i + " : " + v[i]);
        // }    
        // print(targetRect.GetWorl);
        // float handle_x = handle.position.x;
        // float target_x = targetRect.position.x;
        float dif = slider.value - targetValue;
        // Debug.Log(handle_x);
        // Debug.Log(target_x);
        Debug.Log(dif);
        float smallRange = smallTargetWidth / 2.0f /fullWidth;
        float largeRange = largeTargetWidth / 2.0f /fullWidth;
        if ( -smallRange < dif && dif < smallRange) 
            return 2;
        else if (-largeRange < dif && dif < largeRange)
            return 1;
        return 0;
    }
}
