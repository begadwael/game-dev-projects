using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    [SerializeField] float timeScale;
    [SerializeField] float repeatRate;

    void Update()
    {
         InvokeRepeating(nameof(reseting),timeScale, repeatRate);
    }

    void reseting()
    {
        SceneManager.LoadScene(0);
    }
}
