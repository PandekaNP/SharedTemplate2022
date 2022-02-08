using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator wire;
    public bool AnimOn;
   
  

    void Start()
    {
       // wire=GetComponent<Animator>();
         AnimOn=false;

    }


    public void wireOn()
    {
 /*
        if(AnimOn)
        {
       wire.enabled=false;
       wire.enabled=true;
        wire.Play("Demo Room Test");
        AnimOn=false;

        Debug.Log("unclicked"); 
        }

         */
       
    }


    public void BoolControl()
    {
        AnimOn=true;
        Debug.Log("clicked");
    }

    // Update is called once per frame
    void Update()
    {
        if(AnimOn){
        wire.Play("Demo Room Test");
        AnimOn=false;
        Debug.Log("Unclicked");
   }

}
}
