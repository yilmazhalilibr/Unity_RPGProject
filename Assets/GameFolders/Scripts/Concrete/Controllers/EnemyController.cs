using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        bool _canPatrol;
        bool _canChase;
        bool _canAttack = false;

        PatrolPath _patrolPath;
        StateMachine _stateMachine;
        NavMeshAgent _navMeshAgent;
        Transform _player;


        IHealth _health;
        IMover _mover;
        IEnemyAnimation _enemyAnimation;


        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public Transform Player => _player;
        public PatrolPath PatrolPath => _patrolPath;

        public IMover Mover => _mover;
        public IEnemyAnimation EnemyAnimation => _enemyAnimation;

        public float ChaseDistance => _chaseDistance;

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
        public bool CanChase
        {
            get
            {

                return _canChase;
            }
            set
            {
                _canChase = value;
            }
        }


        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;

            _stateMachine = new StateMachine();
            _mover = new EnemyMover(this);
            _enemyAnimation = new EnemyAnimation(this);

            _patrolPath = GameObject.FindAnyObjectByType<PatrolPath>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

        }

        private void Start()
        {

            EnemyPatrolState enemyPatrolState = new(this);
            EnemyIdleState enemyIdleState = new(this);
            EnemyDeadState enemyDeadState = new(this);
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

        public bool IsChase()
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (ChaseDistance >= distance)
            {
                _canPatrol = false;
                return true;
            }
            return false;

        }


    }
}

