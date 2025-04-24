using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    RootState rootstate;

    public bool climbWall = false;

    // Start is called before the first frame update
    void Start()
    {
        rootstate = new RootState(transform);

        /* build the states
            dead
            idle
            walk
            run            
            climb
        */

        dead deadstate = new dead(transform);
        idle idlestate = new idle(transform);
        walk walkstate = new walk(transform);
        run runstate = new run(transform);
        climb climbstate = new climb(transform);

        rootstate.childStates.Add(idlestate);
            idlestate.childStates.Add(walkstate);            
                walkstate.childStates.Add(runstate);
                    runstate.childStates.Add(climbstate);
                        climbstate.childStates.Add(deadstate);


    }

    // Update is called once per frame
    void Update()
    {
        rootstate.Process(Time.deltaTime);
    }
}
