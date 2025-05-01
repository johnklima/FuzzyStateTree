using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : State
{

    public walk(Transform _owner)
    {
        text = "Walk";
        owner = _owner;
        represent = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
        represent.name = text;
    }

   

    public override float Process(float dt)
    {
        

        foreach (State child in childStates)
        {
            float ret = child.Process(dt);

            if (ret > 0)
            {
                stateValue = 0;
                return ret;
            }
        }   
                
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

                

        if(Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
        {
            Debug.Log("walk H " + h + " V " + v + " " + text);
            stateValue = 1;
            return stateValue;
        }
        else 
        {
            stateValue = 0;
            return stateValue;
        }
      
    }

}
