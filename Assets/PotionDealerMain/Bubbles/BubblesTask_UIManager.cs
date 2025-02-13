using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubblesTask_UIManager : MonoBehaviour
{
    public Sprite emptyCircle;
    public Sprite filledCircle;
    public GameObject[] circlesLeftHand;
    public GameObject[] circlesRightHand;

    public Color colorLeft;
    public Color colorRight;

    private void Start()
    {
        
    }
    void OnEnable() 
    {
        ResetUI();
    }

    // Update is called once per frame
    public void UpdateCorrectAnswersLeft(int _i)
    {
        foreach (GameObject go in circlesLeftHand)
        {
            go.GetComponent<Image>().sprite = emptyCircle;
        }

        for (int i = 0; i < _i; i++)
        {
            circlesLeftHand[i].GetComponent<Image>().color = colorLeft;
            circlesLeftHand[i].GetComponent<Image>().sprite = filledCircle;

        }
    }
    
    public void UpdateCorrectAnswersRight(int _i)
    {
        foreach (GameObject go in circlesRightHand)
        {
            go.GetComponent<Image>().sprite = emptyCircle;
        }

        for (int i = 0; i < _i; i++)
        {
            circlesRightHand[i].GetComponent<Image>().color = colorRight;
            circlesRightHand[i].GetComponent<Image>().sprite = filledCircle;
        }
    }

    void ResetUI() 
    {
        UpdateCorrectAnswersRight(0);
        UpdateCorrectAnswersLeft(0);
    }
}
