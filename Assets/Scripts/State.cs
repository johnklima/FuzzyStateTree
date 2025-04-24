using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    
    public string text = "State";
    public Transform owner;

    public List<State> childStates = new List<State>();

    public abstract float Process(float dt);
}
