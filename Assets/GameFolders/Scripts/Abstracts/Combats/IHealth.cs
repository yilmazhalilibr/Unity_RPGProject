using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.Abstracts.Combats
{
    public interface IHealth
    {
        bool isDead { get; }

        void TakeDamage(float damage);

        event System.Action OnDead;
        event System.Action<float, float> OnTakeHit;

    }
}

