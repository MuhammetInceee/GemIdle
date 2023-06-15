using System.Collections.Generic;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private int _collectCount;

        [SerializeField] private List<GameObject> stackList;
        [SerializeField] private Transform firstStackTr;
        [SerializeField] private float offset;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectable collectable))
            {
                collectable.Execute(firstStackTr, stackList);
                _collectCount++;
            }
        }
    }
}
