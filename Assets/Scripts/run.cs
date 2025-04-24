using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : State
{

    public run(Transform _owner)
    {
        text = "Run";
        owner = _owner;

    }




    public override float Process(float dt)
    {
        Debug.Log(text);
        foreach (State child in childStates)
        {
            float ret = child.Process(dt);

            if (ret > 0)
            {
                return 0;
            }
            else
            {

                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                bool run = Input.GetKey(KeyCode.LeftShift);



                if ( (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0 ) && run)
                {
                    Debug.Log("run H " + h + " V " + v + " " + text);
                    return 1;
                }
                else
                {
                    return 0;
                }

            }

        }

        return 0;
    }
}
