using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class experiment1StartScript : MonoBehaviour
{
    
    public Text forceInput,massInputFirstLaw, massInputSecondLaw, heightInput1, heightInput2, heightInput3,forceInputThirdLawText,massInputThirdLawBallText1, massInputThirdLawBallText2,massInputInertiaBall1, massInputInertiaBall2,forceInputInertia;
    public static float forceInputF, massInputFirstLawF, massInputSecondLawF, heightInput1F1, heightInput1F2, heightInput1F3,forceInputThirdLawf,massInputThirdLawBall1f, massInputThirdLawBall2f, massInputInertiaBall1f, massInputInertiaBall2f, forceInputInertiaf;
    public static bool isExperimentFrictionless=true;
    public static bool IsFirstLaw, IsSecondLaw,IsThirdLaw,IsDefinitionOfInertia;
    public bool is1,is2,is3,isDI;
    public static int RunOnce = 0;
    public static bool HasSecondLawBenRestarted = false;
    // Start is called before the first frame update
    void Start()
    {
        RunOnce = 0;
        if (massInputThirdLawBall1f==0)
        {
            massInputThirdLawBall1f = 1.0f;
        }
        if (massInputThirdLawBall2f == 0)
        {
            massInputThirdLawBall2f = 1.0f;
        }
        forceInputThirdLawf = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsThirdLaw)
        {
            if (RunOnce==0)
            {
                if (IsThirdLaw)
                {
                    
                    forceInputThirdLawText.text = (forceInputThirdLawf).ToString() + "kN";
                    
                    RunOnce = 1;
                }
            }
            if (forceInputThirdLawText!=null)
            {
                forceInputThirdLawText.text = (forceInputThirdLawf).ToString() + "kN";
            }
            if (massInputThirdLawBallText1!=null)
            {
                massInputThirdLawBallText1.text = massInputThirdLawBall1f.ToString() + "kg";
            }
            if (massInputThirdLawBallText2!=null)
            {
                massInputThirdLawBallText2.text = massInputThirdLawBall2f.ToString() + "kg";
            }
        }
        if (IsFirstLaw)
        {
            if (RunOnce == 0)
            {
                if (IsFirstLaw)
                {
                    forceInputF = 1.0f;
                    forceInput.text = (forceInputF).ToString() + "kN";
                    massInputFirstLawF = 1.0f;
                    RunOnce = 1;
                }
            }
            if (forceInput != null)
            {
                //forceInputF = float.Parse(forceInput.text);
                forceInput.text = (forceInputF).ToString() + "kN";
            }
            if (massInputFirstLaw != null)
            {
                //massInputF = float.Parse(massInput.text);
                massInputFirstLaw.text = massInputFirstLawF.ToString() + "kg";
            }
        }
        if (IsSecondLaw)
        {
            if (RunOnce == 0)
            {
                if (IsSecondLaw)
                {
                    massInputSecondLawF = 1.0f;
                    heightInput1F1 = 15.0f;
                    heightInput1F2 = 10.0f;
                    heightInput1F3 = 5.0f;
                    forceInputF = 1.0f;
                    RunOnce = 1;
                }
            }
            if (massInputSecondLaw != null)
            {
                //massInputF = float.Parse(massInput.text);
                massInputSecondLaw.text = massInputSecondLawF.ToString() + "kg";
            }
            if (heightInput1 != null)
            {
                heightInput1.text = heightInput1F1.ToString() + "m";
            }
            if (heightInput2 != null)
            {
                heightInput2.text = heightInput1F2.ToString() + "m";
            }
            if (heightInput3 != null)
            {
                heightInput3.text = heightInput1F3.ToString() + "m";
            }
        }
        if(IsDefinitionOfInertia)
        {
            if (RunOnce==0)
            {
                massInputInertiaBall1f = 1.0f;
                massInputInertiaBall2f = 2.0f;
                forceInputInertiaf = 1.0f;
                RunOnce = 1;
                
            }
            if (massInputInertiaBall1!=null)
            {
                massInputInertiaBall1.text = massInputInertiaBall1f.ToString() + "kg";
            }
            if (massInputInertiaBall2 != null)
            {
                massInputInertiaBall2.text = massInputInertiaBall2f.ToString() + "kg";
            }
            if (forceInputInertia != null)
            {
                forceInputInertia.text = forceInputInertiaf.ToString() + "kN";
            }
        }
    }

    public void removeFrictionFromExperiment()
    {
        isExperimentFrictionless = true;
    }
    public void applyFrictionToExperiment()
    {
        isExperimentFrictionless = false;
    }
    public void addForce()
    {
        forceInputF += 1;
    }
    public void addForceThirdLaw()
    {
        forceInputThirdLawf += 1;
    }
    public void subtractForce()
    {
        forceInputF -= 1;
    }
    public void subtractForceThirdLaw()
    {
        forceInputThirdLawf -= 1;
    }
    public void addMass()
    {
        massInputFirstLawF += 1;
    }
    public void addMassThirdLawBall1()
    {
        massInputThirdLawBall1f += 1;
    }
    public void addMassThirdLawBall2()
    {
        massInputThirdLawBall2f += 1;
    }
    public void subtractMass()
    {
        massInputFirstLawF -= 1;
    }
    public void subtractMassThirdLawBall1()
    {
        massInputThirdLawBall1f -= 1;
    }
    public void subtractMassThirdLawBall2()
    {
        massInputThirdLawBall2f -= 1;
    }
    public void addHeight(int heightIndex)
    {
        if (heightIndex == 1)
        {
            heightInput1F1 += 1;
            heightInput1.text = heightInput1F1.ToString() + "m";
        } 
        else
            if (heightIndex == 2)
        {
            heightInput1F2 += 1;
            heightInput2.text = heightInput1F2.ToString() + "m";
        }
        else
            if (heightIndex == 3)
        {
            heightInput1F3 += 1;
            heightInput3.text = heightInput1F3.ToString() + "m";
        }
  
    }
    public void subtractheight(int heightIndex)
    {
        if (heightIndex == 1)
        {
            heightInput1F1 -= 1;
        }
        else
            if (heightIndex == 2)
        {
            heightInput1F2 -= 1;
        }
        else
            if (heightIndex == 3)
        {
            heightInput1F3 -= 1;
        }
    }
    public void AddForceInertia()
    {
        forceInputInertiaf += 1;
    }
    public void SubtractForceInertia()
    {
        forceInputInertiaf -= 1;
    }
    public void addMassInertia1()
    {
        massInputInertiaBall1f += 1;
    }
    public void addMassInertia2()
    {
        massInputInertiaBall2f += 1;
    }
    public void subtractMassInertia1()
    {
        massInputInertiaBall1f -= 1;
    }
    public void subtractMassInertia2()
    {
        massInputInertiaBall2f -= 1;
    }
}

