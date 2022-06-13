using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
	public ParticleSystem particleCoin, particleDust;
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

	public float time;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;
	}

	public void StartParticleCoin(Transform position)
	{
		var particles = Instantiate(particleCoin, position.position, position.rotation);
		//particleCoin.SetActive(true);
		Destroy(particles, particleCoin.main.duration);
	}
	
	public void StartParticleDust(Transform position)
	{
		//particleCoin.SetActive(true);
		var particles = Instantiate(particleDust, position.position, position.rotation);

			time = 0f;
			Destroy(particles, 2f);
	}
	//	ParticleManager.Instance.StartParticleCoin(other.transform);

}

