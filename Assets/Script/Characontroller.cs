using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Characontroller : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private ParticleSystem m_deathVFX;

    private bool m_isaAlive = true;
    public TextMeshProUGUI scoreText;
    public GameObject Score;
    public Camerashake camshake;

    private void Start()
    {
        camshake = FindObjectOfType<Camerashake>();
    }
    public void TakeDamage()
    {
        KillChara();
    }

    public void KillChara()
    {
        m_deathVFX.Play();
        
        camshake.TriggerShake();

        GameObject[] Disc = GameObject.FindGameObjectsWithTag("Disc");
        foreach (GameObject obj in Disc)
        {
            Destroy(obj);
        }

        Score.GetComponent<Score>().score = 0;
        scoreText.text = "Score: " + 0;

        m_isaAlive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disc") && gameObject.GetComponent<Dash>().isdashing == false)
        {
            TakeDamage();
        }
    }
}
