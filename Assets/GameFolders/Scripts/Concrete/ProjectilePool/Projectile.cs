using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Controllers;
using UnityEngine;

namespace Unity_RPGProject.Concrete.ProjectilePool
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] Queue<GameObject> _arrows = new Queue<GameObject>();
        [SerializeField] int _arrowCount = 5;
        GameObject _arrowPrefab;

        private void Start()
        {
            _arrowPrefab = gameObject;
        }

        public void ArrowPoolInitialize()
        {
            for (int i = 0; i < _arrowCount; i++)
            {
                var arrow = Instantiate(_arrowPrefab);
                arrow.SetActive(false);
                _arrows.Enqueue(arrow);
            }
        }
        public GameObject GetArrowObject()
        {
            GameObject arrow = _arrows.Dequeue();
            arrow.SetActive(true);
            _arrows.Enqueue(arrow);
            return arrow;
        }


    }
}

