using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    public void EndGame() // avengers assemble
    {
        asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = $"Your Score: {finalScore}";

        gameOverDisplay.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(1);
    }

    // public void ContinueButton()
    // {
    //     AdManager.Instance.ShowAd(this);
    //     continueButton.interactable = false;
    // }

    public void Continue()
    {
        AdManager.Instance.ShowAd(gameObject.GetComponent<GameOverHandler>());
        continueButton.interactable = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    
    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;

        asteroidSpawner.enabled = true;

        gameOverDisplay.gameObject.SetActive(false);
    }
}
