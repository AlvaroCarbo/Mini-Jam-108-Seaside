using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MenuButtonsController : MonoBehaviour
    {
        public GameObject muteButton;
        public Sprite[] audioSprites;
        
        [SerializeField] private GameObject levelsPanel;
        
        // Start is called before the first frame update
        void Start()
        {
            if (SceneManager.GetActiveScene().name.Equals("SettingsMenu 1"))
            {
                if (GameManager.Instance.isMuted)
                {
                    muteButton.GetComponent<Image>().sprite = audioSprites[0];
                }
                else
                {
                    muteButton.GetComponent<Image>().sprite = audioSprites[1];
                }
            }
        }

        public void OnRetryClicked()
        {
            GameManager.Instance.Time = null;
            GameManager.Instance.TimeFloat = 0f;
            GameManager.Instance.isPaused = false;
            GameManager.Instance.LevelCoins = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        public void OnMenuClicked()
        {
            GameManager.Instance.LevelCoins = 0;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        public void OnSettingsClicked()
        {
            SceneManager.LoadScene("SettingsMenu 1", LoadSceneMode.Single);
        }


        public void OnNextLevelClicked()
        {
            GameManager.Instance.Time = null;
            GameManager.Instance.TimeFloat = 0f;
            GameManager.Instance.isPaused = false;
            GameManager.Instance.isFinished = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }

        public void OnPlayClicked()
        {
            levelsPanel.SetActive(true);
        }

        public void OnHomeClicked(GameObject menuToClose)
        {
            menuToClose.SetActive(false);
        }

        public void OnHelpClicked()
        {
            SceneManager.LoadScene("HelpMenu", LoadSceneMode.Single);
        }

        public void OnExitClicked()
        {
            Application.Quit();
        }

        public void OnMuteClicked()
        {
            if (AudioListener.volume != 0.5f)
            {
                GameManager.Instance.isMuted = false;
                AudioListener.volume = 0.5f;
                muteButton.GetComponentInChildren<Image>().sprite = audioSprites[1];
            }
            else
            {
                GameManager.Instance.isMuted = true;
                AudioListener.volume = 0f;
                muteButton.GetComponentInChildren<Image>().sprite = audioSprites[0];
            }
        }
        
        public void LoadScene(string sceneName)
        {
            GameManager.Instance.isFinished = false;
            GameManager.Instance.isPaused = false;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}