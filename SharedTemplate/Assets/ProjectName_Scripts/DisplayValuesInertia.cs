using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayValuesInertia : MonoBehaviour
{
    public static float fApp1, fApp2, mass1, mass2, distance1, distance2, fAcceleration1, fAcceleration2, time1, time2;
    public Text textApp1, textApp2, textMass1, textMass2, textDistance1, textDistance2, textAcceleration1, textAcceleration2, textTime1, textTime2;
    public SubtextScript subtextScript;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name== "DefinitionOfInertiaScene")
        {
            subtextScript.InertiaSubtext1();
        }
    /*    else if (SceneManager.GetActiveScene().name == "3rdLawExperimentTestScene")
        {
            if(this.name== "BallFrictionless1")
            {
                subtextScript.ThirdLawSubtext1();
            }
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        textApp1.text = fApp1.ToString() + "N";
        textApp2.text = fApp2.ToString() + "N";
        textDistance1.text = distance1.ToString("#0.00") + "m";
        textDistance2.text = distance2.ToString("#0.00") + "m";
        textMass1.text = mass1.ToString("#0.00") + "kg";
        textMass2.text = mass2.ToString("#0.00") + "kg";
        textAcceleration1.text = (fApp1 / mass1).ToString("#0.00") + "m/s squared";
        textAcceleration2.text = (fApp2 / mass2).ToString("#0.00") + "m/s squared";
        textTime1.text = time1.ToString("#0.00") + "s";
        textTime2.text = time2.ToString("#0.00") + "s";
    }
}