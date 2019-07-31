﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor((typeof(FieldOfView)))]
public class FOV_Editor : Editor
{
    void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        //show the view radius in the editor
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius);

        //draw the view angle in the editor
        Handles.color = Color.white;
        Vector3 viewAngle_A = fov.AngleToTarget(-fov.viewAngle / 2, false);
        Vector3 viewAngle_B = fov.AngleToTarget(fov.viewAngle / 2, false);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle_A * fov.viewRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle_B * fov.viewRadius);

        //draw the raycast line
        Handles.color = Color.red;
        foreach (Transform visibleTargets in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTargets.position);
        }
    }
}
