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
        owner.GetComponent<Animator>().Play("Idle"); // Cuando este en este estado, realizara la animacion indicada
        GameObject obj = owner.GetComponent<PlayerRef>().player; //Indicamos la referencia del player
        owner.GetComponent<NavMeshAgent>().SetDestination(new Vector3(865f, 83f, 255f)); // Indicar la posicion

        if (action[0].Check(owner))
        {
            return nextState[0];
        }
        return this;
    }
}




