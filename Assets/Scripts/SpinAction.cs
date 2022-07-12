using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : MonoBehaviour
{

    private bool startSpinning = false;

    private void Update() 
    {
        if(startSpinning)
        {
            float spinAddAmount = 360f * Time.deltaTime;
            transform.eulerAngles += new Vector3(0, spinAddAmount, 0);
        }
    }
    
    public void Spin()
    {
        startSpinning = true;
    }
}
