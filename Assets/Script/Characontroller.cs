using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Characontroller : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] private ParticleSystem m_deathVFX;

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

        StartCoroutine(Reload(0.5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disc") && gameObject.GetComponent<Dash>().isdashing == false)
        {
            TakeDamage();
        }
    }
    IEnumerator Reload(float sleep)
    {
        yield return new WaitForSeconds(sleep);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
