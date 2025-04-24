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
        Debug.Log(text);
        foreach (State child in childStates)
        {
            float ret = child.Process(dt);

            if(ret > 0 )
            {
                return 0;
            }
            else 
            {
                Debug.Log("I'm idle");
                return 1;
            }
            

        }
        return 0;
    }
}
