using UnityEngine;

namespace RpgCourse
{
    [ExecuteInEditMode]
    public class MoveRelativeToObject : MonoBehaviour
    {
        [SerializeField] private Transform relatedObject;

        private Vector3? _offset;
        
        private void OnValidate()
        {
            if (relatedObject)
                _offset = transform.position - relatedObject.position;
        }

        private void Update()
        {
            if (relatedObject && _offset.HasValue)
                transform.position = relatedObject.position + _offset.Value;
        }
    }
}