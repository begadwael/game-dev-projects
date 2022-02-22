using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject StartMenu;
    public InputField usernameField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("instance already exists, destorying object");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        StartMenu.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }
}
