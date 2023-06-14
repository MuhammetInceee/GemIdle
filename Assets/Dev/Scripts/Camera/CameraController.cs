using UnityEngine;

namespace Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private Vector3 _distance;

        private void Start() => _distance = transform.position - target.position;
        private void LateUpdate()
        {
            var position = target.position;
            var transform1 = transform;
            
            transform1.position = new Vector3((position.x + _distance.x), transform1.position.y, (position.z + _distance.z));
        }
    }
}
