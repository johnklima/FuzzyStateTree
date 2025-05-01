using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : State
{
    public dead(Transform _owner)
    {
        text = "Dead";
        owner = _owner;
        represent = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
        represent.name = text;

    }

    public int health = 100; 

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
        if (health <= 0)
            stateValue = 1;
      
         return stateValue;
    }
}
