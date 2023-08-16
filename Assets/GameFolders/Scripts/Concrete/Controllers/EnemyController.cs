using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Combats;
using Unity_RPGProject.PatrolPaths;
using Unity_RPGProject.States;
using Unity_RPGProject.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float _chaseDistance = 5f;
        [SerializeField] PatrolPath _patrolPath;

        float _chaseCancelTime = 3f;
        float _chaseCurrentTime = 0f;

        StateMachine _stateMachine;
        NavMeshAgent _navMeshAgent;
        Transform _player;
        PlayerDetector _playerDetector;


        public float ChaseDistance => _chaseDistance;
        public float ChaseCancelTime { get { return _chaseCancelTime; } set { _chaseCancelTime = value; } }
        public float ChaseCurrentTime { get { return _chaseCurrentTime; } set { _chaseCurrentTime = value; } }
        public bool CanPatrol
        {
            get
            {
                return _navMeshAgent.velocity == Vector3.zero;
            }
            set
            {
                CanPatrol = value;
            }
        }

        public bool CanAttack { get; set; }

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Transform Player => _player;
        public PlayerDetector PlayerDetector => _playerDetector;
        public PatrolPath PatrolPath => _patrolPath;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            _playerDetector = new PlayerDetector(this);

            _navMeshAgent = GetComponent<NavMeshAgent>();

        }

        private void Start()
        {
            _player = _playerDetector.PlayerFind();

            EnemyPatrolState enemyPatrolState = new(this);
            EnemyIdleState enemyIdleState = new(this);
            EnemyDeadState enemyDeadState = new();
            EnemyChaseState enemyChaseState = new();
            EnemyAttackState enemyAttackState = new();

            _stateMachine.AddState(enemyIdleState, enemyPatrolState, () => CanPatrol);
            _stateMachine.AddState(enemyPatrolState, enemyIdleState, () => !CanPatrol);


            _stateMachine.SetState(enemyIdleState);



        }

        private void Update()
        {
            _stateMachine.Tick();
        }
        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }
        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseDistance);
        }




    }
}

