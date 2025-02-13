using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTT_DataManager : MonoBehaviour
{
    private static CTT_DataManager _instance;
    public static CTT_DataManager Instance { get { return _instance; } }

    public SortedDictionary<string, string> expAnswers = new SortedDictionary<string, string>();
    public SortedDictionary<string, string> questAnswers = new SortedDictionary<string, string>();
    public List<bool> easyBoards = new List<bool>();
    public List<bool> mediumBoards = new List<bool>();
    public List<bool> hardBoards = new List<bool>();

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void FinishTask()
    {
        AddBoardsData(easyBoards, "01_easy");
        AddBoardsData(mediumBoards, "02_medium");
        AddBoardsData(hardBoards, "03hard");

        foreach (KeyValuePair<string, string> kvp in expAnswers)
        {
            Debug.Log(kvp.Key + " " + kvp.Value);
        }
    }

    void AddBoardsData(List<bool> _B, string _st) 
    {
        string st = "";
        string st1 = "";
        for (int i = 0; i < _B.Count; i++)
        {
            int index = i + 1;
            st = "exp_" + _st + index.ToString();

            if (_B[i])
                st1 = "Complete";
            else
                st1 = "Incomplete";

            expAnswers.Add(st, st1);
        }
    }
}
