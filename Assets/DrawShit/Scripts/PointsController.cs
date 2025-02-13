using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField]
    bool isFirstPoint;

    [SerializeField]
    bool isLastPoint;

    public bool isCorrect;
    public GameObject previousPoint;

    Color origColor;

    private void Start()
    {
        origColor = GetComponent<Renderer>().material.color;
        int i = FindObjectOfType<PointsManager>().pointsList.IndexOf(gameObject);
        if (!isFirstPoint)
        {
            previousPoint = FindObjectOfType<PointsManager>().pointsList[i - 1];
        }
    }

    private void Update()
    {
        if (isCorrect && GetComponent<BoxCollider>().enabled == true)
        {
            FindObjectOfType<PointsManager>().currentPoint = gameObject;
            FindObjectOfType<PointsManager>().ChangePointColor();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hand"))
        {
            if (isCorrect)
            {
                FindObjectOfType<PointsManager>().currentPoint = gameObject;
            }
            else
            {
                if (isFirstPoint)
                {
                    isCorrect = true;
                    FindObjectOfType<PointsManager>().ShowAllPoints();
                    FindObjectOfType<DrawLine>().CreateLine(gameObject.transform.position);
                    FindObjectOfType<DrawLine_TaskManager>().timeIsCounting = true;
                }
                else
                {
                    if (FindObjectOfType<PointsManager>().currentPoint == previousPoint)
                    {
                        isCorrect = true;
                        FindObjectOfType<PointsManager>().correctPoints++;
                        FindObjectOfType<DrawLine>().UpdateLine(gameObject.transform.position);
                    }
                    else
                        ChangeColor(Color.red);
                }
            }
            if (isLastPoint && isCorrect)
            {
                FindObjectOfType<DrawLine>().isFinished = true;
                FindObjectOfType<PointsManager>().FinishBoard();
                GetComponentInParent<BoardsManager>().AddCheck();
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Hand"))
        {
            if (!isCorrect)
                ChangeColor(origColor);
        }
    }
    void ChangeColor(Color color) 
    {
        GetComponent<Renderer>().material.color = color;
    }
}
