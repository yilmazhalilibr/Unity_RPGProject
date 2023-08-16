using System.Collections;
using System.Collections.Generic;
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


        public float ChaseDistance => _chaseDistance;

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

        private void Awake()
        {
            _stateMachine = new StateMachine();

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        private void Start()
        {

            EnemyPatrolState enemyPatrolState = new(this);
            EnemyIdleState enemyIdleState = new(this);
            EnemyDeadState enemyDeadState = new();
            EnemyChaseState enemyChaseState = new();
            EnemyAttackState enemyAttackState = new();


            _stateMachine.SetState(enemyIdleState);



        }

        private void Update()
        {

        }
        private void FixedUpdate()
        {

        }
        private void LateUpdate()
        {

        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _chaseDistance);
        }
        public void PlayerDetector()
        {
            float enemyDistance = Vector3.Distance(transform.position, Player.transform.position);
            if (enemyDistance < ChaseDistance)
            {
                NavMeshAgent.destination = Player.transform.position;
            }
            else
            {
                _chaseCurrentTime += Time.deltaTime;
                CanPatrol = _chaseCurrentTime >= _chaseCancelTime;
            }

        }



    }
}

