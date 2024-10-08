using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    // Variables to control the slime's wobble animation
    public float scaleAmount = 0.05f;  // How much the slime grows/shrinks
    public float wobbleSpeed = 2f;     // How fast the wobble happens

    // Variables to control slime squishing animation
    public float squishAmount = 0.2f;  // How much the slime squishes
    public float squishSpeed = 3f;     // How fast the squish happens

    private Vector3 originalScale;

    void Start()
    {
        // Store the original scale of the sprite
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Apply wobble effect (growing/shrinking effect)
        float wobble = Mathf.Sin(Time.time * wobbleSpeed) * scaleAmount;

        // Apply squish effect (squishing up/down)
        float squish = Mathf.Sin(Time.time * squishSpeed) * squishAmount;

        // Combine wobble and squish effects for X and Y axes
        transform.localScale = new Vector3(originalScale.x + wobble, originalScale.y - squish, originalScale.z);
    }
}
