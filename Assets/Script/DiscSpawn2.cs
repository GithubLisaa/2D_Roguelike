using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpawner2 : MonoBehaviour
{
    [SerializeField] private GameObject m_discPrefab;
    [SerializeField] private float m_spawnFrequency = 2;

    void Start()
    {
        StartCoroutine(C_Spawn());
    }

    private void SpawnDisc()
    {
        GameObject spawnedDisc = Instantiate(m_discPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator C_Spawn()
    {
        yield return new WaitForSeconds(m_spawnFrequency);
        SpawnDisc();
        StartCoroutine(C_Spawn());
    }
}

