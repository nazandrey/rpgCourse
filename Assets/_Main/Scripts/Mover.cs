using UnityEngine;
using UnityEngine.AI;

namespace RpgCourse
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class Mover : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private Animator _animator;
        // http://answers.unity.com/answers/746157/view.html
        public bool IsMoving => _navMeshAgent.hasPath && _navMeshAgent.remainingDistance >= _navMeshAgent.stoppingDistance;
        public bool HasReachedDestination => !_navMeshAgent.pathPending && !IsMoving 
            && _navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var globalVelocity = _navMeshAgent.velocity;
            var localVelocity = transform.InverseTransformVector(globalVelocity);
            _animator.SetFloat("Speed", localVelocity.z);
        }

        public void SetDestination(Vector3 targetPosition)
        {
            SetDestinationAndStopDistance(targetPosition);
        }

        public void SetDestinationAndStopDistance(Vector3 targetPosition, float stoppingDistance = 0)
        {
            _navMeshAgent.SetDestination(targetPosition);
            _navMeshAgent.stoppingDistance = stoppingDistance;
        }
    }
}
