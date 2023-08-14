using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Inputs;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Inputs;
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


        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;

        IInputReader _input;
        IPlayerAnimation _playerAnimator;
        IMover _mover;
        IAttack _attack;
        IHealth _health;

        public NavMeshAgent NavMeshAgent => _navMeshAgent;
        public WeaponSO Weapon => _weaponSO;

        public IMover Mover => _mover;
        public IPlayerAnimation PlayerAnimation => _playerAnimator;
        public IInputReader Input => _input;

        private bool CanMove => _navMeshAgent.velocity != Vector3.zero;
        private bool CanAttack => _weaponSO.WeaponRange >= 1 && _navMeshAgent.velocity == Vector3.zero;


        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

            _input = new InputReader(this);
            _playerAnimator = new PlayerAnimation(this);
            _stateMachine = new StateMachine();
            _attack = new PlayerAttack(this);
            _mover = new Mover(this);

        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;

            IdleState idleState = new IdleState(this);
            MoveState moveState = new MoveState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState();

            _stateMachine.AddState(idleState, moveState, () => CanMove);
            _stateMachine.AddState(moveState, idleState, () => !CanMove);
            _stateMachine.AddState(idleState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, moveState, () => !CanAttack);

            _stateMachine.AddAnyState(deadState, () => _health.isDead);

            _stateMachine.SetState(idleState);
        }

        private void Update()
        {
            _stateMachine.Tick();
            _mover.Move();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }

        private void LateUpdate()
        {
            _stateMachine.LateTick();
        }



    }
}

