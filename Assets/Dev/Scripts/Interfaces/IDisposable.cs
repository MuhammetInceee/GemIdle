using System.Collections;
using System.Collections.Generic;
using Scripts.GemManagement;

public interface IDisposable
{
    public IEnumerator ExecuteEnter(List<Gem> stackList);
    public void ExecuteExit();
}
