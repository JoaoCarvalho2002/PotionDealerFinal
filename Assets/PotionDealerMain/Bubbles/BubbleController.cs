using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public string color;

    [SerializeField]
    float speed;
    
    public Transform target;

    public GameObject partSystemPrefab;

    [SerializeField]
    Material bubbleMat;
    [SerializeField]
    Color bubbleColor;

    public GameObject spawnPoint;

    // Start is called before the first frame update
    public void Start()
    {
        //bubbleMat = GetComponent<Material>();
        bubbleColor = bubbleMat.GetColor("BubbleColor");

        speed = Random.Range(FindObjectOfType<TaskManager_Bubbles>().minSpeed, FindObjectOfType<TaskManager_Bubbles>().maxSpeed);

        FindObjectOfType<TaskManager_Bubbles>().bubblesOnScreen.Add(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        
    }

    void UpdateMovement() 
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            Destroy(gameObject);
            FindObjectOfType<TaskManager_Bubbles>().errors++;
        }
    }
    
    public void Splash() 
    {
        GameObject go = Instantiate(partSystemPrefab, transform.position, Quaternion.identity);
        var main = go.GetComponent<ParticleSystem>().main;
        main.startColor = bubbleColor;
        FindObjectOfType<TaskManager_Bubbles>().totalBubbles++;

    }

    private void OnDestroy()
    {
        FindObjectOfType<TaskManager_Bubbles>().bubblesOnScreen.Remove(gameObject);
    }
}
