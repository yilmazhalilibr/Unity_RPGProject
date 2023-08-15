using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Enums;
using UnityEngine;


namespace Unity_RPGProject.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Combat/WeaponSO", fileName = "WeaponSO", order = 51)]
    public class WeaponSO : ScriptableObject
    {
        [SerializeField] GameObject _weaponPrefab;
        [SerializeField] WeaponType _weaponType;
        [SerializeField] AnimationClip _animationClip;
        [SerializeField] float _weaponDamage;
        [SerializeField] float _weaponRange;

        public GameObject WeaponPrefab => _weaponPrefab;
        public WeaponType WeaponType => _weaponType;
        public AnimationClip AnimationClip => _animationClip;
        public float WeaponDamage => _weaponDamage;
        public float WeaponRange => _weaponRange;
    }
}

