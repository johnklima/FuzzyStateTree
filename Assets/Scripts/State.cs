using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    
    public string text = "State";
    public Transform owner;
    public Transform represent;

    public List<State> childStates = new List<State>();

    public float stateValue = 0;

    public abstract float Process(float dt);

    public void Add(State state)
    {
        childStates.Add(state);
        Transform rep = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
        rep.parent = represent;
        rep.name = state.text; 
    }

}
