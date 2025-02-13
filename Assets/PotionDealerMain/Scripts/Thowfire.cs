using UnityEngine;

public class Thowfire : MonoBehaviour
{
    [SerializeField] GameObject fireLeft;
    [SerializeField] GameObject fireRight;
    [SerializeField] GameObject fireweak;
    [SerializeField] GameObject firestrong;

    public bool fireleftbool = false;
    public bool firerightbool = false;
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "FireLeft")
        {
            fireleftbool=true;
            CHANGEfire();


        }
        if (collision.gameObject.tag == "FireRight")
        {
            firerightbool = true;
            CHANGEfire();
        } 

    }

    public void CHANGEfire()
    {
         if (fireleftbool == true || firerightbool == true)
         {
            fireweak.SetActive(true);
            firestrong.SetActive(false);
            if (fireleftbool == true && firerightbool == true)
            {
                fireweak.SetActive(false);
                firestrong.SetActive(true);
                

            }
         }
    }

}
