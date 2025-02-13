using UnityEngine;
using UnityEngine.UIElements;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] GameObject Ingredient;
    [SerializeField] GameObject positiontospawn;
    Vector3 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
        position = positiontospawn.transform.position;
        Instantiate(Ingredient, new Vector3(position.x, position.y, position.z), Quaternion.identity);
    }
}
