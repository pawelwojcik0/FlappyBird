using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    public float TerrainWidth;
    public GameObject TerrainPrefab;

    private BirdController m_BirdController;
    private List<GameObject> SpawnedTerrain = new List<GameObject>();

    private void Start()
    {
        m_BirdController = FindObjectOfType<BirdController>();

        if (SpawnedTerrain.Count == 0)
        {
            Instantiate(TerrainPrefab, new Vector3(m_BirdController.transform.position.x + TerrainWidth * 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(TerrainPrefab, new Vector3(m_BirdController.transform.position.x + TerrainWidth * 0.5f, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
