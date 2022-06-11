using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class ButtonsController : MonoBehaviour
{
    public GameObject muteButton;
    public Sprite[] audioSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuClicked() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void OnSettingsClicked()
    {
        SceneManager.LoadScene("SettingsMenu", LoadSceneMode.Single);
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("LevelTest", LoadSceneMode.Single);
    }

    public void OnHelpClicked()
    {
        SceneManager.LoadScene("HelpMenu", LoadSceneMode.Single);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }

    public void OnMuteClicked() {
        if (AudioListener.volume != 1f)
        {
            AudioListener.volume = 1f;
            muteButton.GetComponentInChildren<Image>().sprite = audioSprites[1];
        }
        else {
            AudioListener.volume = 0f;
            muteButton.GetComponentInChildren<Image>().sprite = audioSprites[0];
        }
        

    }
}