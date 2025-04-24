using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpSimpleState : State
{

    public Transform startPos;
    public Transform endPos;
    public Transform objectToMove;
    public bool doIt = false;

    private TheGame theGame;


    public SlerpSimpleState(int depth, TheGame _game)
    {
        theGame = _game;
    }

    public override float Process(float dt)
    {
        doIt = theGame.slerpSimple;


        foreach (State child in childStates)
        {
            float ret = child.Process(dt);
            if (ret > 0)
                return 0;   //if any child state is "true" I am NOT true;
        }


        if (doIt)
        {
            objectToMove = theGame.player;
            startPos = theGame.start;
            endPos = theGame.end;

            
            Vector3 pos = objectToMove.position;
            pos = Vector3.Slerp(pos, endPos.position, dt);

            objectToMove.position = pos;

            if(Vector3.Distance(pos,endPos.position) < 0.01f)
            {
                doIt = false;
                theGame.slerpSimple = false;

            }
            if (doIt)
                return 1.0f;
            else
                return 0;

        }



        return 0;
    }
}
