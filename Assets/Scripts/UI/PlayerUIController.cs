using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText, timeTextFinishUI, coinsTextFinishUI;
    [SerializeField] public int coinsMax;
    [SerializeField] public GameObject DeadUI, FinishUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null) {
            return;
        }
        coinsText.text = GameManager.Instance.LevelCoins + " / " + coinsMax;
    }

    public void SetUpFinishUI()
    {
        timeTextFinishUI.text = "Time "+GameManager.Instance.Time;
        coinsTextFinishUI.text = "Coins "+GameManager.Instance.LevelCoins+"/"+coinsMax;
        GameManager.Instance.Time = null;
        GameManager.Instance.TimeFloat = 0f;
        GameManager.Instance.LevelCoins = 0;
    }
}
