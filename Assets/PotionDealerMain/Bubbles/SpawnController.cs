using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform targetPos;
    public bool canSpawn;
    public float spawnTimer;
    float timer;

    public GameObject nextBubble;

    TaskManager_Bubbles taskMan;

    public bool isRight;

    private void Start()
    {
        taskMan = FindObjectOfType<TaskManager_Bubbles>();
        spawnTimer = taskMan.spawnCooldown;
        
        //canSpawn = true;
    }
    private void Update()
    {
        if (!canSpawn)
        {
            StartTimer();
            taskMan.spawns.Remove(gameObject.transform);
        }
        else 
        {
            if(!taskMan.spawns.Contains(gameObject.transform))
                taskMan.spawns.Add(gameObject.transform);
        }
    }

    void StartTimer() 
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            canSpawn = true;
            timer = spawnTimer;
        }
    }

    public void SpawnBubble(GameObject _go) 
    {
        GameObject go;
        if (canSpawn && nextBubble == null && !taskMan.hasFinished)
        {
            go = Instantiate(_go, transform.position, Quaternion.identity);
            go.GetComponent<BubbleController>().target = targetPos;
            go.GetComponent<BubbleController>().spawnPoint = gameObject;
            nextBubble = go;
            canSpawn = false;
        }
    }

    public void ResetSpawn(float _fl) 
    {
        timer = _fl;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            canSpawn = true;
            timer = spawnTimer;
        }
    }
}
