using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager_Bubbles : MonoBehaviour
{
    public List<GameObject> bubbles = new List<GameObject>();
    public List<GameObject> bubblesOnScreen = new List<GameObject>();
    public List<Transform> spawns = new List<Transform>();

    public int maxBubbles;
    public float spawnCooldown;

    public int totalBubbles;

    public float minSpeed;
    public float maxSpeed;

    public int correctBubblesLeft;
    public int correctBubblesRight;

    public bool hasStarted;
    public bool hasFinishedLeft;
    public bool hasFinishedRight;
    public bool hasFinished;

    public GameObject taskObjs;
    public GameObject smackTrigger;
    public GameObject taskUI;

    int difficultyPercentage;

    [HideInInspector]
    public string diffLevel;

    [HideInInspector]
    public int errors;
    [SerializeField]
    int maxErrors;

    bool hasPassed;


    public enum BubblesDifficulty
    {
        easy,
        medium,
        hard
    }

    public BubblesDifficulty difficulty;

    [SerializeField]
    int taskCounter;


    private void OnEnable()
    {
       // FindObjectOfType<GameManager>().taskIndex++;
        //SetDifficulty();
    }

    void SetDifficulty() 
    {
        errors = 0;
        CheckDifficulty();
        switch (difficulty) 
        {
            case BubblesDifficulty.easy:
                ChooseDifficultySettings(25, 2, 0.05f, 0.25f, "Fácil");
             //   FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions1, true);
                break;
            case BubblesDifficulty.medium:
                ChooseDifficultySettings(35, 2, 0.1f, 0.3f, "Médio");
             //   FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions1, true);
                break;
            case BubblesDifficulty.hard:
                ChooseDifficultySettings(45, 3, 0.15f, 0.35f, "Difícil"); 
        ///       FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions1, true);
                break;
        }
       // GetComponent<TaskManagerUI>().SetupUI(diffLevel);
    }

    public void Init()
    {
        hasStarted = true;
        taskObjs.SetActive(true);
      //  if(taskCounter == 0)
      //      CalibrateScene();
      //  GetComponent<TaskManagerUI>().SetupUI(diffLevel);
     ///   FindObjectOfType<NPCSpeech_Controller>().DeactivateBalloons();
     //   FindObjectOfType<NPCSpeech_Controller>().canMoveText = false;
        taskUI.SetActive(true);
    }

   // void CalibrateScene() 
 //   {
    //    spawns[0].position = new Vector3(spawns[0].position.x, spawns[0].position.y, FindObjectOfType<GameManager>().rightFront.z);
    //    spawns[1].position = new Vector3(spawns[1].position.x, spawns[1].position.y, FindObjectOfType<GameManager>().leftFront.z);
 //   }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted && !hasFinished)
        {
            if (bubblesOnScreen.Count < maxBubbles)
                SpawnBubble();
        }

        if (!hasFinished)
            CheckCompletion();        
    }

    void SpawnBubble() 
    {
        int rnd = Random.Range(0, 100);

        foreach (Transform tr in spawns)
        {
            if (tr.gameObject.GetComponent<SpawnController>().canSpawn)
            {
               
                if (rnd > difficultyPercentage)
                {
                    if (tr.gameObject.GetComponent<SpawnController>().isRight)
                        tr.GetComponent<SpawnController>().SpawnBubble(bubbles[0]);
                    else
                        tr.GetComponent<SpawnController>().SpawnBubble(bubbles[1]);
                }
                else
                {
                    if (tr.gameObject.GetComponent<SpawnController>().isRight)
                        tr.GetComponent<SpawnController>().SpawnBubble(bubbles[1]);
                    else
                        tr.GetComponent<SpawnController>().SpawnBubble(bubbles[0]);
                }
            }
        }
    }

    void CheckCompletion()
    {
        if (correctBubblesLeft >= 7)
        {
            correctBubblesLeft = 7;
            hasFinishedLeft = true;
        }
        else
        {
            hasFinishedLeft = false;

        }
        if (correctBubblesRight >= 7)
        {
            correctBubblesRight = 7;
            hasFinishedRight = true;
        }
        else
            hasFinishedRight = false;

       // if (FindObjectOfType<BubblesTask_UIManager>() != null)
      //      FindObjectOfType<BubblesTask_UIManager>().UpdateCorrectAnswersLeft(correctBubblesLeft);

      //  if (FindObjectOfType<BubblesTask_UIManager>() != null)
          //  FindObjectOfType<BubblesTask_UIManager>().UpdateCorrectAnswersRight(correctBubblesRight);


        if (hasFinishedRight && hasFinishedLeft)
        {
            FinishTask();
        }

        if (!hasFinishedRight || !hasFinishedLeft)
            hasFinished = false;


    }

    void FinishTask() 
    {
        taskUI.SetActive(false);
        hasFinished = true;
        foreach (GameObject go in bubblesOnScreen)
        {
            Destroy(go);
        }
        ActivateBell();

        if (errors <= maxErrors)
            hasPassed = true;
        else
            hasPassed = false;

       // FindObjectOfType<NPCSpeech_Controller>().SetEndTaskSpeech(GetComponent<TaskSpeechManager>().finishTaskInstruction);
    }

    void CheckDifficulty()
    {
        if (taskCounter == 0)
            difficulty = BubblesDifficulty.medium;
        if (taskCounter == 1)
        {
            if(hasPassed)
                difficulty = BubblesDifficulty.hard;
            else
                difficulty = BubblesDifficulty.easy;
        }
    }

    void ResetTask()
    {
        correctBubblesLeft = 0;
        correctBubblesRight = 0;
        hasStarted = false;
        CheckCompletion();        
    }

    void ActivateBell() 
    {
       // FindObjectOfType<BellRingController>().canRing = true;
       // FindObjectOfType<BellRingController>().ReactivateCollider();
        ResetTask();
    }

    void OnDisable()
    {
        if (taskCounter < 1)
            taskCounter++;
        ResetTask();
    }

    void ChooseDifficultySettings(int _difPerc, int _maxB, float _minS, float _maxS, string _difStr) 
    {
        difficultyPercentage = _difPerc;
        maxBubbles = _maxB;
        minSpeed = _minS;
        maxSpeed = _maxS;
        diffLevel = _difStr;
    }
}
