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

    public float targetValue = .4f;

    public float FillSpeed = 0.05f;
    private float sliderValue = 0; // resets slider at 0 everytime page is loaded
    private bool moving = true;

    private static float smallTargetWidth = 16.0f;
    private static float largeTargetWidth = 35.0f;
    private static float fullWidth = 144.0f;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        targetRect.localPosition = new Vector3(targetValue*fullWidth-fullWidth/2.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && sliderValue < 1) {
            sliderValue += FillSpeed * Time.deltaTime;
            slider.value = sliderValue;
        }
    }

    // called when stop cooking button is pressed
    public void stopCooking() {
        moving = false;
        int score = scoring();
        Debug.Log(score);
        PlayerData.score = score;
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
