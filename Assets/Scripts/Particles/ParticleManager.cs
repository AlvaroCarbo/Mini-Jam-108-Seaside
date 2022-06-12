using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	public ParticleSystem particleCoin;
	// Singleton instance.
	public static ParticleManager Instance = null;

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

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartParticleCoin(Transform position)
	{
		var particles = Instantiate(particleCoin, position.position, position.rotation);
		//particleCoin.SetActive(true);
		Destroy(particles, particleCoin.main.duration);
	}
}

