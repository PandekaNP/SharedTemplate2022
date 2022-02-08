using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCoordinates : MonoBehaviour
{
    [SerializeField] GameObject ballA;
    [SerializeField] Text ballXYZ;
    public Rigidbody target;

    InertiaExperimentScript inertiaExp;
    experiment1StartScript exp1Start;
    // Start is called before the first frame update
    void Awake()
    {
        inertiaExp = FindObjectOfType<InertiaExperimentScript>();
        exp1Start = FindObjectOfType<experiment1StartScript>();
        //target = GetComponent<Rigidbody>();
    }

    void GetTargetXYZ()
    {
        ballXYZ.text = $"X:{ballA.transform.position.x:f1}\n" +
            $"Y:{ballA.transform.position.y:f1}\n" +
            $"Z:{ballA.transform.position.z:f1}\n" +
        //$"TForce:{inertiaExp.thrustF:f1}";
        //$"MASS:{experiment1StartScript.massInputInertiaBall1f:f1}";
        $"MASS:{target.mass:f1}";

    }
    // Update is called once per frame
    void Update()
    {
        GetTargetXYZ();
    }
}
