using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidStream : MonoBehaviour
{
    private LineRenderer lineR = null;
    private ParticleSystem splashPart;

    private Coroutine pourRoutine;

    private Vector3 targetPos = Vector3.zero;
    public bool isdropping = false;

    private void Awake()
    {
        lineR = GetComponent<LineRenderer>();
        lineR.startColor = GetComponentInParent<SetPotion>().topColor;
        lineR.endColor = GetComponentInParent<SetPotion>().sideColor;
        lineR.colorGradient = GetComponentInParent<SetPotion>().grad;

        splashPart = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        MoveToPos(0, transform.position);
        MoveToPos(1, transform.position);
    }
    private void FixedUpdate()
    {
        if(FindObjectOfType<PotionsTaskManager>() != null)
            CheckPosition();
    }
    public void Begin()
    {
        StartCoroutine(BeginPour());
        pourRoutine = StartCoroutine(UpdateParticle());
    }


    IEnumerator BeginPour()
    {
        while (gameObject.activeSelf) 
        {
            targetPos = FindEndPoint();

            MoveToPos(0, transform.position);
            AnimateToPosition(1, targetPos);

            yield return null;
        }
        
    }

    public void End() 
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    IEnumerator EndPour() 
    {
        while (!HasReachedPosition(0, targetPos))
        {
            AnimateToPosition(0, targetPos);
            AnimateToPosition(1, targetPos);

            yield return null;
        }
    }

    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2);

        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

        return endPoint;
    }

    void CheckPosition()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.transform.tag == "Cauldron")
            {    

                GetComponentInParent<SetPotion>().isHittingCauldron = true;
                isdropping = true;
                //FindObjectOfType<PotionMaker>().Check1();
                FindObjectOfType<LiquidPouringController>().CreateStream(gameObject.transform.parent.tag);
            }
            else
                GetComponentInParent<SetPotion>().isHittingCauldron = false;

        }
    }

    private void MoveToPos(int index, Vector3 targetPos) 
    {
        lineR.SetPosition(index, targetPos);
    }

    private void AnimateToPosition(int index, Vector3 targetPos) 
    {
        Vector3 currentPoint = lineR.GetPosition(index);
        Vector3 newPos = Vector3.MoveTowards(currentPoint, targetPos, Time.deltaTime * 1.75f);
        lineR.SetPosition(index, newPos);
    }

    bool HasReachedPosition(int index, Vector3 targetPos) 
    {
        Vector3 currentPos = lineR.GetPosition(index);
        return currentPos == targetPos;
    }

    IEnumerator UpdateParticle() 
    {
        while (gameObject.activeSelf)
        {
            var main = splashPart.main;
            main.startColor = GetComponentInParent<SetPotion>().sideColor;
            splashPart.gameObject.transform.position = targetPos;
            //Instantiate(ripplePart, targetPos, Quaternion.identity);
            bool isHitting = HasReachedPosition(1, targetPos);
            splashPart.gameObject.SetActive(isHitting);

            yield return null;
        }
    }
}
