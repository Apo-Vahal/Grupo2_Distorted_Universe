using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : ScriptableObject
// Codigo para que los siguientes Acciones puedan heredar de esta Accion.
{
    public abstract bool Check(GameObject owner);
}
// He añadido float time para controlar el tiempo de la IA //