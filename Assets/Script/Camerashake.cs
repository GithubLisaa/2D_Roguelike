using UnityEngine;

public class Camerashake : MonoBehaviour
{
    // Durée totale de la secousse
    public float shakeDuration = 0.5f;

    // Amplitude de la secousse
    public float shakeMagnitude = 0.2f;

    // Temps de déclin de la secousse
    public float dampingSpeed = 1.0f;

    private Vector3 initialPosition;
    private float currentShakeDuration = 0f;

    void Awake()
    {
        if (Camera.main != null)
        {
            initialPosition = Camera.main.transform.localPosition;
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            currentShakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    // Fonction publique pour déclencher la secousse
    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
    }
}