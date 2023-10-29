using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using Unity_RPGProject.ScriptableObjects;
using UnityEngine;

namespace Unity_RPGProject.Concrete.Controllers
{
    public class EquipmentController
    {
        PlayerController _controller;
        WeaponSO _baseSO;

        bool _range = false;
        GameObject _weaponPrefab;
        public bool RangeWeapon => _range;
        public GameObject WeaponPrefab => _weaponPrefab;

        public EquipmentController(PlayerController controller)
        {
            _controller = controller;
            _baseSO = _controller.WeaponSO;
        }

        public void UseEquipment()
        {
            if (_baseSO.WeaponType == Enums.WeaponType.BOW)
            {
                //We are using only a Instantiate , so Instantie is not expensive this time.
                _weaponPrefab = GameObject.Instantiate(_baseSO.WeaponPrefab, _controller.LeftHand.transform);
                _range = true;
            }
            else
            {
                _weaponPrefab = GameObject.Instantiate(_baseSO.WeaponPrefab, _controller.RightHand.transform);
                _range = false;
            }
        }

        public void TakeOutEquipment()
        {
            if (_range)
            {
                Transform[] childs = _controller.LeftHand.GetComponentsInChildren<Transform>();
                for (int i = 0; i < childs.Length; i++)
                {
                    GameObject.Destroy(childs[i].gameObject);
                }
            }
            else
            {
                Transform[] childs = _controller.RightHand.GetComponentsInChildren<Transform>();
                for (int i = 0; i < childs.Length; i++)
                {
                    GameObject.Destroy(childs[i].gameObject);
                }
            }

        }


    }
}

