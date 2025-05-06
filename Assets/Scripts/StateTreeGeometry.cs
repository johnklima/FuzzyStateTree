using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTreeGeometry : MonoBehaviour
{

    private State state;


    public string stateName;
    public float stateValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setState(State _state)
    {
        state = _state;

        stateName = state.text;
        stateValue = state.stateValue;
        Debug.Log("Geom assignment " + stateName + " " + stateValue);

    }
    // Update is called once per frame
    void Update()
    {
        if(true)
        {
            stateName = state.text;
            stateValue = state.stateValue;
        }


        
    }
}
