using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndStop : MonoBehaviour
{
    Vector3 savedVelocity;
    Vector3 savedAngularVelocity;
    public Rigidbody Freeze_sphere;
    public JetFlyCsv Freeze_jet;
    Boolean check = true;

    //By pressing the button we will stop the time and with another press we will continue from the time we stopped
    public void On_Click()
    {
        Freeze_jet.enabled = !Freeze_jet.enabled;
        if (check)
        {
            savedVelocity = Freeze_sphere.velocity;
            Freeze_sphere.isKinematic = true;
            check = false;
        }
        else
        {
            Freeze_sphere.isKinematic = false;
            Freeze_sphere.AddForce(savedVelocity, ForceMode.VelocityChange);
            check = true;
        }
    }

 

}
