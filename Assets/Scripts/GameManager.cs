using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip backGroundMusic;
    public bool isMuted;
    public int LevelCoins;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
       // AudioManager.Instance.PlayMusic(backGroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
