using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawLine_TaskManager : MonoBehaviour
{
    public bool isStandAloneBuild;
    public enum Difficulty 
    { 
        easy,
        medium,
        hard
    }

    public Difficulty difficulty;

    public GameObject tutorial;
    public GameObject easyBoards;
    public GameObject mediumBoards;
    public GameObject hardBoards;

    public Sprite[] sp;

    public float easyTimer;
    public float mediumTimer;
    public float hardTimer;
    public float startTimer;
    float timer;

    public bool timeIsCounting;
    public GameObject currentBoard;

    bool hasStarted = false;

    void Start()
    {
        startTimer = 1000;
        easyBoards.SetActive(false);
        mediumBoards.SetActive(false);
        hardBoards.SetActive(false);

        if (FindObjectOfType<CTT_DataManager>().easyBoards.Count > 0 && FindObjectOfType<CTT_DataManager>().mediumBoards.Count < 1)
            difficulty = Difficulty.medium;
        else if (FindObjectOfType<CTT_DataManager>().easyBoards.Count > 0 && FindObjectOfType<CTT_DataManager>().mediumBoards.Count > 0)
            difficulty = Difficulty.hard;
        else
            difficulty = Difficulty.easy;

    }

    public void StartTutorial() => tutorial.SetActive(true);
    public void StartTask() => CheckDifficulty();
    void CheckDifficulty() 
    {
        hasStarted = true;
        switch (difficulty) 
        {
            case Difficulty.easy:
                easyBoards.SetActive(true);
                startTimer = easyTimer;
                break;
            case Difficulty.medium:
                mediumBoards.SetActive(true);
                startTimer = mediumTimer;
                break;
            case Difficulty.hard:
                hardBoards.SetActive(true);
                startTimer = hardTimer;
                break;
        }
        timer = startTimer;
    }

    private void Update()
    {
        if(hasStarted)
            UpdateClock();
    }

    void UpdateClock() 
    {
        if (timeIsCounting)
            timer -= Time.deltaTime;

        if (timer <= 0) 
        {
            FindObjectOfType<BoardsManager>().NextBoard(currentBoard);
            AddCheckToList(false);
        }

        int UITime = Mathf.CeilToInt(timer);
        FindObjectOfType<UIManager>().UpdateTimer(UITime.ToString());
    }

    public void ResetTimer() => timer = startTimer;

    /*public void ChangeToMedium() 
    {
        difficulty = Difficulty.medium;
        CheckDifficulty();
    }
    public void ChangeToHard()
    {
        difficulty = Difficulty.hard;
        CheckDifficulty();
    }*/

    public void AddCheckToList(bool _b)
    {
        if (FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.easy)
            FindObjectOfType<CTT_DataManager>().easyBoards.Add(_b);
        else if (FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.medium)
            FindObjectOfType<CTT_DataManager>().mediumBoards.Add(_b);
        else if (FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.hard)
            FindObjectOfType<CTT_DataManager>().hardBoards.Add(_b);
    }

    public void FinishTask() 
    {
        //FindObjectOfType<CTT_DataManager>().FinishTask();
        LoadNextScene(0);
    }

    public void LoadNextScene(int _i) 
    {
        SceneManager.LoadScene(_i);
    }
}
