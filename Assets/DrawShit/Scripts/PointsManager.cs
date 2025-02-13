using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public List<GameObject> pointsList = new List<GameObject>();

    public GameObject currentPoint;

    public int correctPoints = 1;

    private void Start()
    {
        foreach (GameObject go in pointsList)
        {
            go.SetActive(false);
        }
        correctPoints = 1;
        Init();
    }

    private void Init()
    {
        pointsList[0].SetActive(true);
        SetupUI();
    }

    public void ShowAllPoints()
    {
        foreach (GameObject go in pointsList)
        {
            go.SetActive(true);
        }
    }

    public void ChangePointColor()
    {
        foreach (GameObject go in pointsList)
        {
            if (go.GetComponent<PointsController>().isCorrect && go != currentPoint)
            {
                go.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (go.GetComponent<PointsController>().isCorrect && go == currentPoint)
            {
                go.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }

    public void FinishBoard()
    {
        foreach (GameObject go in pointsList)
        {
            go.GetComponent<Renderer>().material.color = Color.green;
        }
        Invoke("GetNext", 1);
    }

    void SetupUI() 
    {
        for (int i = 0; i < pointsList.Count; i++)
        {
            pointsList[i].GetComponentInChildren<Image>().sprite = FindObjectOfType<DrawLine_TaskManager>().sp[i];
        }
    }

    void GetNext() 
    {
        FindObjectOfType<BoardsManager>().NextBoard(gameObject);
    }
}
