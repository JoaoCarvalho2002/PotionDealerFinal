using Unity.VisualScripting;
using UnityEngine;

public class MortarAndPestleScript : MonoBehaviour
{
    [SerializeField] GameObject inputIngredient1;
    [SerializeField] GameObject outputIngrient1;
    [SerializeField] GameObject inputIngredient2;
    [SerializeField] GameObject outputIngrient2;
    [SerializeField] GameObject inputIngredient3;
    [SerializeField] GameObject outputIngrient3;
    [SerializeField] GameObject inputIngredient4;
    [SerializeField] GameObject outputIngrient4;

    [SerializeField] GameObject positiontospawn;

    Vector3 position;
    bool pestle=false;
    bool ingredient=false;
    bool destroyed=false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        { 
        
            pestle=true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            
            ingredient=true;
            CheckEnter(collision);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
        
            ingredient = false;
        }
        if (collision.gameObject.tag == "Finish")
        {
            
            pestle = false;
        }
    }

    private void CheckEnter(Collision collision)
    {
        
        if (destroyed == false)
        {
            if (pestle == true && ingredient == true && collision.gameObject.name=="Heart"|| pestle == true && ingredient == true && collision.gameObject.name == "Heart(Clone)")
            {
                
                pestle = false;
                ingredient = false;
                position = positiontospawn.transform.position;
                Destroy(collision.gameObject);
                destroyed = true;
                Instantiate(outputIngrient1, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                collision = null;
            }
            if (pestle == true && ingredient == true && collision.gameObject.name == "Frog_Leg_Raw" || pestle == true && ingredient == true && collision.gameObject.name == "Frog_Leg_Raw(Clone)")
            {
                
                pestle = false;
                ingredient = false;
                position = positiontospawn.transform.position;
                Destroy(collision.gameObject);
                destroyed = true;
                Instantiate(outputIngrient2, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                collision = null;
            }
            if (pestle == true && ingredient == true && collision.gameObject.name == "Spider.002" || pestle == true && ingredient == true && collision.gameObject.name == "Spider.002(Clone)")
            {

                pestle = false;
                ingredient = false;
                position = positiontospawn.transform.position;
                Destroy(collision.gameObject);
                destroyed = true;
                Instantiate(outputIngrient3, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                collision = null;
            }
            if (pestle == true && ingredient == true && collision.gameObject.name == "Snake_Eye_Raw" || pestle == true && ingredient == true && collision.gameObject.name == "Snake_Eye_Raw(Clone)")
            {

                pestle = false;
                ingredient = false;
                position = positiontospawn.transform.position;
                Destroy(collision.gameObject);
                destroyed = true;
                Instantiate(outputIngrient4, new Vector3(position.x, position.y, position.z), Quaternion.identity);
                collision = null;
            }


        }
        if (destroyed == true)
        {
            destroyed = false;

        }
        
        
    }

}
