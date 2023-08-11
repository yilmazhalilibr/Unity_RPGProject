using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Transform _targetTrasform;


        NavMeshAgent _navMeshAgent;
        IMover _mover;

        public Transform TargetTransform => _targetTrasform;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _mover = new Mover(this);
        }

        private void FixedUpdate()
        {
            _mover.Move();
        }




    }
}

