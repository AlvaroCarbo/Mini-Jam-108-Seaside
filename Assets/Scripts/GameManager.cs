using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backGroundMusic;
    public bool isMuted;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
