using UnityEngine;
using System.Collections;
public class PlayAnimation : MonoBehaviour
{
    [SerializeField]private Animator anim;
    private void Start()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag=="Client")
       {
            anim.SetTrigger("trigger1");
          
        }
        
    }
    

}
