using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text boardIndex;

    public void UpdateTimer(string _st)
    {
        timer.text = _st;    
    }

    public void TutorialUI(bool _b)
    {
        timer.gameObject.SetActive(!_b);
    }
}
