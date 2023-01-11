using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
    // Codigo para que los siguientes estados puedan heredar de esta State.
{
    public Actions[] action;
    public State[] nextState;

    public abstract State Run(GameObject owner, float time);
}


