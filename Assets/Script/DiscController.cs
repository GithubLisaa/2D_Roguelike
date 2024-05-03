using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscController : MonoBehaviour
{
    [SerializeField] private Transform m_rotationHandler;
    [SerializeField] private float m_rotationSpeed = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_rotationHandler.Rotate(Vector3.forward * m_rotationSpeed * Time.deltaTime);
    }
}
