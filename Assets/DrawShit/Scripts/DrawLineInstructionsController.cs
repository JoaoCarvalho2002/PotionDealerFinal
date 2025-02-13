using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawLineInstructionsController : MonoBehaviour
{
    public string[] instructions;
    public string[] newStageInstructions;
    public string[] finalLevelInstuctions;
    public string[] finalTaskInstuctions;
    public GameObject balloonObj;
    public TMP_Text speechBalloon;


    void Start()
    {
       // if(FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.easy)
       //     StartCoroutine(StartTutorial());
      //  else
       //     StartCoroutine(StartLevel());
    }
    
    public void FinishLevelInstructions() => StartCoroutine(FinishLevel());

    public void ShowLastInstructions() => StartCoroutine(FinishTutorial());

    IEnumerator StartTutorial()
    {
        for (int i = 0; i <= 7; i++)
        {
            balloonObj.SetActive(true);
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(true);
            speechBalloon.text = instructions[i];
            yield return new WaitForSeconds(7);
            balloonObj.SetActive(false);
        //    FindObjectOfType<NPCAnimationController>().NPCTalking(false);
        }
     //   FindObjectOfType<DrawLine_TaskManager>().StartTutorial();
    }

    IEnumerator FinishTutorial()
    {
        for (int i = 8; i < instructions.Length; i++)
        {
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(true);
            balloonObj.SetActive(true);
            speechBalloon.text = instructions[i];
            yield return new WaitForSeconds(7);
            balloonObj.SetActive(false);
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(false);
        }
    //    FindObjectOfType<DrawLine_TaskManager>().StartTask();
    }

    IEnumerator StartLevel()
    {
        for (int i = 0; i < newStageInstructions.Length; i++)
        {
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(true);
            balloonObj.SetActive(true);
            speechBalloon.text = newStageInstructions[i];
            yield return new WaitForSeconds(7);
            balloonObj.SetActive(false);
         //   FindObjectOfType<NPCAnimationController>().NPCTalking(false);
        }
       // FindObjectOfType<DrawLine_TaskManager>().StartTask();
    }
    
    IEnumerator FinishLevel()
    {
        for (int i = 0; i < finalLevelInstuctions.Length; i++)
        {
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(true);
            balloonObj.SetActive(true);
            speechBalloon.text = finalLevelInstuctions[i];
            yield return new WaitForSeconds(7);
            balloonObj.SetActive(false);
         //   FindObjectOfType<NPCAnimationController>().NPCTalking(false);
        }
      //  FindObjectOfType<DrawLine_TaskManager>().LoadNextScene(2);
    }
    
    IEnumerator FinishExperience()
    {
        for (int i = 0; i < finalTaskInstuctions.Length; i++)
        {
          //  FindObjectOfType<NPCAnimationController>().NPCTalking(true);
            balloonObj.SetActive(true);
            speechBalloon.text = finalTaskInstuctions[i];
            yield return new WaitForSeconds(7);
            balloonObj.SetActive(false);
        //    FindObjectOfType<NPCAnimationController>().NPCTalking(false);
        }
        //FindObjectOfType<DrawLine_TaskManager>().StartTask();
    }

}
