using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;
public class ClientRequest : MonoBehaviour
{
    [SerializeField] public GameObject potion1;
    [SerializeField] public GameObject potion2;
    [SerializeField] public GameObject potion3;
    [SerializeField] public GameObject potion4;

    [SerializeField] GameObject canvas1;

    [SerializeField] Animator animator;
    [SerializeField] GameObject walkingdude;
    

    GameObject rugOfDelivery;
    string hoje;
    string requestedpotion;

    RawImage potionimage1;

    Vector3 positionguy;

    public Texture PotionTexture1;
    public Texture PotionTexture2;
    public Texture PotionTexture3;
    public Texture PotionTexture4;

    [SerializeField] GameObject completeparticle;
    GameObject potionrequestedobj;

    AudioSource hello;

    public string totalclients="";
    public int numberOfClients = 0;

    [SerializeField] GameObject rawimage;
    int number;
    public bool clientarrives = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        hello = GetComponent<AudioSource>();
        //clientarrives = true;
        potionimage1 = (RawImage)rawimage.GetComponent<RawImage>();
        Transform walkguy = walkingdude.gameObject.GetComponent<Transform>();
        Vector3 positionguy = walkguy.transform.position;
        


    }

    // Update is called once per frame
    void Update()
    {
        ClientArrives();
        
    }
    private void ClientArrives()
    {
        if (clientarrives == true)
        {
           
            PotionList();
            clientarrives = false;
            completeparticle.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == potion1.gameObject.tag)
        {
            hoje = other.gameObject.tag;

          
        }
        if (other.gameObject.tag == potion2.gameObject.tag)
        {
            hoje = other.gameObject.tag;
 
           
        }
        if (other.gameObject.tag == potion3.gameObject.tag)
        {
            hoje = other.gameObject.tag;
 
           
        }
        if (other.gameObject.tag == potion4.gameObject.tag)
        {
            hoje = other.gameObject.tag;
    
        }
        potionrequestedobj = other.gameObject;
    }
    private void PotionList()
    {

        number =Random.Range(1, 5);
        if(number == 1)
        {
            //potion1;
            Debug.Log("1");
            potionimage1.texture = (Texture)PotionTexture1;
            requestedpotion = "FinalRed";
            canvas1.SetActive(false);




        }
        if (number == 2)
        {
            //  potion2;
            Debug.Log("2");
            potionimage1.texture = (Texture)PotionTexture2;
            requestedpotion = "FinalBlue";
            canvas1.SetActive(false);

        }
        if (number == 3)
        {
            //potion3;
            Debug.Log("3");
            potionimage1.texture = (Texture)PotionTexture3;
            
            requestedpotion = "FinalGreen";
            canvas1.SetActive(false);

        }
        if (number == 4)
        {
            //potion3;
            Debug.Log("4");
            potionimage1.texture = (Texture)PotionTexture4;
            requestedpotion = "FinalBrown";
            canvas1.SetActive(false);

        }
        canvas1.SetActive(true);
    }
    public void CheckItem()
    {
        if (hoje == requestedpotion && requestedpotion!=null && hoje!=null)
        {

            
            completeparticle.SetActive(true);
            hello.Play(0);
            ResetRequest();
            numberOfClients = numberOfClients + 1;
            
            totalclients = numberOfClients.ToString();
           

        }

    }
    public void ReadString()
    {

    }
    public void ResetRequest()
    {
        Destroy(potionrequestedobj);
        
        Animator anim = animator.gameObject.GetComponent<Animator>();
        walkingdude.transform.position = positionguy;
        hoje = null;
        requestedpotion = null;
        anim.Rebind();
        anim.Update(0f);
        potionimage1.texture = null;
        canvas1.SetActive(false);
        number = 0;
        clientarrives = false;
        ClientArrives();

        
    }
}
