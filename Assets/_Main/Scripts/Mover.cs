using UnityEngine;
using UnityEngine.AI;

namespace RpgCourse
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Start()
        {
            GetComponent<NavMeshAgent>().SetDestination(target.position);
            ;
        }
    }
}
