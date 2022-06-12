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
        if (SceneManager.GetActiveScene().name.Equals("SettingsMenu 1")) {
            if (GameManager.Instance.isMuted) {
                muteButton.GetComponent<Image>().sprite = audioSprites[0];
            }
            else {
                muteButton.GetComponent<Image>().sprite = audioSprites[1];
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRetryClicked()
    {
        GameManager.Instance.Time = null;
        GameManager.Instance.TimeFloat = 0f;
        GameManager.Instance.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name , LoadSceneMode.Single);
    }
    public void OnMenuClicked() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void OnSettingsClicked()
    {
        SceneManager.LoadScene("SettingsMenu 1", LoadSceneMode.Single);
    }
    public void OnNextLevelClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    public void OnPlayClicked()
    {
        GameManager.Instance.isFinished = false;
        GameManager.Instance.isPaused = false;
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
        if (AudioListener.volume != 0.5f)
        {
            GameManager.Instance.isMuted = false;
            AudioListener.volume = 0.5f;
            muteButton.GetComponentInChildren<Image>().sprite = audioSprites[1];
        }
        else {
            GameManager.Instance.isMuted = true;
            AudioListener.volume = 0f;
            muteButton.GetComponentInChildren<Image>().sprite = audioSprites[0];
        }
        

    }
}
