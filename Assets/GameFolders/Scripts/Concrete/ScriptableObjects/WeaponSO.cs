using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity_RPGProject.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Combat/WeaponSO", fileName = "WeaponSO", order = 51)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] GameObject _weaponPrefab;
        [SerializeField] float _weaponDamage;
        [SerializeField] float _weaponRange;

        public GameObject WeaponPrefab => _weaponPrefab;
        public float WeaponDamage => _weaponDamage;
        public float WeaponRange => _weaponRange;
    }
}

