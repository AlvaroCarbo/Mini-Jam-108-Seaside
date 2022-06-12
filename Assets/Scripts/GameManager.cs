using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backGroundMusic;
    public bool isMuted, isFinished, isPaused;
	public string Time;
	public float TimeFloat;
    public int LevelCoins;
	// Singleton instance.
	public static GameManager Instance = null;

	// Initialize the singleton instance.
	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
		}
		
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
	}
	// Start is called before the first frame update
	void Start()
    {
       AudioManager.Instance.PlayMusic(backGroundMusic);
    }
	public void LevelFinished() {
		GameObject.FindGameObjectWithTag("UIPlayer").GetComponent<PlayerUIController>().SetUpFinishUI();
		GameObject.FindGameObjectWithTag("UIPlayer").GetComponent<PlayerUIController>().FinishUI.SetActive(true);
		isFinished = true;
		Destroy(GameObject.FindGameObjectWithTag("Player").gameObject); 
	}
	public void PlayerDead() {
		GameObject.FindGameObjectWithTag("UIPlayer").GetComponent<PlayerUIController>().DeadUI.SetActive(true);
		isPaused = true;
		GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(false);
	}
	public string formatFloatToTime(float value)
	{
		string minutes = ((int)value / 60).ToString();
		string seconds = (value % 60).ToString("f1");
		string timer = minutes + ":" + seconds;
		return timer;
	}

	// Update is called once per frame
	void Update()
    {
		if (GameObject.FindGameObjectWithTag("Player") == null) { return; }
		if (LevelCoins == GameObject.FindGameObjectWithTag("UIPlayer").GetComponent<PlayerUIController>().coinsMax) {
			LevelFinished();
		}
    }
}
