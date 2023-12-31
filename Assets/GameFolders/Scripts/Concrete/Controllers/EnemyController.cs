using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.Movements.Enemy;
using Unity_RPGProject.PatrolPaths;
using Unity_RPGProject.ScriptableObjects;
using Unity_RPGProject.States;
using Unity_RPGProject.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class EnemyController : BaseController
    {
        [Header("Enemy Chase")]
        [SerializeField] float _chaseDistance = 5f;
        [SerializeField] float _chaseTime = 5f;
        [Header("Combats")]
        [SerializeField] WeaponSO _weapon;
        [Header("Patrol Of Enemy")]
        [SerializeField] PatrolPath _patrolPath;


        public event System.Action OnHit;

        bool _canPatrol;
        bool _canChase;
        bool _canAttack = false;

        StateMachine _stateMachine;
        NavMeshAgent _navMeshAgent;
        Transform _player;

        IHealth _health;
        IHealth _playerHealth;
        IMover _mover;
        IEnemyAnimation _enemyAnimation;


        public override NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } set { _navMeshAgent = value; } }

        public override WeaponSO WeaponSO { get { return _weapon; } set { _weapon = value; } }
        public override StateMachine StateMachine { get { return _stateMachine; } set { _stateMachine = value; } }

        public Transform Player => _player;
        public PatrolPath PatrolPath => _patrolPath;
        public Transform PatrolWay { get; set; }

        public override IMover Mover { get { return _mover; } set { _mover = value; } }


        public IEnemyAnimation EnemyAnimation => _enemyAnimation;
        public IHealth PlayerHealth => _playerHealth;
        public IHealth EnemyHealth => _health;

        public float ChaseDistance => _chaseDistance;
        public float ChaseTime => _chaseTime;
        public bool CanAttack { get { return _canAttack; } set { _canAttack = value; } }
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
            _playerHealth = _player.GetComponent<Health>();

            _stateMachine = new StateMachine();
            _mover = new EnemyMover(this);
            _enemyAnimation = new EnemyAnimation(this);

            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

        }

        private void Start()
        {

            EnemyPatrolState enemyPatrolState = new(this);
            EnemyIdleState enemyIdleState = new(this);
            EnemyDeadState enemyDeadState = new(this);
            EnemyChaseState enemyChaseState = new(this);
            EnemyAttackState enemyAttackState = new(this);

            _stateMachine.AddState(enemyIdleState, enemyPatrolState, () => CanPatrol && !CanAttack && !CanChase);
            _stateMachine.AddState(enemyPatrolState, enemyIdleState, () => !CanPatrol && NavMeshAgent.velocity == Vector3.zero && WeaponSO.WeaponRange <= Vector3.Distance(transform.position, Player.transform.position));
            _stateMachine.AddState(enemyChaseState, enemyPatrolState, () => CanPatrol && !CanChase && !CanAttack);
            _stateMachine.AddState(enemyAttackState, enemyPatrolState, () => CanPatrol && !CanAttack && !CanChase);

            _stateMachine.AddAnyState(enemyDeadState, () => _health.isDead);
            _stateMachine.AddAnyState(enemyChaseState, () => CanChase);
            _stateMachine.AddAnyState(enemyAttackState, () => CanAttack && !Player.GetComponent<IHealth>().isDead);

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
            float distance = PlayerAndEnemyDistance();
            if (ChaseDistance >= distance)
            {
                _canPatrol = false;
                return true;
            }
            return false;

        }

        public float PlayerAndEnemyDistance()
        {
            return Vector3.Distance(transform.position, Player.transform.position);
        }

        //Animation Event's method.
        public void EnemyOnHit()
        {
            OnHit?.Invoke();
        }

        public void StatesChangeHandle(bool stateTrue, string name)
        {
            switch (name)
            {
                case "CanAttack":
                    CanAttack = stateTrue;
                    CanPatrol = !stateTrue;
                    CanChase = !stateTrue;
                    break;
                case "CanPatrol":
                    CanAttack = !stateTrue;
                    CanPatrol = stateTrue;
                    CanChase = !stateTrue;
                    break;
                case "CanChase":
                    CanAttack = !stateTrue;
                    CanPatrol = !stateTrue;
                    CanChase = stateTrue;
                    break;
            }

        }

        public override object CaptureState()
        {
            return new SerializableVector3(transform.position);

        }
        public override void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;
            NavMeshAgent.enabled = false;
            transform.position = position.ToVector();
            NavMeshAgent.enabled = true;

        }

    }
}

