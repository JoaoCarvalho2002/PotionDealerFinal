using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorResetBottleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bottle")
        {

            GameObject go = other.gameObject;
            GameObject parent = other.transform.parent.gameObject;
            parent.transform.position = go.GetComponent<SetPotion>().spawn.position;
            parent.transform.rotation = go.GetComponent<SetPotion>().spawn.rotation;
        }
    }
}
