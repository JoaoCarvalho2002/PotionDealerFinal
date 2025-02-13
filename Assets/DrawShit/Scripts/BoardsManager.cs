using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardsManager : MonoBehaviour
{ 
    public List<GameObject> boards = new List<GameObject>();

    [SerializeField]
    bool isTutorial;
    private void OnEnable()
    {
        if (!isTutorial)
        {
            boards[0].SetActive(true);
            FindObjectOfType<DrawLine_TaskManager>().currentBoard = boards[0];
            int i = boards.IndexOf(boards[0]) + 1;
            FindObjectOfType<UIManager>().boardIndex.text = i.ToString();
        }
        else 
        {
            FindObjectOfType<DrawLine_TaskManager>().StartTutorial();
        }
        FindObjectOfType<UIManager>().TutorialUI(isTutorial);
    }

    public void Init() 
    {
        boards[0].SetActive(true);
        FindObjectOfType<DrawLine_TaskManager>().currentBoard = boards[0];
        int i = boards.IndexOf(boards[0]) + 1;
        FindObjectOfType<UIManager>().boardIndex.text = i.ToString();
        FindObjectOfType<UIManager>().TutorialUI(isTutorial);
    }

    public void NextBoard(GameObject go) 
    {
        FindObjectOfType<DrawLine_TaskManager>().timeIsCounting = false;
        FindObjectOfType<DrawLine_TaskManager>().ResetTimer();
        int i = boards.IndexOf(go);
        
        boards[i].SetActive(false);
        FindObjectOfType<DrawLine>().DestroyLine();
        if (i < boards.Count - 1)
        {
            i++;
            boards[i].SetActive(true);
            FindObjectOfType<DrawLine_TaskManager>().currentBoard = boards[i];
            FindObjectOfType<UIManager>().boardIndex.text = (i + 1).ToString();
        }
        else
        {
            GameObject go2 = FindObjectOfType<BoardsManager>().gameObject;
            go2.SetActive(false);
            if (isTutorial)
            {
                FindObjectOfType<DrawLineInstructionsController>().ShowLastInstructions();
            }
            else
            {
                if (FindObjectOfType<DrawLine_TaskManager>().isStandAloneBuild)
                {
                    if (FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.easy)
                        FindObjectOfType<DrawLine_TaskManager>().LoadNextScene(1);
                    else if (FindObjectOfType<DrawLine_TaskManager>().difficulty == DrawLine_TaskManager.Difficulty.medium)
                        FindObjectOfType<DrawLine_TaskManager>().LoadNextScene(1);
                    else
                        FindObjectOfType<DrawLine_TaskManager>().FinishTask();
                }
                else
                    Debug.Log("It's over");
            }
        }
    }

    public void AddCheck() 
    {
        if(!isTutorial)
            FindObjectOfType<DrawLine_TaskManager>().AddCheckToList(true);
    }
}
