using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The dumbest state ever, it just processes its child states
/// </summary>
public class RootState : State
{
    
    public RootState(Transform _owner)
    {
        text = "Root";
        owner = _owner;
        represent = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
        represent.name = text;

    }
    /// <summary>
    /// Processes the state by time dt.
    /// </summary>
    /// <param name="dt">The delta time.</param>
    /// <returns>is in state by float how much</returns>
    public override float Process(float dt)
    {

        foreach(State child in childStates)
        {
            float ret = child.Process(dt);
            return ret;
            
        }

        return 0;
    }

}
