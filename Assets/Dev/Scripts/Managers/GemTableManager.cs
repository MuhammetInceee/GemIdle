using TMPro;
using UnityEngine;

public class GemTableManager : Singleton<GemTableManager>
{
    private int _greenGemCount;
    private int _pinkGemCount;
    private int _yellowGemCount;

    [SerializeField] private TextMeshProUGUI greenGemCountText;
    [SerializeField] private TextMeshProUGUI pinkGemCountText;
    [SerializeField] private TextMeshProUGUI yellowGemCountText;

    private void Awake()
    {
        CountersLoad();
    }

    private void OnEnable()
    {
        greenGemCountText.text = $"Collected Gem Count: {_greenGemCount}";
        pinkGemCountText.text = $"Collected Gem Count: {_pinkGemCount}";
        yellowGemCountText.text = $"Collected Gem Count: {_yellowGemCount}";
    }

    public void GemCountUpdater(string gemName)
    {
        switch (gemName)
        {
            case "GreenGem":
                _greenGemCount++;
                greenGemCountText.text = $"Collected Gem Count: {_greenGemCount}";
                PlayerPrefs.SetInt("GreenGem", _greenGemCount);
                break;
            
            case "PinkGem":
                _pinkGemCount++;
                pinkGemCountText.text = $"Collected Gem Count: {_pinkGemCount}";
                PlayerPrefs.SetInt("PinkGem", _pinkGemCount);

                break;
            
            case "YellowGem":
                _yellowGemCount++;
                yellowGemCountText.text = $"Collected Gem Count: {_yellowGemCount}";
                PlayerPrefs.SetInt("YellowGem", _yellowGemCount);
                break;
        }
    }

    private void CountersLoad()
    {
        _greenGemCount = PlayerPrefs.GetInt("GreenGem", 0);
        _pinkGemCount = PlayerPrefs.GetInt("PinkGem", 0);
        _yellowGemCount = PlayerPrefs.GetInt("YellowGem", 0);
    }
}
