using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI PointsText;
    [SerializeField] private TMPro.TextMeshProUGUI BestScore;
    [SerializeField] private Button UnMute;
    [SerializeField] private Button Mute;
    [SerializeField] private Button VolumeUp;
    [SerializeField] private Button VolumeDown;

    private SaveManager m_SaveManager;
    private BirdController m_Bird;
    private Rigidbody2D m_BirdRigid;
    private Animator m_BirdAnimator;
    private AudioSource m_BirdAudioSoruce;
    private bool isSimulated;
    private float AudioVolume;

    private void Start()
    {
        m_SaveManager = FindObjectOfType<SaveManager>();
        m_Bird = FindObjectOfType<BirdController>();
        m_BirdRigid = m_Bird.GetComponent<Rigidbody2D>();
        m_BirdAnimator = m_Bird.GetComponent<Animator>();
        m_BirdAudioSoruce = m_Bird.GetComponent<AudioSource>();

        UnMute.onClick.AddListener(delegate { OnMute(); });
        Mute.onClick.AddListener(delegate { OnUnMute(); });
        VolumeUp.onClick.AddListener(delegate { OnChangeVolume(true); });
        VolumeDown.onClick.AddListener(delegate { OnChangeVolume(false); });

        isSimulated = true;
        
        AudioListener.volume = 0.5f;
        AudioVolume = AudioListener.volume;

        PlayPause(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSimulated = !isSimulated;

            if (isSimulated == true)
            {
                PlayPause(true);
            }

            else if (isSimulated == false)
            {
                PlayPause(false);
                BestScore.text = "Best score: " + m_SaveManager.MaxPoint;
            }
            
        }
    }

    public void UpdatePoints(int points)
    {
        PointsText.text = "" + points;
    }

    private void OnUnMute()
    {
        UnMute.gameObject.SetActive(true);
        Mute.gameObject.SetActive(false);
        AudioListener.volume = AudioVolume;
    }

    private void OnMute()
    {
            UnMute.gameObject.SetActive(false);
            Mute.gameObject.SetActive(true);
            AudioListener.volume = 0.0f;
    }

    private void OnChangeVolume(bool vol)
    {
        float newValue = AudioListener.volume;

        if (vol)
        {
            newValue += 0.1f;
        }

        else
        {
            newValue -= 0.1f;
        }

        newValue = Mathf.Clamp01(newValue);
        AudioListener.volume = newValue;
        AudioVolume = newValue;
    }

    private void PlayPause(bool state)
    {

        UnMute.gameObject.SetActive(true);
        Mute.gameObject.SetActive(false);
        VolumeUp.gameObject.SetActive(!state);
        VolumeDown.gameObject.SetActive(!state);
        BestScore.gameObject.SetActive(!state);
        m_BirdRigid.simulated = state;
        m_BirdAnimator.enabled = state;
        m_BirdAudioSoruce.enabled = state;
    }

}