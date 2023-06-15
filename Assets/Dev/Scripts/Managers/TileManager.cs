using System;
using System.Collections.Generic;
using DG.Tweening;
using Scripts.Interfaces;
using Scripts.Manager;
using UnityEngine;

public class TileManager : MonoBehaviour, ICollectable
{
    private GemPoolingManager _poolingManager;
    private bool _collectable;
    private GameObject _gem;
    private Vector3 _targetPos;

    private void Awake() => InitVariables();
    private void Start() => GetNewGem();
    private void InitVariables() => _poolingManager = GemPoolingManager.Instance;
    private void GetNewGem()
    {
        _gem = _poolingManager.GetFirstInactiveGemType();
        var position = transform.position;
        _gem.SetActive(true);
        _gem.transform.position = new Vector3(position.x, position.y + 0.65f, position.z);
        _gem.transform.localScale = Vector3.zero;
        _gem.transform.DOScale(1, 5)
            .OnUpdate(() =>
            {
                if (_gem.transform.localScale.x >= 0.25f) _collectable = true;
            });

        // var sequence = DOTween.Sequence();
        // Tween collectableScale = gem.transform.DOScale(0.25f, 1.25f)
        //     .OnComplete(() =>
        //     {
        //         _collectable = true;
        //     });
        // Tween finalScale = gem.transform.DOScale(1, 3.75f);
        // sequence.Append(collectableScale);
        // sequence.Append(finalScale);
        // sequence.Play();
    }
    
    public void Execute(Transform parent, int collectCount, List<GameObject> stackList)
    {
        if(!_collectable) return;
        
        _gem.transform.DOKill();
        _gem.transform.SetParent(parent);
        
        if (stackList.Count == 0) _targetPos = Vector3.zero;
        else
        {
            var lastElement = stackList[^1];
            var gemMesh = _gem.GetComponent<MeshRenderer>();
            var gemBound = gemMesh.bounds;

            _targetPos = new Vector3(0, lastElement.transform.localPosition.y + gemBound.size.y, 0);
        }
        _gem.transform.DOLocalJump(_targetPos, 1, 1, 0.5f)
            .OnComplete(() =>
            {
                _collectable = false;
                stackList.Add(_gem);
                GetNewGem();
            });
    }
}
