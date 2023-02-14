using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HearAction", menuName = "ScriptableObjects/States/Action/HearAction")]
public class HearAction : Actions
    //Codigo donde le indicamos la Acion que tiene que hacer la IA (En este caso la Accion de escuchar al player
{

    public override bool Check(GameObject owner)
    {
        RaycastHit[] info =
        Physics.SphereCastAll(owner.transform.position, 50, Vector3.up); 

        foreach (RaycastHit col in info)
        {
            if (col.collider.gameObject.GetComponent<PlayerController>())
            {
                return true;
            }
        }
        return false;
    }
}



