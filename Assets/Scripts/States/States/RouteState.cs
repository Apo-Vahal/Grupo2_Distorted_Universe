using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Route", menuName = "ScriptableObjects/States/RouteState")]
public class RouteState : State
{
    //Codigo de la ruta que tiene que seguir la Ia
    public Vector3[] WayPoints;
    private int nextWayPoint = 0;
    private float curretime = 0;


    public override State Run(GameObject owner, float time)
    {
        GameObject obj = owner.GetComponent<PlayerRef>().player;
        owner.GetComponent<NavMeshAgent>().SetDestination(WayPoints[nextWayPoint]);
        float distance = Vector3.Distance(owner.transform.position, WayPoints[nextWayPoint]); // con la distancia le indicamos cuando tiene que cambiar wayPoints
        
        if (distance <= 3.0f  )
        {
            curretime += time;

            if(curretime >= 5.0f) 
            {
                nextWayPoint = (nextWayPoint + 1) % WayPoints.Length; // Codigo para que pueda cambiar al siguiente WayPoints
                curretime = 0;

            }
            
        }
        if (!action[0].Check(owner))
        {
            return nextState[0];

        }
        return this;
    }
}







