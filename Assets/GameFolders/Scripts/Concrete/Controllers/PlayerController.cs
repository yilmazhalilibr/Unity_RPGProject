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

        public bool CanAttack => _weaponSO.WeaponRange >= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;
        public bool CanMove => _navMeshAgent.velocity != Vector3.zero;
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

            IdleState idleState = new IdleState();
            AttackState attackState = new AttackState();
            MoveState moveState = new MoveState();
            DeadState deadState = new DeadState();

            _stateMachine.AddState(idleState, moveState, () => CanMove);
            _stateMachine.AddState(moveState, idleState, () => !CanMove);
            _stateMachine.AddState(idleState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, moveState, () => !CanAttack);

            _stateMachine.AddAnyState(deadState, () => _health.isDead);
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            if (_attack.Attack()) return;
            if (_mover.Move()) return;

        }

        private void LateUpdate()
        {
            _playerAnimator.AnimationUpdate();
        }

        private void AttackMovement()
        {
            _mover.Move();
        }


    }
}

