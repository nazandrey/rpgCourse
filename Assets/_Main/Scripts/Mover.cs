using UnityEngine;
using UnityEngine.AI;

namespace RpgCourse
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        private NavMeshAgent _navMeshAgent;
        private Camera _mainCamera;
        private Animator _animator;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    _navMeshAgent.SetDestination(hit.point);
                }
            }
            _animator.SetFloat("Speed", _navMeshAgent.velocity.z);
        }
    }
}
