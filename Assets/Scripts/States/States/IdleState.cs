using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Idle", menuName = "ScriptableObjects/States/IdleState")]
public class IdleState : State
// Codigo del Idle 
{
    public override State Run(GameObject owner, float time)
    {
        owner.GetComponent<Animator>().Play("Z_Idle"); // Cuando este en este estado, realizara la animacion indicada
        GameObject obj = owner.GetComponent<PlayerRef>().player; //Indicamos la referencia del player
        owner.GetComponent<NavMeshAgent>().SetDestination(new Vector3 (0f, 0f, -10.7f)); // Indicar la posicion

        if (action[0].Check(owner))
        {
            return nextState[0];
        }
        return this;
    }
}




