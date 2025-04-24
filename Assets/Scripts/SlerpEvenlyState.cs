using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlerpEvenlyState : State
{

    public Transform startPos;
    public Transform endPos;
    public Transform objectToMove;
    public bool doIt = false;

    private TheGame theGame;
    
    public SlerpEvenlyState(int depth, TheGame _game)
    {
        text = "SlerpEvenlyState " + depth;
        theGame = _game;
    }

    // Update is called once per frame
    public float t = 0;
    public Vector3 initialPos;
    
    public override float Process(float dt)
    {

        //Debug.Log(text);
        doIt = theGame.slerpEvenly;


        foreach (State child in childStates)
        {
            float ret = child.Process(dt);
            if (ret > 0)
            {
                theGame.slerpEvenly = false;
                return 0;   //if any child state is "true" I am NOT true;

            }
        }

        if (doIt)
        {
            objectToMove = theGame.player;
            startPos = theGame.start;
            endPos = theGame.end;


            if (t == 0)
            {
                objectToMove.position = startPos.position;
                initialPos = objectToMove.position;
            }


            t += dt * 0.5f;

            Vector3 nextpos = Vector3.Slerp(initialPos, endPos.position, t);

            objectToMove.position = nextpos;


            if (t > 1.0f)
            {
                objectToMove.position = endPos.position;
                t = 0;
                doIt = false;

            }

            //when done let the game know
            theGame.slerpEvenly = doIt;

            if (doIt)
                return 1.0f;
            else
                return 0.0f;
        }

        return 0;

    }
}
