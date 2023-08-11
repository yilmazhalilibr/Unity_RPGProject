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
        [Header("Movement")]
        [SerializeField] float _speed;


        NavMeshAgent _navMeshAgent;
        IMover _mover;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _mover = new Mover(this);
        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;
        }


        private void LateUpdate()
        {
            _mover.Move();
        }



    }
}

