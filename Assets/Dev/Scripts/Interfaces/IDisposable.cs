using System.Collections;
using System.Collections.Generic;
using Scripts.GemManagement;
using UnityEngine;

public interface IDisposable
{
    public IEnumerator ExecuteEnter(List<Gem> stackList);
    public void ExecuteExit();
}
