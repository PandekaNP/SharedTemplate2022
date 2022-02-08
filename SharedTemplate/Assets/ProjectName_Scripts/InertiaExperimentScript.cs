using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaExperimentScript : MonoBehaviour
{
    private const int ADDEDWEIGHT = 50;
    public int ThrustFactor;
    public Rigidbody objRigidbody;
    Vector3 StartPos, CurrentPos;
    public Transform objTransform;
    public float thrustF = 20f;
    experiment1StartScript InputScript;
    public Vector3 BallStartPos, BallStartRot;


    // Start is called before the first frame update
    void Start()
    {
        //tests
        ThrustFactor = 1;
        //get variables from scripts container in input scene

        objTransform = GetComponent<Transform>();
        objRigidbody = GetComponent<Rigidbody>();
        thrustF = experiment1StartScript.forceInputInertiaf* ThrustFactor;
        if (thrustF==0)
        {
            thrustF = 1000;
        }
        DisplayValuesInertia.distance1 = 0;
        DisplayValuesInertia.distance2 = 0;
        StartPos = objTransform.position;
        BallStartPos = objTransform.position;
       
    }
    public void ResetBall()
    {
        objRigidbody.isKinematic = true;
        objTransform.position = BallStartPos;
        objTransform.eulerAngles = new Vector3(0, -90, 0);
        DisplayValuesInertia.time1 = 0;
        DisplayValuesInertia.time2 = 0;

    }
    private void OnCollisionEnter(Collision collision)
    {

        objRigidbody.velocity = Vector3.zero;
    }
    private void FixedUpdate()
    {
        CurrentPos = objTransform.position;
       
        DisplayValuesInertia.fApp1 = thrustF;
        DisplayValuesInertia.fApp2 = thrustF;
        if (this.name == "BallFrictionless1")
        {
            DisplayValuesInertia.mass1 = experiment1StartScript.massInputInertiaBall1f;
            DisplayValuesInertia.distance1 = Vector3.Distance(StartPos, CurrentPos);
            if (objRigidbody.velocity.magnitude>0.1f)
            {
                DisplayValuesInertia.time1 += Time.deltaTime;
            }

        }
        else if (this.name == "BallFrictionless2")
        {
            DisplayValuesInertia.mass2 = experiment1StartScript.massInputInertiaBall2f;
            DisplayValuesInertia.distance2 = Vector3.Distance(StartPos, CurrentPos);
           
            if (objRigidbody.velocity.magnitude>0.1f)
            {
                DisplayValuesInertia.time2 += Time.deltaTime;
            }
        }
        
    }

    public void PushBallInertia()
    {
        objRigidbody.isKinematic = false;
        if (this.name=="BallFrictionless1")
        {
            objRigidbody.mass = experiment1StartScript.massInputInertiaBall1f + ADDEDWEIGHT;
        } else if (this.name == "BallFrictionless2")
        {
            objRigidbody.mass = experiment1StartScript.massInputInertiaBall2f + ADDEDWEIGHT;
        }
        if (objRigidbody.mass==0)
        {
            objRigidbody.mass = 1;
        }

        objRigidbody.AddForce(transform.forward * thrustF);
    }
    
}
