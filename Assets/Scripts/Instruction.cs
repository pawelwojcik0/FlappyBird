using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instruction : MonoBehaviour
{
    [SerializeField] GameObject Text; 

    void Update()
    {
        Text.transform.localScale = Vector3.Lerp(new Vector3(0.5f, 0.5f, 0.5f), Vector3.one, (Mathf.Sin(Time.time * 2f) + 1) / 2);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("flappybird", LoadSceneMode.Single);
        }
    }
}
