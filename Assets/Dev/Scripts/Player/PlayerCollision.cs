using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Execute(transform);
            }
        }
    }
}
