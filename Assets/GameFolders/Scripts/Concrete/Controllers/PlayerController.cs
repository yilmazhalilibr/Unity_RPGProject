using Unity_RPGProject.Abstracts.Animations;
using Unity_RPGProject.Abstracts.Combats;
using Unity_RPGProject.Abstracts.Inputs;
using Unity_RPGProject.Abstracts.Movements;
using Unity_RPGProject.Animations;
using Unity_RPGProject.Combats;
using Unity_RPGProject.Concrete;
using Unity_RPGProject.Concrete.Controllers;
using Unity_RPGProject.Inputs;
using Unity_RPGProject.Interacts;
using Unity_RPGProject.Movements;
using Unity_RPGProject.ScriptableObjects;
using Unity_RPGProject.States;
using Unity_RPGProject.States.PlayerStates;
using UnityEngine;
using UnityEngine.AI;

namespace Unity_RPGProject.Controllers
{
    public class PlayerController : BaseController
    {
        [Header("Movement")]
        [SerializeField] float _speed;
        [Header("Combat")]
        [SerializeField] WeaponSO _weaponSO;
        [Header("Hands")]
        [SerializeField] GameObject _leftHand;
        [SerializeField] GameObject _rightHand;


        bool _onHit = false;

        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;
        TargetDetector _targetDetector;
        EquipmentController _equipmentController;

        IInputReader _input;
        IPlayerAnimation _playerAnimation;
        IMover _mover;
        IHealth _health;

        public GameObject LeftHand { get { return _leftHand; } set { _leftHand = value; } }
        public GameObject RightHand { get { return _rightHand; } set { _rightHand = value; } }
        public override NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } set { _navMeshAgent = value; } }
        public override WeaponSO WeaponSO { get { return _weaponSO; } set { _weaponSO = value; } }
        public override StateMachine StateMachine { get { return _stateMachine; } set { _stateMachine = value; } }
        public TargetDetector TargetDetector => _targetDetector;

        public IPlayerAnimation PlayerAnimation => _playerAnimation;
        public IInputReader Input => _input;
        public override IMover Mover { get { return _mover; } set { _mover = value; } }

        public bool CanMove => Input.OnMouseLeftClick || _navMeshAgent.velocity != Vector3.zero;
        public bool CanAttack
        {
            get
            {
                return
                    _navMeshAgent.velocity == Vector3.zero &&
                    _targetDetector.CurrentTargetType == Enums.Targets.Enemy &&
                    Vector3.Distance(transform.position, TargetDetector.CurrentTargetTransform.position) <= WeaponSO.WeaponRange &&
                    !TargetDetector.CurrentTargetTransform.GetComponent<IHealth>().isDead;
            }
            set
            {
                _onHit = value;
            }
        }
        public bool OnHitInfo { get { return _onHit; } set { _onHit = value; } }



        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<Health>();

            _equipmentController = new EquipmentController(this);
            _input = new InputReader(this);
            _playerAnimation = new PlayerAnimation(this);
            _stateMachine = new StateMachine();
            _mover = new Mover(this);
            _targetDetector = new TargetDetector(this);

        }

        private void Start()
        {
            _navMeshAgent.speed = _speed;
            _playerAnimation.PlayerAnimator.runtimeAnimatorController = WeaponSO.AnimatorOverride;

            IdleState idleState = new(this);
            MoveState moveState = new(this);
            AttackState attackState = new(this);
            DeadState deadState = new(this);

            _stateMachine.AddState(idleState, moveState, () => CanMove);
            _stateMachine.AddState(moveState, idleState, () => !CanMove);
            _stateMachine.AddState(attackState, idleState, () => !CanAttack && _navMeshAgent.velocity == Vector3.zero);
            _stateMachine.AddState(attackState, moveState, () => CanMove);

            _stateMachine.AddAnyState(deadState, () => _health.isDead);
            _stateMachine.AddAnyState(attackState, () => CanAttack && !TargetDetector.CurrentTargetTransform.GetComponent<IHealth>().isDead);

            _stateMachine.SetState(idleState);


            _equipmentController.UseEquipment();
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

        //Animation Event's method.(OnHit)
        public void OnHit()
        {
            _onHit = true;
        }

        [System.Obsolete]
        public void PlayerControllerHandle(bool state)
        {
            enabled = state;
            NavMeshAgent.Resume();
            if (state == false)
            {
                NavMeshAgent.Stop();
                NavMeshAgent.velocity = Vector3.zero;
            }
        }

        public override object CaptureState()
        {
            Debug.Log(transform.localPosition);
            return new SerializableVector3(transform.localPosition);
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

