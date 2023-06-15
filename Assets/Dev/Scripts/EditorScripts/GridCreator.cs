using Sirenix.OdinInspector;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField] private int row = 4;
    [SerializeField] private int column= 4;
    
    private GameObject _tilePrefab; 
    private GameObject _parent;

    [Button]
    private void GenerateGrid()
    {
        _parent = new GameObject { name = $"Tile ({row}X{column})" };
        _tilePrefab = Resources.Load<GameObject>("Prefabs/Tile");
        
        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                var position = new Vector3(i * 2f, 0, j * 3f);

                var tile = Instantiate(_tilePrefab, position, Quaternion.identity, _parent.transform);
            }
        }
    }

    [Button]
    private void ClearGrid() => DestroyImmediate(_parent);
}
