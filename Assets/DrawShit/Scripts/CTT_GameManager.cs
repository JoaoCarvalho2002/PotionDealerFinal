using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTT_GameManager : MonoBehaviour
{
    public string username;

    private static CTT_GameManager _instance;
    public static CTT_GameManager Instance { get { return _instance; } }

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
}
