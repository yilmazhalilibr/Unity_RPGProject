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
        [SerializeField] float _movementDuration = 1f;
        GameObject _arrowPrefab;
        float _elapseTime = 0f;
        PlayerController _playerController;
        private void Start()
        {
            _arrowPrefab = gameObject;
            ArrowPoolInitialize();
            _playerController = FindFirstObjectByType<PlayerController>();
        }

        private void ArrowPoolInitialize()
        {
            for (int i = 0; i < _arrowCount; i++)
            {
                var arrow = Instantiate(_arrowPrefab, transform);
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
        public void FireTheTarget()
        {
            _elapseTime += Time.deltaTime;
            if (_elapseTime < _movementDuration)
            {
                float t = _elapseTime / _movementDuration;
                transform.position = Vector3.Lerp(_playerController.transform.position, _playerController.TargetDetector.CurrentTargetTransform.position, t);
            }
            else
            {
                //vurulunca napsýn
            }
        }

    }
}

