using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBubblesTaskTrigger : MonoBehaviour
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

      //  if (other.tag == "Hand")
      //  {
        //    if (FindObjectOfType<GameManager>().currentTask == task)
          //  {
           //     FindObjectOfType<TaskManager_Bubbles>().Init();
           //     gameObject.SetActive(false);
         //   }
          //  else
          //      gameObject.SetActive(false);
        //}
    }
}
