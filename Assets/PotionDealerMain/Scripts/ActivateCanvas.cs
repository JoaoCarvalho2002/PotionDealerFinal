using Unity.VisualScripting;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ActivateCanvas : MonoBehaviour
{
    [SerializeField] GameObject canvas;

    [SerializeField] public GameObject thisthing;
    public ClientRequest request;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClientRequest request = thisthing.GetComponent<ClientRequest>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActeCanvas()
    {
     
       
        request.clientarrives = true;
        canvas.SetActive(true);
    }

}
