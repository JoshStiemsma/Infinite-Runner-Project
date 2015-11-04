using UnityEngine;
using System.Collections;

public class ParticleColorBoostChange : MonoBehaviour {
	private GameObject player;
	new public ParticleSystem m_currentParticleEffect;
	new public ParticleSystem.Particle []ParticleLis;
	private bool inBoost;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		ParticleSystem m_currentParticleEffect = (ParticleSystem)GetComponent("ParticleSystem");
		ParticleSystem.Particle []ParticleList = new  ParticleSystem.Particle[m_currentParticleEffect.particleCount];
		inBoost = player.GetComponent<playercontroller> ().inBoost;
	}
	
	// Update is called once per frame
	void Update () {

		ParticleSystem m_currentParticleEffect = (ParticleSystem)GetComponent("ParticleSystem");
		ParticleSystem.Particle []ParticleList = new  ParticleSystem.Particle[m_currentParticleEffect.particleCount];

		m_currentParticleEffect.GetParticles(ParticleList);
		inBoost = player.GetComponent<playercontroller> ().inBoost;
	
		if (inBoost == false) {
			for (int i = 0; i < ParticleList.Length; ++i) {
				float LifeProcentage = (ParticleList [i].lifetime / ParticleList [i].startLifetime);
				ParticleList [i].color = Color.Lerp (Color.blue, Color.white, LifeProcentage);
			}   
		}
		if (inBoost) {
			for (int i = 0; i < ParticleList.Length; ++i) {
				float LifeProcentage = (ParticleList [i].lifetime / ParticleList [i].startLifetime);
				ParticleList [i].color = Color.red;
			}   
		}
		m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
	}
}
