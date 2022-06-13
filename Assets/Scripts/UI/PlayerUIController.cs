using Inputs;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText, timeTextFinishUI, coinsTextFinishUI;
    [SerializeField] public int coinsMax;

    public GameObject deadUI;
    public GameObject finishUI;

    [SerializeField] private GameObject helpUI;
    [SerializeField] private bool helpToggle;


    // Start is called before the first frame update
    void Start()
    {
        helpToggle = false;

        // if (InputHandler.Instance != null)
        InputHandler.Instance.OnPressed += OnSettingsToggle;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null)
        {
            return;
        }

        coinsText.text = GameManager.Instance.LevelCoins + " / " + coinsMax;
    }

    private void OnSettingsToggle() => helpUI.SetActive(helpToggle = !helpToggle);
    

    public void SetUpFinishUI()
    {
        timeTextFinishUI.text = "Time " + GameManager.Instance.Time;
        coinsTextFinishUI.text = "Coins " + GameManager.Instance.LevelCoins + "/" + coinsMax;
        GameManager.Instance.Time = null;
        GameManager.Instance.TimeFloat = 0f;
        GameManager.Instance.LevelCoins = 0;
    }

    private void OnDestroy()
    {
        // if (InputHandler.Instance != null)
        InputHandler.Instance.OnPressed -= OnSettingsToggle;
    }

    private void OnDisable()
    {
        // if (InputHandler.Instance != null)
        InputHandler.Instance.OnPressed -= OnSettingsToggle;
    }
}