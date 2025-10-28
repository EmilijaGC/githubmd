using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [Header("Flicker Settings")]
    public float minTime = 0.05f;     // Minimum time light stays on/off
    public float maxTime = 0.3f;      // Maximum time light stays on/off
    public float minIntensity = 0.2f; // Minimum light intensity
    public float maxIntensity = 1.5f; // Maximum light intensity
    public bool randomizeIntensity = true; // Toggle to randomize brightness

    private Light flickerLight;
    private float timer;

    void Start()
    {
        flickerLight = GetComponent<Light>();
        if (flickerLight == null)
        {
            Debug.LogError("No Light component found on " + gameObject.name);
            enabled = false;
            return;
        }

        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Toggle light on/off
            flickerLight.enabled = !flickerLight.enabled;

            // Optional: Randomize intensity each flicker
            if (randomizeIntensity && flickerLight.enabled)
            {
                flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            }

            // Reset timer
            timer = Random.Range(minTime, maxTime);
        }
    }
}
