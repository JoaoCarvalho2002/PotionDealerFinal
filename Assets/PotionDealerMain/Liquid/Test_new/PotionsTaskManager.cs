using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsTaskManager : MonoBehaviour
{



    public float maxAngle = -1000;


    
    public int pourTreshold = 30;
    /*
    private void Update()
    {
        if (hasStarted && !hasFinished)
            CheckTaskCompletion();

        if (Input.GetKeyDown(KeyCode.Space))
            ResetTask();

    }

    private void OnEnable()
    {
     //   FindObjectOfType<GameManager>().taskIndex++;
        ResetPotionBottles();
        potionsMain.SetActive(true);
        ResetTask();
        SetupUI();
    }

    public void Init()
    {
        hasStarted = true;

        foreach (GameObject go in potionsGrabs)
        {
            go.GetComponent<CapsuleCollider>().enabled = true;
            go.GetComponent<MeshRenderer>().enabled = true;
        }

        taskUI.SetActive(true);
      //  FindObjectOfType<NPCSpeech_Controller>().DeactivateBalloons();
      //  FindObjectOfType<NPCSpeech_Controller>().canMoveText = false;
    }

    void CheckTaskCompletion()
    {
        int x = 0;

        for (int i = 0; i < pc.Length; i++)
        {
            if (pc[i].correctQuantity)
                x++;

        }
        if (x >= 4)
        {
            hasFinished = true;
            FinishTask();
        }                
    }

    void SetupUI()
    {
       // GetComponent<TaskManagerUI>().ClearList();
      //  foreach (PotionsController pcs in pc)
      //  {
         //   FindObjectOfType<TaskManagerUI>().instructions.Add(pcs.gameObject.GetComponent<SetPotion>().potionName + " " + pcs.quantityText);
     //   }
     //   GetComponent<TaskManagerUI>().SetupUI(diffLevel);
    }

    void FinishTask()
    {
        hasStarted = false;
      //  FindObjectOfType<NPCSpeech_Controller>().SetEndTaskSpeech(GetComponent<TaskSpeechManager>().finishTaskInstruction);
        if (taskCounter < 1)
            taskCounter++;

        ActivateBell();
    }

    public void ResetTask()
    {
        hasFinished = false;
        foreach (PotionsController pcs in pc)
        {
            pcs.Reset();
        }
        SetDifficulty();
    }

    void SetDifficulty()
    {
        List<PotionsController> pc_temp = new List<PotionsController>();

        foreach (PotionsController ptC in pc)
        {
            pc_temp.Add(ptC);
        }

        CheckDifficulty();

        if (potionsDifficulty == PotionsDifficulty.easy)
        {
            pourTreshold = 30;
          //  FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions1, true);
            diffLevel = "Fácil";
            int rnd = Random.Range(0, pc_temp.Count);
            pc_temp[rnd].GetComponent<PotionsController>().timer = 7;
            pc_temp[rnd].GetComponent<PotionsController>().quantity = 1;
            pc_temp[rnd].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[rnd].GetComponent<PotionsController>().quantityText = "- Muito";
            pc_temp.RemoveAt(rnd);

            for (int i = 0; i < 2; i++)
            {
                int rnd2 = Random.Range(0, pc_temp.Count);
                pc_temp[rnd2].GetComponent<PotionsController>().timer = 4;
                pc_temp[rnd2].GetComponent<PotionsController>().quantity = 1;
                pc_temp[rnd2].GetComponent<PotionsController>().filler.fillAmount = 0;
                pc_temp[rnd2].GetComponent<PotionsController>().quantityText = "- Pouco";
                pc_temp.RemoveAt(rnd2);
            }

            pc_temp[0].GetComponent<PotionsController>().timer = 1;
            pc_temp[0].GetComponent<PotionsController>().quantity = 0;
            pc_temp[0].GetComponent<PotionsController>().filler.fillAmount = 1;
            pc_temp[0].GetComponent<PotionsController>().quantityText = "- Nada";
            pc_temp[0].GetComponent<PotionsController>().correctQuantity = true;
            pc_temp.Remove(pc_temp[0]);


        }
        else if (potionsDifficulty == PotionsDifficulty.medium)
        {
            pourTreshold = 0;
           // FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions2, true);
            diffLevel = "Médio";
            int rnd = Random.Range(0, pc_temp.Count);
            pc_temp[rnd].GetComponent<PotionsController>().timer = 9;
            pc_temp[rnd].GetComponent<PotionsController>().quantity = 1;
            pc_temp[rnd].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[rnd].GetComponent<PotionsController>().quantityText = "- Bastante";
            pc_temp.RemoveAt(rnd);

            for (int i = 0; i < 2; i++)
            {
                int rnd2 = Random.Range(0, pc_temp.Count);
                pc_temp[rnd2].GetComponent<PotionsController>().timer = 5;
                pc_temp[rnd2].GetComponent<PotionsController>().quantity = 1;
                pc_temp[rnd2].GetComponent<PotionsController>().filler.fillAmount = 0;
                pc_temp[rnd2].GetComponent<PotionsController>().quantityText = "- Médio";
                pc_temp.RemoveAt(rnd2);
            }

            pc_temp[0].GetComponent<PotionsController>().timer = 1;
            pc_temp[0].GetComponent<PotionsController>().quantity = 0;
            pc_temp[0].GetComponent<PotionsController>().filler.fillAmount = 1;
            pc_temp[0].GetComponent<PotionsController>().quantityText = "- Nada";
            pc_temp[0].GetComponent<PotionsController>().correctQuantity = true;
            pc_temp.Remove(pc_temp[0]);
        }
        else if (potionsDifficulty == PotionsDifficulty.hard)
        {
            pourTreshold = -10;
           // FindObjectOfType<NPCSpeech_Controller>().SetSpeech(GetComponent<TaskSpeechManager>().taskInstructions3, true);
            diffLevel = "Difícl";
            int rnd = Random.Range(0, pc_temp.Count);
            pc_temp[rnd].GetComponent<PotionsController>().timer = 9;
            pc_temp[rnd].GetComponent<PotionsController>().quantity = 1;
            pc_temp[rnd].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[rnd].GetComponent<PotionsController>().quantityText = "- Bastante";
            pc_temp.RemoveAt(rnd);

            int rnd2 = Random.Range(0, pc_temp.Count);
            pc_temp[rnd2].GetComponent<PotionsController>().timer = 7;
            pc_temp[rnd2].GetComponent<PotionsController>().quantity = 1;
            pc_temp[rnd2].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[rnd2].GetComponent<PotionsController>().quantityText = "- Muito";
            pc_temp.RemoveAt(rnd2);

            int rnd3 = Random.Range(0, pc_temp.Count);
            pc_temp[rnd3].GetComponent<PotionsController>().timer = 5;
            pc_temp[rnd3].GetComponent<PotionsController>().quantity = 1;
            pc_temp[rnd3].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[rnd3].GetComponent<PotionsController>().quantityText = "- Médio";
            pc_temp.RemoveAt(rnd3);


            pc_temp[0].GetComponent<PotionsController>().timer = 3;
            pc_temp[0].GetComponent<PotionsController>().quantity = 1;
            pc_temp[0].GetComponent<PotionsController>().filler.fillAmount = 0;
            pc_temp[0].GetComponent<PotionsController>().quantityText = "- Pouco";
            pc_temp.Remove(pc_temp[0]);
        }

        pc_temp.Clear();
        ActivateControllers(true);
    }

    void CheckDifficulty()
    {
        if (taskCounter == 0)
            potionsDifficulty = PotionsDifficulty.easy;
        if (taskCounter == 1)
        {
            if (maxAngle < mediumPass && maxAngle > hardPass)
            {
                Debug.Log("medium");
                potionsDifficulty = PotionsDifficulty.medium;
            }
            else if (maxAngle < hardPass)
            {
                Debug.Log("hard");
                potionsDifficulty = PotionsDifficulty.hard;
            }
            else if (maxAngle > mediumPass)
            {
                Debug.Log("easy");
                potionsDifficulty = PotionsDifficulty.easy;
            }
        }
        maxAngle = 1000;
    }

    void ActivateBell()
    {
        ActivateControllers(false);
       // FindObjectOfType<BellRingController>().canRing = true;
       // FindObjectOfType<BellRingController>().ReactivateCollider();
    }

    void ResetPotionBottles()
    {
        foreach (SetPotion sp in potions)
        {
            GameObject parent = sp.transform.parent.gameObject;

            parent.transform.position = sp.spawn.position;
            parent.transform.rotation = sp.spawn.rotation;
        }
    }

    void DeactivateBottles()
    {
        foreach (GameObject go in potionsGrabs)
        {
            //go.GetComponent<CapsuleCollider>().enabled = false;
            go.GetComponent<MeshRenderer>().enabled = false;
        }
        taskUI.SetActive(false);
    }

    void ActivateControllers(bool _b) 
    {
        foreach (PotionsController _pc in pc)
        {
            _pc.enabled = _b;
        }
    }
    */
    public void GetMaxAngle(float _fl) 
    {
        if (_fl < maxAngle)
            maxAngle = _fl;
    }
    /*
    private void OnDisable()
    {
        DeactivateBottles();
        ResetPotionBottles();
    }

    */
}
