using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Movements;
using Unity_RPGProject.ScriptableObjects;
using Unity_RPGProject.States;
using Unity_RPGProject.States.PlayerStates;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] float _speed;
        [Header("Combat")]
        [SerializeField] WeaponSO _weaponSO;
        [SerializeField] IHealth _health;


        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;
        IPlayerAnimation _playerAnimator;
        IMover _mover;
        IAttack _attack;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public WeaponSO Weapon => _weaponSO;

        public IMover Mover => _mover;

        public bool CanAttack => _weaponSO.WeaponRange >= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        public bool CanMove => _mover.Move();
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

            _playerAnimator = new PlayerAnimationWithNavMesh(this);
            _stateMachine = new StateMachine();
            _attack = new PlayerAttack(this);
            _mover = new Mover(this);

        }
        private void OnEnable()
        {
            _attack.OnAttack += AttackMovement;
        }
        private void OnDisable()
        {
            _attack.OnAttack -= AttackMovement;
        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;

            IdleState idleState = new IdleState(this);
            AttackState attackState = new AttackState();
            MoveState moveState = new MoveState(this);
            DeadState deadState = new DeadState();

            _stateMachine.AddState(idleState, moveState, () => _mover.Move());
            _stateMachine.AddState(moveState, idleState, () => !_mover.Move());
            _stateMachine.AddState(idleState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, moveState, () => !CanAttack);

            _stateMachine.AddAnyState(deadState, () => _health.isDead);

            _stateMachine.SetState(idleState);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            //if (_attack.Attack()) return;
            //if (_mover.Move()) return;

            _stateMachine.FixedTick();


        }

        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }

        private void AttackMovement()
        {
            _mover.Move();
        }


    }
}

