using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Combats
{
    public interface IAttack
    {
        WeaponSO Weapon { get; }
        bool Attack();
    }
}

