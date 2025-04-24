using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : State
{
    public dead(Transform _owner)
    {
        text = "Dead";
        owner = _owner;

    }

  

    public override float Process(float dt)
    {
        Debug.Log(text);
        foreach (State child in childStates)
        {
            float ret = child.Process(dt);
            return ret;

        }
        return 0;
    }
}
