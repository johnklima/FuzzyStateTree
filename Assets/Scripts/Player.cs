using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    RootState rootstate;
    public Transform StateTreeEmpty;

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
        jump jumpstate = new jump(transform,runstate, walkstate);

        rootstate.Add(idlestate);
            idlestate.Add(walkstate);            
                walkstate.Add(runstate);
                walkstate.Add(jumpstate);
                    runstate.Add(jumpstate);
                        jumpstate.Add(climbstate);
                            climbstate.Add(deadstate);


    }

    // Update is called once per frame
    void Update()
    {
        rootstate.Process(Time.deltaTime);
    }
}
