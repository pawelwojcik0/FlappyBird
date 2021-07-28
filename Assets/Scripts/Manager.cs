using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField] private float TerrainWidth;
    [SerializeField] private float DistanseToBird;
    
    public GameObject TerrainPrefab;
    public GameObject ObstaclePrefab;


    public int Points
    {
        get { return m_points; }
        set
        {
            m_points = value;
            m_HUD.UpdatePoints(m_points);
        }
    }

    private BirdController m_BirdController;
    private ObstacleController m_ObstacleController;
    public List<GameObject> Terrains = new List<GameObject>();
    public List<GameObject> Obstacles = new List<GameObject>();
    private int m_points = 0;
    private HUDController m_HUD;

    private void Start()
    {
        m_BirdController = FindObjectOfType<BirdController>();
        m_ObstacleController = FindObjectOfType<ObstacleController>();
        m_HUD = FindObjectOfType<HUDController>();

        if (Terrains.Count == 0)

        {
            Terrains.Add (Instantiate(TerrainPrefab, new Vector3(m_BirdController.transform.position.x + TerrainWidth * 0.5f, transform.position.y, transform.position.z), Quaternion.identity));
        }

        if (Obstacles.Count == 0)
        {
            Obstacles.Add(Instantiate(ObstaclePrefab, new Vector3(m_BirdController.transform.position.x + DistanseToBird, transform.position.y, transform.position.z), Quaternion.identity));
        }



        Points = 0;
    }

    private void Update()
    {

        if (m_BirdController.transform.position.x - Terrains[Terrains.Count - 1].transform.position.x > 0.0f)
        {
            Terrains.Add(Instantiate(TerrainPrefab, new Vector3(m_BirdController.transform.position.x + TerrainWidth * 0.5f, transform.position.y, transform.position.z), Quaternion.identity));
        }

        if (Terrains.Count > 0 && m_BirdController.transform.position.x - Terrains[0].transform.position.x > TerrainWidth)
        {
            GameObject.Destroy(Terrains[0]);
            Terrains.RemoveAt(0);
        }

        if (m_BirdController.transform.position.x - Obstacles[Obstacles.Count - 1].transform.position.x > -12f)
        {
            Obstacles.Add(Instantiate(ObstaclePrefab, new Vector3(m_BirdController.transform.position.x + DistanseToBird, transform.position.y, transform.position.z), Quaternion.identity));
        }

        if (Obstacles.Count > 5 && m_BirdController.transform.position.x - Obstacles[0].transform.position.x > 5)
        {
            GameObject.Destroy(Obstacles[0]);
            Obstacles.RemoveAt(0);
        }


    }


}

