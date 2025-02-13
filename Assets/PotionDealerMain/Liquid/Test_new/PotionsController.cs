using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsController : MonoBehaviour
{
    public string potionName;
    public float timer;
    public float quantity;
    public string quantityText;
    public bool correctQuantity;


    private void Start()
    {
        potionName = GetComponent<SetPotion>().potionName;
    }

    private void OnEnable()
    {
    }

    private void Update()
    {
     //   if (FindObjectOfType<GameManager>().currentTask == FindObjectOfType<PotionsTaskManager>().gameObject)
    //    {
      //      if (FindObjectOfType<PotionsTaskManager>().hasStarted && !FindObjectOfType<PotionsTaskManager>().hasFinished && !correctQuantity)
       //         CheckCompletion();
      //  }
    }




    public void Reset()
    {
        timer = 0;
        quantity = 0;
        quantityText = "";
        correctQuantity = false;
        GetComponent<SetPotion>().SetupTask();
    }

    

}
