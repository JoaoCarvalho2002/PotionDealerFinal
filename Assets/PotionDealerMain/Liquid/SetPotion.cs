using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPotion : MonoBehaviour
{
    public string potionName;
    public Color sideColor;
    public Color topColor;

    public Gradient grad;

    public Material liquidMat;
    public Renderer rend;

    [SerializeField]
    float initialFill;

    [Range(0.476f, 0.516f)] //fill slider on shader
    float fill;

    public bool isEmpty = false;

    [HideInInspector]
    public bool isHittingCauldron;

    public Transform spawn;

    [SerializeField]
    PotionsController potCont;

    private void Start()
    {
        potCont = GetComponent<PotionsController>();
        SetupTask();
    }
    public void SetupTask()
    {
        rend = GetComponentInChildren<Wobble>().gameObject.GetComponent<Renderer>();
        liquidMat.SetColor("_SideColor", sideColor);
        liquidMat.SetColor("_TopColor", topColor);
        liquidMat.SetFloat("_FillAmount", initialFill);
        rend.material.SetFloat("_FillAmount", initialFill);
        fill = initialFill;
    }

    private void Update()
    {
            if (GetComponent<LiquidPouringController>().isPouring)
            {
                fill -= Time.deltaTime / 1000;
                rend.material.SetFloat("_FillAmount", fill);
            }

            if (fill <= 0.476f)
                isEmpty = true;
    }

}
