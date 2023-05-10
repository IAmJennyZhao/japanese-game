using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicController : MonoBehaviour
{
    GameObject musicParent;

    AudioSource[] musicObjs; // holds all the music that we will be playing 
    /**
    all music credits to Michael Zhang
    0: title bg
    1: level menu screen + cooking background music
    2: Game congrats SFX
    3: Game end loop 
    4: button sfx
    5: unlock sfx
    **/

    string lastScene;

    // delay for game end loop song
    private float timeDelay = 4.0f;
    private float timePassed = 0.0f;
    private bool gameEndPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        musicParent = GameObject.FindGameObjectsWithTag("MusicParent")[0];
        // musicObjs = musicParent.GetComponentsInChildren<AudioSource>();
        musicObjs = new AudioSource[6];
        for (int i = 0 ; i<musicParent.transform.childCount; i++) {
            musicObjs[i] = musicParent.transform.GetChild(i).GetComponent<AudioSource>();
        }
        // foreach (Transform child in musicParent.transform) {
        //     musicObjs[i]
        // }

        Debug.Log(musicObjs.Length);
        
        string currentScene = SceneManager.GetActiveScene().name;
        lastScene = currentScene;
        updateBackgroundMusic(currentScene);
    }

    private void updateBackgroundMusic(string currentScene) {
        // setting background music
        if (currentScene == "タイトルスクリーン" || currentScene == "ルールスクリーン") {
            if (currentScene != lastScene) {
                playButtonClickSFX();
            }
            musicObjs[0].UnPause();
            musicObjs[1].Play();
            musicObjs[1].Pause();
            Debug.Log("0");
        }
        else if (currentScene == "メニュースクリーン") {
            playButtonClickSFX();
            musicObjs[0].Pause();
            musicObjs[1].UnPause();
            musicObjs[2].Stop();
            musicObjs[3].Stop();
            Debug.Log("1");
        }
        else if (currentScene == "ゲームスクリーン") {
            playButtonClickSFX();
            musicObjs[1].UnPause();
            musicObjs[2].Stop();
            musicObjs[3].Stop();
            Debug.Log("2");
        }
        else if (currentScene == "ゲームエンドスクリーン") {
            playButtonClickSFX();
            musicObjs[1].Pause();
            musicObjs[2].Play();
            Debug.Log("3");
        }
        else if (currentScene == "インフォスクリーン") {
            playButtonClickSFX();
            musicObjs[1].UnPause();
            musicObjs[2].Stop();
            musicObjs[3].Stop();
            Debug.Log("4");
        }
        else {
            Debug.Log("No background music found");
        }
    }

    void Update() {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene != lastScene) {
            updateBackgroundMusic(currentScene);
            if (currentScene == "ゲームエンドスクリーン")
                timePassed = 0.0f;
            lastScene = currentScene;
        }
        if (!gameEndPlaying  && currentScene == "ゲームエンドスクリーン"){
            timePassed += Time.deltaTime;
            if (timePassed > timeDelay) {
                musicObjs[3].Play();
                gameEndPlaying = true;
            }
        }
    }

    public void playButtonClickSFX() {
        musicObjs[4].PlayOneShot(musicObjs[4].clip, .2f);
    }

    public void playUnlockSFX() {
        musicObjs[5].Play();
    }
}
