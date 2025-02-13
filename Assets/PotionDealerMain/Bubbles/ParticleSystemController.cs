using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]
    Material mat;

    void Start() 
    {
        mat.color = GetComponent<ParticleSystem>().main.startColor.color;
    }

    private void Update()
    {
        if (GetComponent<ParticleSystem>().isStopped)
            Destroy(gameObject);
    }
}
