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
        [SerializeField] GameObject _arrowPrefab;
        [SerializeField] Transform _fireTransform;

        public void ArrowPoolInitialize()
        {
            for (int i = 0; i < _arrowCount; i++)
            {
                GameObject arrow = Instantiate(_arrowPrefab);
                arrow.SetActive(false);
                arrow.transform.position = _fireTransform.position;
                _arrows.Enqueue(arrow);
            }
        }
        public GameObject GetArrowObject()
        {
            GameObject arrow = _arrows.Dequeue();
            arrow.transform.position = _fireTransform.position;
            arrow.SetActive(true);
            _arrows.Enqueue(arrow);
            return arrow;
        }

        public void ArrowCompleted(GameObject arrow)
        {
            arrow.SetActive(false);
            arrow.transform.position = _fireTransform.position;
        }


    }
}

