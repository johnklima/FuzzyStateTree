using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : State
{
    run runstate;
    walk walkstate;

    public Vector3 velocity;

    public jump(Transform _owner, run _runstate, walk _walkstate)
    {
        text = "Jump";
        owner = _owner;
        runstate = _runstate;
        walkstate = _walkstate; 
        represent  = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
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



        bool jump = Input.GetKeyDown(KeyCode.Space);

        
        if(jump)
        {
            if(walkstate.stateValue > 0)
            {
                Debug.Log("I am walking jump forward");
                velocity = owner.forward * 3;
                velocity += owner.up * 3;
                owner.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
            }
            else if (runstate.stateValue > 0)
            {
                Debug.Log("I am running jump forward");
                velocity = owner.forward * 6;
                velocity += owner.up * 6;
                owner.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("I'm Jumping up");
                velocity = owner.up * 3;
                owner.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
            }
            stateValue = 1;
            return stateValue;
        }
        else if (owner.position.y > 1.001f)
        {
            Debug.Log("I'm in the air");
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
