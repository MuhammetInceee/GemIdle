using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    private const int PanelUpValue = 2000;
    private const int PanelDownValue = 56;
    
    private GameManager _gameManager;
    
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private RectTransform gemPanel;
    [SerializeField] private Button gemPanelButton;
    [SerializeField] private Button gemPanelCloseButton;

    private void Awake()
    {
        GetReferences();
        InitVariables();
    }
    private void GetReferences()
    {
        _gameManager = GameManager.Instance;
    }

    private void InitVariables()
    {
        moneyText.text = _gameManager.GetMoney().ToString(CultureInfo.InvariantCulture);
        gemPanelButton.onClick.AddListener(GemPanelOpen);
        gemPanelCloseButton.onClick.AddListener(GemPanelClose);
    }
    public void UpdateMoneyText(float money)
    {
        moneyText.transform.DOScale(Vector3.one * 1.3f, 0.2f)
            .OnComplete(() =>
            {
                moneyText.text = Mathf.RoundToInt(money).ToString();
                moneyText.transform.DOScale(Vector3.one, 0.2f);
            });
    }
    private void GemPanelOpen()
    {
        gemPanelButton.gameObject.SetActive(false);
        gemPanel.DOAnchorPosY(PanelDownValue, 0.5f)
            .SetEase(Ease.OutSine);
    }
    private void GemPanelClose()
    {
        gemPanel.DOAnchorPosY(PanelUpValue, 0.5f)
            .SetEase(Ease.InSine)
            .OnComplete(() => { gemPanelButton.gameObject.SetActive(true); });
    }
}
