using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Animations;
using UnityEngine;

public abstract class State : MonoBehaviour 
{
    
    public string text = "State";
    public Transform owner;

    public List<State> childStates = new List<State>();

    public float stateValue = 0;
    public Transform geom;
    public abstract float Process(float dt);
    

    public void Add(State state)
    {
        childStates.Add(state);
       
    }

    public void traverse(Transform parent)
    {

        //get the geometry to duplcate from the owner tranform (player usualy)
        geom = GameObject.Instantiate(owner.GetComponent<Player>().StateTreeEmpty);
        geom.parent = parent;
        geom.name = text;


        //get the state tree geometry component that this must have
        StateTreeGeometry gsg = geom.GetComponent<StateTreeGeometry>();
        //tell the state it represents is this state
        gsg.setState(this);


        //go and traverse the rest
        foreach (State child in childStates)
        {
            child.traverse(geom);
        }

    }
}
