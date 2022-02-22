using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;

    public static AdManager Instance;

#if UNITY_ANDROID
    private string gameId = "4233095";
#elif UNITY_IOS
    private string gameId = "4233094";
#endif


    private GameOverHandler gameOverHandler;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;

        Advertisement.Show("RewardedVideo");
    }


    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped:
                // AD was skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("AD failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready");
    }

    
}
