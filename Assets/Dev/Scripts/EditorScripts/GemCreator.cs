#if UNITY_EDITOR
using Scripts.GemManagement;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.Editor
{
    public class GemCreator : MonoBehaviour
    {
        [SerializeField] private string gemName;
        [SerializeField] private Sprite icon;
        [SerializeField] private int startPrice;
        [SerializeField] private GameObject gemModel;

        [Button]
        public void CreateGem()
        {
            var gem = Instantiate(gemModel);
            var component = gem.AddComponent<Gem>();

            component.icon = this.icon;
            component.startPrice = this.startPrice;
            component.gemName = this.gemName;

            var locationPath = $"Assets/Resources/GemTypes/{gemName}.prefab";
            locationPath = AssetDatabase.GenerateUniqueAssetPath(locationPath);
            PrefabUtility.SaveAsPrefabAsset(gem, locationPath);
            
            DestroyImmediate(gem);
        }
    }
}
#endif
