using System;
using UnityEngine;

namespace RpgCourse
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] private Transform objectToFollow;

        private Vector3 _offset;
        
        private void Start()
        {
            _offset = transform.position - objectToFollow.position;
        }

        private void LateUpdate()
        {
            transform.position = objectToFollow.position + _offset;
        }
    }
}