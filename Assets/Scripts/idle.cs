using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : State
{
    public idle(Transform _owner)
    {
        text = "Idle";
        owner = _owner;
        
    }

 


    public override float Process(float dt)
    {
       
        
        foreach (State child in childStates)
        {
            float ret = child.Process(dt);

            if(ret > 0 )
            {
                stateValue = 0;
                return ret;
            }            

        }

        //if no child states are true, I can only be idle
        Debug.Log("I'm idle");
        stateValue = 1;
        return stateValue;


    }
}
