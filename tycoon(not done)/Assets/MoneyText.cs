using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    Text _MoneyText;
    GameManager gameManager;

    private void Awake()
    {
        _MoneyText = GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        _MoneyText.text = $"Money:{gameManager.money}";
    }
}
