using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class PotionMaker : MonoBehaviour
{
    GameObject inputIngredient1;
    GameObject inputIngredient2;
    GameObject inputIngredient3;
    GameObject inputIngredient4;

    GameObject inputIngredient5;
    GameObject inputIngredient6;
    GameObject inputIngredient7;
    GameObject inputIngredient8;
    [SerializeField] GameObject potion1;
    [SerializeField] GameObject potion2;
    [SerializeField] GameObject potion3;
    [SerializeField] GameObject potion4;
    [SerializeField] GameObject fireRed;
    [SerializeField] GameObject fireBlue;
    [SerializeField] GameObject anchor;
    [SerializeField] GameObject fireweak;
    [SerializeField] GameObject firestrong;
    [SerializeField] GameObject tempfire;
    public Thowfire thowfire;
    Vector3 position;
    bool red = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LovePotion(GameObject inputIngredient8, GameObject inputIngredient1, GameObject inputIngredient2, bool red)
    {
        
        Destroy(inputIngredient8);
        Destroy(inputIngredient2);
        Destroy(inputIngredient1);
        position = anchor.transform.position;
        Instantiate(potion1, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        inputIngredient8 = null;
        inputIngredient2 = null;
        inputIngredient1 = null;
        red = false;
        fireweak.SetActive(false);
        firestrong.SetActive(false);
        thowfire.fireleftbool = false;
        thowfire.firerightbool = false;
    }
    private void VisionPotion(GameObject inputIngredient7, GameObject inputIngredient6, GameObject inputIngredient2, bool red)
    {
        
        Destroy(inputIngredient7);
        Destroy(inputIngredient6);
        Destroy(inputIngredient2);
        position = anchor.transform.position;
        Instantiate(potion2, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        inputIngredient7 = null;
        inputIngredient6 = null;
        inputIngredient2 = null;
        red = false;
        fireweak.SetActive(false);
        firestrong.SetActive(false);
        thowfire.fireleftbool = false;
        thowfire.firerightbool = false;
    }
    private void JumpPotion(GameObject inputIngredient5, GameObject inputIngredient7, GameObject inputIngredient3, GameObject inputIngredient4, bool red)
    {

        Destroy(inputIngredient5);
        Destroy(inputIngredient7);
        Destroy(inputIngredient3);
        Destroy(inputIngredient4);
        position = anchor.transform.position;
        Instantiate(potion3, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        inputIngredient5 = null;
        inputIngredient7 = null;
        inputIngredient3 = null;
        inputIngredient4 = null;
        red = false;
        fireweak.SetActive(false);
        firestrong.SetActive(false);
        thowfire.fireleftbool = false;
        thowfire.firerightbool = false;
    }
    private void StrenghtPotion(GameObject inputIngredient5, GameObject inputIngredient7, GameObject inputIngredient6, GameObject inputIngredient8, GameObject inputIngredient1, GameObject inputIngredient4, bool red)
    {

        Destroy(inputIngredient5);
        Destroy(inputIngredient7);
        Destroy(inputIngredient6);
        Destroy(inputIngredient8);
        Destroy(inputIngredient1);
        Destroy(inputIngredient4);
        position = anchor.transform.position;
        Instantiate(potion4, new Vector3(position.x, position.y, position.z), Quaternion.identity);
        inputIngredient5 = null;
        inputIngredient7 = null;
        inputIngredient6 = null;
        inputIngredient8 = null;
        inputIngredient1 = null;
        inputIngredient4 = null;
        red = false;
        fireweak.SetActive(false);
        firestrong.SetActive(false);
        thowfire.fireleftbool = false;
        thowfire.firerightbool = false;
    }
    //OnTriggerEnter
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "HeartSmashed")
        {
            inputIngredient1 = other.gameObject;

        }
        
        if (other.gameObject.tag == "EyeSmashed")
        {
            inputIngredient2 = other.gameObject;

        }
        
        if (other.gameObject.tag == "FrogSmashed")
        {
            inputIngredient3 = other.gameObject;

        }
        if (other.gameObject.tag == "SpiderSmashed" )
        {
            inputIngredient4 = other.gameObject;

        }

        if (other.gameObject.tag == "LiquidBlue" )
        {
            inputIngredient5 = other.gameObject;

        }

        if (other.gameObject.tag == "LiquidPurple")
        {
            inputIngredient6 = other.gameObject;

        }
        if (other.gameObject.tag == "LiquidYellow")
        {
            inputIngredient7 = other.gameObject;

        }

        if (other.gameObject.tag == "LiquidWhite")
        {
            inputIngredient8 = other.gameObject;

        }


        //if fire is red
        if (inputIngredient7 != null && inputIngredient6 != null && inputIngredient2 != null && fireRed.activeInHierarchy)
        {

            VisionPotion(inputIngredient7, inputIngredient6, inputIngredient2, red = true);

        }


        if (inputIngredient5 != null && inputIngredient7 != null && inputIngredient3 != null && inputIngredient4 != null && fireRed.activeInHierarchy)
        {

            JumpPotion(inputIngredient5, inputIngredient7, inputIngredient3, inputIngredient4, red = true);

        }
        //if fire is blue
        if (inputIngredient8 != null && inputIngredient1!= null && inputIngredient2 != null && fireBlue.activeInHierarchy)
        {
           
            LovePotion(inputIngredient8, inputIngredient1, inputIngredient2, red = false);

        }
        if (inputIngredient5 != null && inputIngredient7 != null && inputIngredient6 != null && inputIngredient8 != null && inputIngredient1 != null && inputIngredient4 != null && fireBlue.activeInHierarchy)
        {

            StrenghtPotion(inputIngredient5, inputIngredient7, inputIngredient6, inputIngredient8, inputIngredient1, inputIngredient4, red = false);

        }

    }
   

    public void ResetCooking()
    {
        Thowfire thowfire = tempfire.GetComponent<Thowfire>();
        Destroy(inputIngredient1);
        Destroy(inputIngredient2);
        Destroy(inputIngredient3);
        Destroy(inputIngredient4);
        Destroy(inputIngredient5);
        Destroy(inputIngredient6);
        Destroy(inputIngredient7);
        Destroy(inputIngredient8);
        inputIngredient1 = null;
        inputIngredient2 = null;
        inputIngredient3 = null;
        inputIngredient4 = null;
        inputIngredient5 = null;
        inputIngredient6 = null;
        inputIngredient7 = null;
        inputIngredient8 = null;
        red = false;
        fireweak.SetActive(false); 
        firestrong.SetActive(false);
        thowfire.fireleftbool = false;
        thowfire.firerightbool = false;


    }

    
}
