using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/IntegerObject", fileName = "NewIntegerObject")]
public class IntegerObject : ScriptableObject
{
    [SerializeField] private int Value;
    public int value => Value;
}