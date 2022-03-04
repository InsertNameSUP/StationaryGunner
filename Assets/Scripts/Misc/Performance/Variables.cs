using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    object checkVariable;
    object oldVarVal;
    // Start is called before the first frame update
    void Start()
    {
        
    } 
    public void OnChange<T>(ref T variable)
    {
        checkVariable = variable;
        oldVarVal = checkVariable;
    }
    // Update is called once per frame
    void Update()
    {
        print(oldVarVal + "||" + checkVariable);
        if(checkVariable != oldVarVal)
        {
            print("testing");
        }
        oldVarVal = checkVariable;
    }
}
