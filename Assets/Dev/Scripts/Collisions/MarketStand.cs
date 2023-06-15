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
        private GameManager _gameManager;
        private GemTableManager _gemTableManager;
        private bool _isSellArea;

        private void Awake()
        {
            _standTr = transform.parent.transform;
            _poolingManager = GemPoolingManager.Instance;
            _gameManager = GameManager.Instance;
            _gemTableManager = GemTableManager.Instance;
        }
        public IEnumerator ExecuteEnter(List<Gem> stackList)
        {
            _isSellArea = true;
            
            while (_isSellArea)
            {
                if(stackList.Count == 0) yield break;
                var targetGem = stackList[^1];
                var price = targetGem.startPrice + targetGem.gameObject.transform.localScale.x * 100;
                
                targetGem.gameObject.transform.DOJump(_standTr.position, 1, 1, 0.1f)
                    .OnComplete(() =>
                    {
                        _poolingManager.ReturnPool(targetGem.gameObject);
                        _gemTableManager.GemCountUpdater(targetGem.gemName);
                        stackList.Remove(targetGem);
                    });
                
                _gameManager.MoneyUpdate(price);
                yield return new WaitForSeconds(0.1f);
            }

        }

        public void ExecuteExit()
        {
            _isSellArea = false;
        }
    }
}
