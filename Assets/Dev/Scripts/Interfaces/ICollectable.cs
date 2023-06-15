using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Interfaces
{
    public interface ICollectable
    {
        public void Execute(Transform parent, int collectCount, List<GameObject> stackList);
    }
}
