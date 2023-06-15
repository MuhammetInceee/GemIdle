using System.Collections.Generic;
using Scripts.GemManagement;
using UnityEngine;

namespace Scripts.Interfaces
{
    public interface ICollectable
    {
        public void Execute(Transform parent, List<Gem> stackList);
    }
}
