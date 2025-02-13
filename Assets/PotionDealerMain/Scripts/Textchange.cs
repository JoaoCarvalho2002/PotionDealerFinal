using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Textchange : MonoBehaviour
{
    [SerializeField] ClientRequest totalnumberofclients;
    public TMP_Text text;
    [SerializeField] GameObject Endgame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClientRequest request = totalnumberofclients.GetComponent<ClientRequest>();

        text.text = request.totalclients;
        if (text.text == "3")
        {
            Endgame.SetActive(true);
        }
    }
}
