using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSplash : MonoBehaviour
{
    //Transform bubblePosition;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bubble")
        {
            GameObject go = other.gameObject;
            go.GetComponent<BubbleController>().Splash();
            go.GetComponent<BubbleController>().spawnPoint.GetComponent<SpawnController>().ResetSpawn(1);
            Destroy(go);
            //Destroy(gameObject);
             
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            GameObject go = collision.gameObject;
            go.GetComponent<BubbleController>().Splash();
            go.GetComponent<BubbleController>().spawnPoint.GetComponent<SpawnController>().ResetSpawn(1);
          //  SendCount(go);
            Destroy(go);
            //Destroy(gameObject);
        }
    }

  //  void SendCount(GameObject go)
  //  {
      //  if (GetComponent<CheckHand>().isLeft && go.GetComponent<BubbleController>().color == "Pink")
     //   {
  //          if (FindObjectOfType<TaskManager_Bubbles>().correctBubblesLeft < 7)
              //  FindObjectOfType<TaskManager_Bubbles>().correctBubblesLeft++;
  //      }
  //      else if (GetComponent<CheckHand>().isLeft && go.GetComponent<BubbleController>().color == "Blue")
  //      {
          //  if (FindObjectOfType<TaskManager_Bubbles>().correctBubblesLeft > 0)
          ///      FindObjectOfType<TaskManager_Bubbles>().correctBubblesLeft--;

        //    FindObjectOfType<TaskManager_Bubbles>().errors++;

       // }
      //  else if (!GetComponent<CheckHand>().isLeft && go.GetComponent<BubbleController>().color == "Blue")
     //   {
     //       if (FindObjectOfType<TaskManager_Bubbles>().correctBubblesRight < 7)
      //          FindObjectOfType<TaskManager_Bubbles>().correctBubblesRight++;
     //   }
      //  else if (!GetComponent<CheckHand>().isLeft && go.GetComponent<BubbleController>().color == "Pink")
      //  {
       //     if (FindObjectOfType<TaskManager_Bubbles>().correctBubblesRight > 0)
       //         FindObjectOfType<TaskManager_Bubbles>().correctBubblesRight--;
        //     FindObjectOfType<TaskManager_Bubbles>().errors++;
       // }
    //}
}
