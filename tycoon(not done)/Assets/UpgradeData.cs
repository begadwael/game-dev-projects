using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UpgradeData")]

public class UpgradeData : ScriptableObject
{
    [Serializable]
    public struct Levels
    {
        public float upgradeLevelAutoMoneyToAdd;
        public float upgradeLevelClickMoneyToAdd;
        public float upgradeAutoClickRate;
    }

    public Levels[] levels;
}
