using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.ScriptableObjects;
using Unity_RPGProject.States;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseController : MonoBehaviour, ISaveable
{
    public abstract WeaponSO WeaponSO { get; set; }
    public abstract NavMeshAgent NavMeshAgent { get; set; }
    public abstract StateMachine StateMachine { get; set; }
    public abstract IMover Mover { get; set; }

    public abstract object CaptureState();

    public abstract void RestoreState(object state);

}
