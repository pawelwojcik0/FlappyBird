using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private float GapMidPoint;
    [SerializeField] private AudioClip Point;

    private float TotalHeight;
    private float UpColumnPosition;
    private float DownColumnPosition;
    private SpriteRenderer UpColumn;
    private SpriteRenderer DownColumn;
    private AudioSource m_AudioSource;
    private Manager m_Manager;
    private LevelManager m_Level;
    private float GapHeight;


    private void Start()
    {
        m_Manager = FindObjectOfType<Manager>();
        m_Level = FindObjectOfType<LevelManager>();
        m_AudioSource = GetComponent<AudioSource>();
        TotalHeight = GetComponent<BoxCollider2D>().size.y;
        DownColumn = transform.Find("DownColumn").gameObject.GetComponent<SpriteRenderer>();
        UpColumn = transform.Find("UpColumn").gameObject.GetComponent<SpriteRenderer>();

        UpdateObstacleParms();
        Debug.Log("GapHeight: " + GapHeight);
    }


    private void UpdateObstacleParms()
    {

        GapMidPoint = Random.Range(7.5f, 12.5f);
        GapHeight = m_Level.GapHeight;

        UpColumnPosition = TotalHeight - GapMidPoint - (GapHeight / 2);
        DownColumnPosition = GapMidPoint - (GapHeight / 2);

        UpColumn.size = new Vector2(UpColumn.size.x, UpColumnPosition);
        DownColumn.size = new Vector2(DownColumn.size.x, DownColumnPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bird"))
        {
            m_Manager.Points++;
            m_AudioSource.PlayOneShot(Point);
        }
    }

    private void Level()
    {
        if (m_Manager.Points < 10)
        {
            GapHeight = -2f;
        }
        else if (m_Manager.Points >= 10)
        {
            GapHeight = -3.5f;
        }
        else if (m_Manager.Points >= 20)
        {
            GapHeight = -5;
        }
        else if (m_Manager.Points >= 30)
        {
            GapHeight = -5f;
        }
        else
        {
            GapHeight = -5f;
        }
    }


}
