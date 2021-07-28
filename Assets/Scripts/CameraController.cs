using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private BirdController m_BirdController; 

    void Start()
    {

        m_BirdController = FindObjectOfType<BirdController>();
        
    }


    void Update()
    {

        transform.position = new Vector3(m_BirdController.transform.position.x + 8f, transform.position.y, transform.position.z);

    }

}
