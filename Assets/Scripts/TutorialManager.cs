using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 0f;

    void Update()
    {
        for(int i = 0; i<popUps.Length; i++){
            if(i== popUpIndex){
                popUps[i].SetActive(true);
            } else {
                popUps[i].SetActive(false);
            }
        }
        waitTime += Time.deltaTime;

        if(popUpIndex == 0){
            if(waitTime > 1){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }
            }
        } else if(popUpIndex == 1){
            if(waitTime > 2){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }
            }
        } else if(popUpIndex == 2){
            if(waitTime > 3){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }

        }
        } else if(popUpIndex == 3){
            if(waitTime > 5){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }

        }

        }
        else if(popUpIndex == 4){
            if(waitTime > 7){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }

        }

        }
        else if(popUpIndex == 5){
            if(waitTime > 10){
            Time.timeScale = 0f;
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                popUpIndex++;
                Time.timeScale = 1f;
            }
            SceneManager.LoadScene("GameMenu");

        }

        }
    }

        }
    
    
