using System;
using System.Collections.Generic;
using Scripts.GemManagement;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private List<Gem> stackList;
        [SerializeField] private Transform firstStackTr;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICollectable collectable)) collectable.Execute(firstStackTr, stackList);
            else if(other.TryGetComponent(out IDisposable disposable)) StartCoroutine(disposable.ExecuteEnter(stackList));
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.TryGetComponent(out IDisposable disposable)) disposable.ExecuteExit();
        }
    }
}
