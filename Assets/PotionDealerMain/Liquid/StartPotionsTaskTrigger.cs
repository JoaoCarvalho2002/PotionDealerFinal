using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPotionsTaskTrigger : MonoBehaviour
{

    [SerializeField]
    GameObject task;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if (!task.activeInHierarchy)
            gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {

       // if (other.tag == "Hand")
     //   {
           // if (FindObjectOfType<GameManager>().currentTask == task)
        //    {
          //      FindObjectOfType<PotionsTaskManager>().Init();
          //      gameObject.SetActive(false);
        //    }
          //  else
       //   //      gameObject.SetActive(false);
      //  }
    }
}
