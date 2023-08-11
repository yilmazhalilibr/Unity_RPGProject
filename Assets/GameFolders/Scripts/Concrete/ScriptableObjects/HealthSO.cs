using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity_RPGProject.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health", menuName = "Combat/Health", order = 51)]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] float _maxHealth;

        public float MaxHealth => _maxHealth;
    }
}

