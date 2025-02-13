using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPouringController : MonoBehaviour
{
    
    public Transform origin;
    public GameObject streamPrefab;

    [HideInInspector]
    public bool isPouring;
    LiquidStream currentStream = null;

    string parentName;

    private void Update()
    {
        //if (FindObjectOfType<PotionsTaskManager>() != null)
        //{ 
            bool pourCheck = CalculatePourAngle() < FindObjectOfType<PotionsTaskManager>().pourTreshold;

            //FindObjectOfType<PotionsTaskManager>().pourTreshold = Mathf.Clamp(FindObjectOfType<PotionsTaskManager>().pourTreshold, -45, 30);
            if (isPouring != pourCheck)
            {
                isPouring = pourCheck;

                if (isPouring && !GetComponent<SetPotion>().isEmpty)
                {
                    StartPour();
                }
                else if (!isPouring && !GetComponent<SetPotion>().isEmpty)
                {
                    EndPour();
                }
            }

            if (GetComponent<SetPotion>().isEmpty && currentStream != null)
            {
                EndPour();
            }
        //}
    }

    private void StartPour()
    {
        //currentStream = CreateStream();
        //currentStream.Begin();
    }

    private void EndPour()
    {
        currentStream.End();
        DestroyStream();


    }

    private float CalculatePourAngle() 
    {
        float angle = 0;
        angle = transform.up.y * Mathf.Rad2Deg;

        FindObjectOfType<PotionsTaskManager>().GetMaxAngle(angle);
        return angle;
    }

    public LiquidStream CreateStream(string _st) 
    {
        GameObject streamObj = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        //var parentName = streamObj.transform.parent.name;
        if (_st == "potionWhite")
        {
            Debug.Log("hite");
            streamObj.gameObject.tag = "LiquidWhite";
        }
        if (parentName == "potionYellow")
        {
            Debug.Log("yellow");
            streamObj.gameObject.tag = "LiquidYellow";
        }
        if (parentName == "potionPurple")
        {
        
            streamObj.gameObject.tag = "LiquidPurple";
        }
        if (parentName == "potionBlue")
        {
           
            streamObj.gameObject.tag = "LiquidBlue";
        }
        return streamObj.GetComponent<LiquidStream>();

    }

    public void DestroyStream() 
    {
        Destroy(currentStream.gameObject, .1f);
    }
}
