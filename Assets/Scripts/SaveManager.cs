using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SaveManager : Singleton<SaveManager>
{
    public int MaxPoint;

    private Manager m_manager;

    private void Start()
    {
        m_manager = FindObjectOfType<Manager>();
        LoadSettings();
    }
    public void SaveSettings()
    {
        if (m_manager.Points > MaxPoint)
        {
            PlayerPrefs.SetInt("MaxPoint", m_manager.Points - 1);
        }

    }

    public void LoadSettings()
    {
        MaxPoint = PlayerPrefs.GetInt("MaxPoint", MaxPoint);
    }
}
