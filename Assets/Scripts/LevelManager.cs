using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private Manager m_Manager;
    private BirdController m_Bird;
    private float Velocity;
    
    public float GapHeight;

    private void Start()
    {
        m_Manager = FindObjectOfType<Manager>();
        m_Bird = FindObjectOfType<BirdController>();

        if (m_Manager.Points == 0)
        {
            GapHeight = -2f;
        }
    }


    private void Update()
    {
        if (m_Manager.Points < 10)
        {
            m_Bird.Velocity = 4f;
            GapHeight = -2f;
        }
        else if (m_Manager.Points >= 10 && m_Manager.Points < 20)
        {
            m_Bird.Velocity = 5f;
            GapHeight = -3f;
        }
        else if (m_Manager.Points >= 20 && m_Manager.Points < 30)
        {
            m_Bird.Velocity = 6f;
            GapHeight = -3.5f;
        }
        else if (m_Manager.Points >= 30 && m_Manager.Points < 40)
        {
            m_Bird.Velocity = 8f;
            GapHeight = -4f;
        }
        else
        {
            m_Bird.Velocity = 10f;
            GapHeight = -4.5f;
        }
    }
}
