using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Manager
{
    public class GemPoolingManager : Singleton<GemPoolingManager>
    {
        private const int PoolSize = 150;
        [SerializeField] private GameObject[] gemTypes;
        [SerializeField] private List<GameObject> gemPool;
        private void Start()
        {
            ReadGems();
            CreatePool();
        }

        private void ReadGems() => gemTypes = Resources.LoadAll<GameObject>("GemTypes");

        private void CreatePool()
        {
            var gemsPerType = PoolSize / gemTypes.Length;
            var remainingGems = PoolSize % gemTypes.Length;

            for (var i = 0; i < gemTypes.Length; i++)
            {
                var gemsToAdd = gemsPerType;

                if (i < remainingGems)
                    gemsToAdd++;

                for (var j = 0; j < gemsToAdd; j++)
                {
                    var gem = Instantiate(gemTypes[i], Vector3.zero, Quaternion.identity, transform);
                    gem.SetActive(false);
                    gemPool.Add(gem);
                }
            }
            
            gemPool.Shuffle();
        }

        private GameObject GetFirstInactiveGemType()
        {
            var firstInactiveGemType = gemPool.FirstOrDefault(gemType => !gemType.activeSelf);
            return firstInactiveGemType;
        }
    }
}
