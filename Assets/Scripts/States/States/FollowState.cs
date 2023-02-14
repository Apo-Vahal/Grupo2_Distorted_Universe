using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "FollowState", menuName = "ScriptableObjects/States/followState")]
public class FollowState : State
    //Codigo del Estado donde persigue al Player
{
    public override State Run(GameObject owner, float time)
    {
        owner.GetComponent<Animator>().Play("Run");
        GameObject obj = owner.GetComponent<PlayerRef>().player; // Utilizamos la referencia del Player para saber a quien tiene que seguir.
        owner.GetComponent<NavMeshAgent>().SetDestination(obj.transform.position);

        if (!action[0].Check(owner))
        {
            return nextState[0];
        }
        return this;
    }
}


