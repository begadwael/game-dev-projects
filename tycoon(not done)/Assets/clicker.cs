using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicker : MonoBehaviour
{
    GameManager gameManager;
    

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Money Giver"))
            {
                Click(gameManager.clickMoneyToAdd);
            }

            if (hit.collider != null && hit.collider.GetComponent<Upgrade>())
            {
                hit.collider.GetComponent<Upgrade>().upgrade();
            }
        }

        AutoClick();
    }

    void AutoClick()
    {
        if (Time.time > gameManager.autoClickRate + gameManager.lastClick && gameManager.canAutoClick)
        {
            Click(gameManager.autoMoneyToAdd);
            gameManager.lastClick = Time.time;
        }
    }

    void Click(float moneyToAdd)
    {
        gameManager.giveMoney(moneyToAdd);
    }
}
