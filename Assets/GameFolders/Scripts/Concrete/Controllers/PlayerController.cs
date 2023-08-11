using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
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
        IPlayerAnimation _playerAnimator;
        IMover _mover;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;


        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _mover = new Mover(this);
            _playerAnimator = new PlayerAnimationWithNavMesh(this);
        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;
        }

        private void FixedUpdate()
        {
            _mover.Move();
        }

        private void LateUpdate()
        {
            _playerAnimator.AnimationUpdate();
        }



    }
}

