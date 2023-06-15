using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.GemManagement;
using Scripts.Manager;
using UnityEngine;

namespace Scripts.Collisions
{
    public class MarketStand : MonoBehaviour, IDisposable
    {
        private Transform _standTr;
        private GemPoolingManager _poolingManager;
        private bool _isSellArea;

        private void Awake()
        {
            _standTr = transform.parent.transform;
            _poolingManager = GemPoolingManager.Instance;
        }
        public IEnumerator ExecuteEnter(List<Gem> stackList)
        {
            _isSellArea = true;
            
            while (_isSellArea)
            {
                if(stackList.Count == 0) yield break;
                var targetGem = stackList[^1];
                
                targetGem.gameObject.transform.DOJump(_standTr.position, 1, 1, 0.1f)
                    .OnComplete(() =>
                    {
                        _poolingManager.ReturnPool(targetGem.gameObject);
                        stackList.Remove(targetGem);
                    });

                yield return new WaitForSeconds(0.1f);
            }

        }

        public void ExecuteExit()
        {
            _isSellArea = false;
        }
    }
}
