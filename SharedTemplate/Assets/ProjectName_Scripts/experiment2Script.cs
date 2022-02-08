using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class experiment2Script : MonoBehaviour
{
    public Transform ballTransform;
    public Vector3 ballTransformPosition;
    public Rigidbody ballRigidbody;
    public static float heightF1, heightF2, massF, heightF3;
    public float startDelay = 3.0f;
    public float timerF1 = 0.0f;
    public float timerF2 = 0.0f;
    public float timerF3 = 0.0f;
    public float timerFTest = 0.0f;
    public bool setHeightB = false;
    public bool startExperiment1 = false;
    public bool startExperiment2 = false;
    public bool startExperiment3 = false;
    public float firstQuarterPosY, secondQuarterPosY, thirdQuarterPosY,ballPosY;
    public bool heightCheck1 = false;
    public bool heightCheck2 = false;
    public bool heightCheck3 = false;
    public bool heightCheck4 = false;
    public  bool isBallDropped = false;
    public static bool hasBallImpacted = false;
    public static int experimentCount = 1;
    public SubtextScript SubtextScriptObject;
    //public Text forceMarker1, forceMarker2, forceMarker3, forceMarker4;
    public GameObject firstMarker,ballGameObject,stopGameObject,secondMarker,thirdMarker,impactPoint;
    public Transform dropMechanismStartPos,dropMechanismStopPos;
    public Vector3 dropMechanismStartPosVec;
    public Transform dropMechanismTransform,dropMechanismContainerTransform;
    // Movement speed in units per second.
    public float speed ;
    public static bool HasItBeenRestarted=false;
    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    //Ui Elements for 2nd law
    public  Button StartButton2nd, BackButton2nd, NextButton2nd, ExitButton2nd;
    //Height markers for drop height
    public GameObject HeightMarker1, HeightMarker2, HeightMarker3,MarkerChange,DropMechGO;
    public Text HeightMarkerText1, HeightMarkerText2, HeightMarkerText3;
    public ChangeScene ChangeSceneScript;
    public SubtextScript SubtextScriptObj;
    public VoiceoverControlSCript voiceoverControlSCriptObj;
    public GameObject LoadingSplash;
    public CrateAnimBuild1 crateAnimBuildObj;
    public float NextTimer = 0;
        public bool IsNextPressed=false ;
    // Start is called before the first frame update
    void Start()
    {
        
        
        SubtextScriptObj = GameObject.Find("SubtextCanvas").GetComponent<SubtextScript>();
        //Debug.Log(heightF1.ToString() + heightF2.ToString() + heightF3.ToString());
        //Debug.Log(experiment2Script.experimentCount);
        startExperiment1 = false;
        startExperiment2 = false;
        startExperiment3 = false;
        experimentCount = 1;
        isBallDropped = false;
        dropMechanismStartPosVec = dropMechanismTransform.position;
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(dropMechanismStartPos.position, dropMechanismStopPos.position);
        //SubtextScriptObj.SecondLawExperiment1stSubText();

        if (experiment1StartScript.heightInput1F1 != 0)
        {
            heightF1 = experiment1StartScript.heightInput1F1;
        } 
        else
        {
            heightF1 = 15;
        }
        if (experiment1StartScript.heightInput1F2 != 0)
        {
            heightF2 = experiment1StartScript.heightInput1F2;
        }
        else
        {
            heightF2 = 10;
        }
        if (experiment1StartScript.heightInput1F3 != 0)
        {
            heightF3 = experiment1StartScript.heightInput1F3;
        }
        else
        {
            heightF3 = 5;
        }
        massF = experiment1StartScript.massInputFirstLawF;
        ballTransformPosition = ballTransform.position;
        ballTransformPosition.y = heightF1;
        ballRigidbody.mass = massF;
        
        ballTransform.localPosition = new Vector3(0, heightF1, 0);
        dropMechanismContainerTransform.localPosition = new Vector3(dropMechanismContainerTransform.localPosition.x,heightF1,dropMechanismContainerTransform.localPosition.z);
        

    }

    private void Awake()
    {
        
    }
    public void PlayNextExperiment()
	{
        if (IsNextPressed==false)
        {

        
        CrateAnimBuild1.resetB = true;
        if (experimentCount==3)
        {
            ChangeSceneScript.SetUI("SelectLawCanvas");
            ChangeSceneScript.SceneLoaderName("UIScene");
        }
            IsNextPressed = true;
        }
    }
    
    public void ResetExperiment()
    {
        experiment1StartScript.HasSecondLawBenRestarted = true;
         experimentCount = 1;
         startExperiment1 = false;
         startExperiment2 = false;
         startExperiment3 = false;
         isBallDropped = false;
         CrateAnimBuild1.resetB = true;
         CrateAnimBuild1.experimentCountCraterBuild = 1;
         hasBallImpacted = false;
         DropMechGO.SetActive(true);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }    
    // Update is called once per frame
    void Update()
    {
        if (IsNextPressed)
        {
            NextTimer += Time.deltaTime;
            if (NextTimer>3)
            {
                IsNextPressed = false;
            }
        }
        if (experiment1StartScript.HasSecondLawBenRestarted)
        {
            SubtextScriptObj.LoadingScreenDelay = false;
            
            voiceoverControlSCriptObj.UnmuteVoiceOvers();
            LoadingSplash.SetActive(false);
           // SubtextScriptObj.SecondLawExperiment1stSubText();
            experiment1StartScript.HasSecondLawBenRestarted = false;
       
        }
        
        
        if (isBallDropped == true)
        {
          
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            while (dropMechanismTransform.position != dropMechanismStartPos.position)
            {
                dropMechanismTransform.position = Vector3.Lerp(dropMechanismStartPos.position, dropMechanismStopPos.position, fractionOfJourney);
            }
            if (dropMechanismTransform.position==dropMechanismStopPos.position)
            {
               isBallDropped = false;
               
            }
        } 
        ballPosY = ballTransform.localPosition.y;
        
        if (startExperiment1 && experimentCount==1)
        {
          
                timerF1 += Time.deltaTime;
            if (timerF1 > startDelay)
            {
                ballRigidbody.useGravity = true;
                isBallDropped = true;
                startTime = Time.time;
            
                if (ballPosY <= 0)
                {
                  
                    hasBallImpacted = true;
                }
            } 
        }
        if ( experimentCount == 2)
        {
            
            timerF2 += Time.deltaTime;
            if (timerF2 > startDelay)
            {
                ballRigidbody.useGravity = true;
                isBallDropped = true;
                startTime = Time.time;
                
                if (ballPosY <= 0 )
                {
                   
                    hasBallImpacted = true;
                }
            }
        }
        if ( experimentCount == 3)
        {
           
            timerF3 += Time.deltaTime;
            if (timerF3 > startDelay)
            {
                ballRigidbody.useGravity = true;
                isBallDropped = true;
                startTime = Time.time;
                
                if (ballPosY <= 0)
                {
                   
                    hasBallImpacted = true;
                    DropMechGO.SetActive(false);
                    SubtextScriptObj.SecondLawExperimentObservation();
                    StartButton2nd.gameObject.SetActive(false);
                    ExitButton2nd.gameObject.SetActive(true);
                    BackButton2nd.gameObject.SetActive(true);
                    NextButton2nd.gameObject.SetActive(false);
                    experimentCount = 4;
                }
            }
        }
        
    }

    public void startExperimentMethod()
    {

        
        hasBallImpacted = false;

        StartButton2nd.gameObject.SetActive(false);
        ExitButton2nd.gameObject.SetActive(false);
        BackButton2nd.gameObject.SetActive(false);

        if (experimentCount == 1)
        {
            DisplayValues.force1 = 0;
            //Debug.Log(experimentCount.ToString());
           

            ballRigidbody.useGravity = false;
            startExperiment1 = true;
            ballTransform.localPosition = new Vector3(0, heightF1, 0);
            //dropMechanismTransform.position = dropMechanismStartPos.position;
            dropMechanismContainerTransform.localPosition = new Vector3 (dropMechanismContainerTransform.localPosition.x,heightF1,dropMechanismContainerTransform.localPosition.z);            
            ballRigidbody.velocity = new Vector3(0, 0, 0);
            
           
        }
        if (experimentCount == 2 )
        {
            DisplayValues.force2 = 0;
            ballRigidbody.velocity = new Vector3(0, 0, 0);
            //Debug.Log(experimentCount.ToString());
            ballRigidbody.useGravity = false;
            startExperiment2 = true;
            ballTransform.localPosition = new Vector3(0, heightF2, 0);
            
            dropMechanismContainerTransform.localPosition = new Vector3(dropMechanismContainerTransform.localPosition.x, heightF2, dropMechanismContainerTransform.localPosition.z);
            

            
        }
        if (experimentCount == 3)
        {
            DisplayValues.force3 = 0;
            //Debug.Log(experimentCount.ToString());
            ballRigidbody.velocity = new Vector3(0, 0, 0);
            ballRigidbody.useGravity = false;
            startExperiment3 = true;
            ballTransform.localPosition = new Vector3(0, heightF3, 0);
            
            dropMechanismContainerTransform.localPosition = new Vector3(dropMechanismContainerTransform.localPosition.x, heightF3, dropMechanismContainerTransform.localPosition.z);
            

           
            NextButton2nd.gameObject.SetActive(true);
            BackButton2nd.gameObject.SetActive(false);
            ExitButton2nd.gameObject.SetActive(false);
            StartButton2nd.gameObject.SetActive(false);
        }
    }
}
