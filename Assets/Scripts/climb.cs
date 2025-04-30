using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb : State
{

    public climb(Transform _owner)
    {
        text = "Climb";
        owner = _owner;

    }

  
    public override float Process(float dt)
    {
        
        foreach (State child in childStates)
        {
            float ret = child.Process(dt);

            if (ret > 0)
                return ret;           

        }
        

        return doClimb();
    }

    private float doClimb()
    {
        if (owner.GetComponent<Player>().climbWall)
        {

            Inventory inv = owner.GetComponent<Inventory>();
            Transform obj = inv.stuff[0];
            Debug.Log("Climb Wall with " + obj.name);
            return 1;
        }

        return 0;

    }
}
