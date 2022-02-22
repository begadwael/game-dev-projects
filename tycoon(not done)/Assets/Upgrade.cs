using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    #region Upgrade Config variables 

    [Header("Upgrade Config")]
    [SerializeField] UpgradeData upgradeData;
    [Space]
    [SerializeField] bool upgradesAutoMoneyToAdd = true;
    [SerializeField] bool upgradesClickMoneyToAdd = true;
    [SerializeField] bool upgradesAutoClickRate = true;

    #endregion

    int maxUpgradeLevels;
    int currentUpgradeLevel;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        maxUpgradeLevels = upgradeData.levels.Length;
        currentUpgradeLevel = 0;
    }

    public void upgrade()
    {
        UpgradeLogic();
    }

    void UpgradeLogic()
    {
        if (currentUpgradeLevel < maxUpgradeLevels && upgradesAutoMoneyToAdd) //AutoMoneyToAdd
        {
            gameManager.IncreaseAutoMoneyToAdd(upgradeData.levels[currentUpgradeLevel].upgradeLevelAutoMoneyToAdd);
            currentUpgradeLevel++;
        }

        if (currentUpgradeLevel < maxUpgradeLevels && upgradesClickMoneyToAdd) //ClickMoneyToAdd
        {
            gameManager.IncreaseClickMoneyToAdd(upgradeData.levels[currentUpgradeLevel].upgradeLevelClickMoneyToAdd);
            currentUpgradeLevel++;
        }

        if (currentUpgradeLevel < maxUpgradeLevels && upgradesAutoClickRate)
        {
            gameManager.DecreaseAutoClickRate(upgradeData.levels[currentUpgradeLevel].upgradeAutoClickRate); //AutoClickRate
            currentUpgradeLevel++;
        }
    }
}