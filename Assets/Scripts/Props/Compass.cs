using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Compass : MonoBehaviour
{
    public Vector3 NorthDirection; //Direcci�n del Norte. 
    public Transform Player; //Posici�n del jugador.
    public Transform NorthLayer; 
   
    void Update()
    {
        ChangeNorthDirection(); 
    }

    public void ChangeNorthDirection()
    {
        NorthDirection.z = Player.eulerAngles.y; //La direcci�n del norte en el eje z (es decir, en la profundidad) ser� igual 
                                                 // a la rotaci�n en relaci�n con el mundo del eje y del Player. 
        NorthLayer.localEulerAngles = NorthDirection; 
    }
}
