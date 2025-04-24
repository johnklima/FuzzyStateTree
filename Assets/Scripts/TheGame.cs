using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheGame : MonoBehaviour
{
    //dummy triggers and references to act upon
    public bool slerpEvenly = false;
    public bool slerpSimple = false;

    public RootState rootState ;

    public Transform player;
    public Transform start;
    public Transform end;

    // Start is called before the first frame update
    void Start()
    {
        SlerpEvenlyState slerpeven = new SlerpEvenlyState(1, this);
        SlerpSimpleState slerpsimp = new SlerpSimpleState(2, this);

        slerpeven.childStates.Add(slerpsimp);

        rootState.childStates.Add(slerpeven);

    }

    // Update is called once per frame

    
    void Update()
    {

        
        rootState.Process(Time.deltaTime);
        
    }
}
