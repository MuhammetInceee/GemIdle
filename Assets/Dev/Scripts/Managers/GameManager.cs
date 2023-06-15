using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GameManager : Singleton<GameManager>
{
    private float money;
    private UIManager uIManager;

    private void Awake()
    {
        uIManager = UIManager.Instance;
        money = GetMoney();
    }

    public void MoneyUpdate(float addMoney)
    {
        money += addMoney;
        PlayerPrefs.SetFloat("Money", money);
        uIManager.UpdateMoneyText(money);
    }

    public int GetMoney()
    {
        return Mathf.RoundToInt(PlayerPrefs.GetFloat("Money", 0));
    }
}


