using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;

    public LineRenderer _lineR;
    public List<Vector3> linePos = new List<Vector3>();

    public Transform fingerPos;

    public bool isFinished;

    private void Update()
    {
        if (currentLine != null && !isFinished)
            UpdateFingerPos();
    }

    public void CreateLine(Vector3 pos) 
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        isFinished = false;
        _lineR = currentLine.GetComponent<LineRenderer>();
        linePos.Clear();
        linePos.Add(pos);
        linePos.Add(pos);
        _lineR.SetPosition(0, linePos[0]);
        _lineR.SetPosition(1, linePos[1]);
    }

    public void UpdateLine(Vector3 pos) 
    {
        linePos.Remove(linePos[linePos.Count - 1]);
        linePos.Add(pos);
        _lineR.positionCount++;
        _lineR.SetPosition(_lineR.positionCount - 1, pos);
    }

    void UpdateFingerPos() 
    {
        linePos.Add(fingerPos.position);
        _lineR.SetPosition(_lineR.positionCount - 1, fingerPos.position);
    }

    public void DestroyLine() 
    {
        Destroy(currentLine, 0.1f);
    }
}
