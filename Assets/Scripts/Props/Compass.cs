using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Compass : MonoBehaviour
{
    public Vector3 NorthDirection; //Dirección del Norte. 
    public Transform Player; //Posición del jugador.
    public Transform NorthLayer; 
   
    void Update()
    {
        ChangeNorthDirection(); 
    }

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y; //La dirección del norte en el eje z (es decir, en la profundidad) será igual 
                                                 // a la rotación en relación con el mundo del eje y del Player. 
        NorthLayer.localEulerAngles = NorthDirection; 
    }
}
