using UnityEngine;

public class TransportLiquid : MonoBehaviour
{
    GameObject CurrentLiquid;
    [SerializeField] GameObject LiquidRed;
    [SerializeField] GameObject LiquidPurple;
    [SerializeField] GameObject LiquidGreen;
    [SerializeField] GameObject LiquidWhite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LiquidRed")
        {
            LiquidRed.SetActive(true);
            Destroy(collision.gameObject);

        }
    }
}
