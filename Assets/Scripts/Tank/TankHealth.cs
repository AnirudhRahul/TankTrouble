﻿using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float m_StartingHealth = 1f;          
    public Slider m_Slider;                        
    public Image m_FillImage;                      
    public Color m_FullHealthColor = Color.green;  
    public Color m_ZeroHealthColor = Color.red;
    public Color m_CoinColor = Color.blue;
    public GameObject m_ExplosionPrefab;
    public bool m_hasCoin;

    private AudioSource m_ExplosionAudio;          
    private ParticleSystem m_ExplosionParticles;   
    private float m_CurrentHealth;  
    public bool m_Dead;
    private Vector3 originalCoinPosition;
    public GameManager gameManager;


    // In the Start method, find and set the GameManager reference.

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_CurrentHealth = m_StartingHealth;
        m_Dead = false;
        m_hasCoin = false;
        SetHealthUI();
    }
    

    public void TakeDamage(float amount)
    {
        // Adjust the tank's current health, update the UI based on the new health and check whether or not the tank is dead.
        m_CurrentHealth -= amount;
        SetHealthUI();

        if(m_CurrentHealth <=0f && !m_Dead){
            OnDeath();
        }
    }

    public void GetCoin(Vector3 coinPos)
    {
        m_hasCoin = true;
        originalCoinPosition = coinPos;
        SetHealthUI();
    }
    public void DropCoin()
    {
        m_hasCoin = false;
        SetHealthUI();
    }

    private void SetHealthUI()
    {
        // Adjust the value and colour of the slider.
        m_Slider.value = 100;
        m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth/m_StartingHealth);
        if (m_hasCoin)
        {
            m_FillImage.color = m_CoinColor;
        }
    }


    private void OnDeath()
    {
        gameManager = FindObjectOfType<GameManager>();
        // Play the effects for the death of the tank and deactivate it.
        m_Dead = true;
        m_ExplosionParticles.transform.position=transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        if (m_hasCoin) gameManager.SpawnOldCoin(originalCoinPosition);

        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        //m_CurrentHealth = m_StartingHealth;
        gameObject.SetActive(false);
        //gameObject.SetActive(true);
    }
}