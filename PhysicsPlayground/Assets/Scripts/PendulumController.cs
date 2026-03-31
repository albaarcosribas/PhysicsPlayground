using UnityEngine;
using UnityEngine.UI;

using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public float mass = 1.0f;
    public Transform lineTransform;
    public Transform sphereTransform;
    public Slider lengthSlider;   


    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (lengthSlider != null)
        {
            // Set initial slider value to match current length
            lengthSlider.value = lineTransform.localScale.z;

            // Listener to call OnSliderChanged when value changes
            lengthSlider.onValueChanged.AddListener(OnSliderChanged);
        }
    }

    void Update()
    {
        // Update mass
        if (rb.mass != mass)
        {
            rb.mass = mass;
        }
    }

  
    void OnSliderChanged(float value)
    {
        if (lineTransform != null)
        {
            // Scale line change based on slider value
            Vector3 scale = lineTransform.localScale;
            scale.z = value;
            lineTransform.localScale = scale;

            // Keep bob at the end of the line
            if (sphereTransform != null)
            {
                sphereTransform.localPosition = new Vector3(0, -value, 0);
            }
        }
    }
}