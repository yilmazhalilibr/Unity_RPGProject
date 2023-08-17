using System.Collections;
using System.Collections.Generic;
using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Movements.Enemy;
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
        bool _canPatrol;
        bool _canChase;
        bool _canAttack = false;

        StateMachine _stateMachine;
        NavMeshAgent _navMeshAgent;
        Transform _player;
        PlayerDetector _playerDetector;


        IHealth _health;
        IMover _mover;
        IEnemyAnimation _enemyAnimation;

        public float ChaseDistance => _chaseDistance;
        public float ChaseCancelTime { get { return _chaseCancelTime; } set { _chaseCancelTime = value; } }
        public float ChaseCurrentTime { get { return _chaseCurrentTime; } set { _chaseCurrentTime = value; } }
        public bool CanPatrol
        {
            get
            {
                return _canPatrol;
            }
            set
            {
                _canPatrol = value;
            }
        }
        public bool CanChase => _canChase;
        public bool CanAttack { get { return _canAttack; } set { _canAttack = value; } }

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Transform Player => _player;
        public PlayerDetector PlayerDetector => _playerDetector;
        public PatrolPath PatrolPath => _patrolPath;

        public IMover Mover => _mover;
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _playerDetector = new PlayerDetector(this);
            _mover = new EnemyMover(this);
            _enemyAnimation = new EnemyAnimation(this);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

        }

        private void Start()
        {
            _player = _playerDetector.PlayerFind();

            EnemyPatrolState enemyPatrolState = new(this);
            EnemyIdleState enemyIdleState = new(this);
            EnemyDeadState enemyDeadState = new();
            EnemyChaseState enemyChaseState = new(this);
            EnemyAttackState enemyAttackState = new();

            _stateMachine.AddState(enemyIdleState, enemyPatrolState, () => CanPatrol);
            _stateMachine.AddState(enemyPatrolState, enemyIdleState, () => !CanPatrol && NavMeshAgent.velocity == Vector3.zero);
            _stateMachine.AddState(enemyChaseState, enemyPatrolState, () => !CanChase);


            _stateMachine.AddAnyState(enemyDeadState, () => _health.isDead);
            _stateMachine.AddAnyState(enemyChaseState, () => CanChase);

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

