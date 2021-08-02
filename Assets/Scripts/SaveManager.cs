using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SaveManager : Singleton<SaveManager>
{
    public int MaxPoint;

    private Manager m_manager;
    private HUDController m_HUD;
    

    private void Start()
    {
        m_manager = FindObjectOfType<Manager>();
        m_HUD = FindObjectOfType<HUDController>();
        LoadSettings();

    }
    public void SaveSettings()
    {
        if (m_manager.Points > MaxPoint)
        {
            PlayerPrefs.SetInt("MaxPoint", m_manager.Points - 1);
        }
        PlayerPrefs.SetFloat("Audio", AudioListener.volume);
    }

    public void LoadSettings()
    {
        MaxPoint = PlayerPrefs.GetInt("MaxPoint", MaxPoint);
        PlayerPrefs.GetFloat("Audio", AudioListener.volume);
    }

}
