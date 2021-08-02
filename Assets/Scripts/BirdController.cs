using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{

    [SerializeField] private float UpMovement;
    [SerializeField] private float RotationSpeed;
    [SerializeField] new Vector3 TargetRotation = new Vector3(0f, 0f, 30f);
    [SerializeField] AudioClip Up;

    private Rigidbody2D m_rigidbody;
    private float step;
    private AudioSource m_AudioSource;
    private Manager m_Manager;

    public float Velocity;
    private void Start()
    {
        m_Manager = FindObjectOfType<Manager>();
        m_AudioSource = GetComponent<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        step = Time.deltaTime * RotationSpeed;
    }

    private void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        m_rigidbody.velocity = new Vector2(Velocity, m_rigidbody.velocity.y);
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(Vector2.up * UpMovement);
            m_AudioSource.PlayOneShot(Up);
        }

        if (m_rigidbody.velocity.y > 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(TargetRotation), step);
        }

        else if (m_rigidbody.velocity.y < 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-TargetRotation), step);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}

    
