using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public State startingState;
    public State currentState;
    // Codigo de la maquina de estados, para saber en que estado estas(privado) y para que pueda pasar al siguiente estado.
    void Start()
    {
        currentState = startingState;
    }
    void Update()
    {
        RunStateMachine();
    }
        
    private void RunStateMachine()
    {
        if(currentState == null)
        {
            return;
        }

        State nextState = currentState.Run(gameObject, Time.deltaTime);

        if(nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State next)
    {
        currentState = next;
    }
}
