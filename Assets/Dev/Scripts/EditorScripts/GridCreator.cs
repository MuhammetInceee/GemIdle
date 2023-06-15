using Sirenix.OdinInspector;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    public int row = 4;
    public int column= 4;
    public GameObject tilePrefab; 
    // public GameObject gemPrefab; 
    private GameObject _parent;

    [Button]
    private void GenerateGrid()
    {
        _parent = new GameObject { name = $"Tile ({row}X{column})" };

        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < column; j++)
            {
                var position = new Vector3(i * 1.2f, 0, j * 1.2f);

                var tile = Instantiate(tilePrefab, position, Quaternion.identity, _parent.transform);
            }
        }
    }

    [Button]
    private void ClearGrid() => DestroyImmediate(_parent);
}
