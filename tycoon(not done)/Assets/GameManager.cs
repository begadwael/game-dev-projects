using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public float money = 100;

    [Header("Money Settings")]
    public float clickMoneyToAdd = 10;
    public float autoMoneyToAdd = 7;

    [Header("auto-Click Settings")]
    public float autoClickRate = 0.5f;
    public bool canAutoClick = true;
    [HideInInspector] public float lastClick = 0f;

    #region money

    public void giveMoney(float amount)
    {
        money += amount;
    }

    public void TakeMoney(float amount)
    {
        money -= amount;
    }
    #endregion

    #region clickMoneyToAdd

    public void IncreaseClickMoneyToAdd(float amount)
    {
        clickMoneyToAdd += amount;
    }

    public void DecreaseClickMoneyToAdd(float amount)
    {
        clickMoneyToAdd -= amount;
    }

    public void SetClickMoneyToAdd(float amount)
    {
        clickMoneyToAdd = amount;
    }
    #endregion

    #region autoMoneyToAdd

    public void IncreaseAutoMoneyToAdd(float amount)
    {
        autoMoneyToAdd += amount;
    }

    public void DecreaseAutoMoneyToAdd(float amount)
    {
        autoMoneyToAdd -= amount;
    }

    public void SetAutoMoneyToAdd(float amount)
    {
        autoMoneyToAdd = amount;
    }
    #endregion

    #region autoClickRate

    public void IncreaseAutoClickRate(float amount)
    {
        autoClickRate += amount;
    }

    public void DecreaseAutoClickRate(float amount)
    {
        autoClickRate -= amount;
    }

    public void SetAutoClickRate(float amount)
    {
        autoClickRate = amount;
    }
    #endregion
}
