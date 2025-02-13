using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(MeshCreator))]
public class MeshEditor : Editor
{
  //  MeshCreator creator;

    private void OnSceneGUI()
    {
      //  if (creator.autoUpdate && Event.current.type == EventType.Repaint)
     //   {
     //       creator.UpdateRoad();
     //   }
    }
    private void OnEnable()
    {
      //  creator = (MeshCreator)target;
    }
}
