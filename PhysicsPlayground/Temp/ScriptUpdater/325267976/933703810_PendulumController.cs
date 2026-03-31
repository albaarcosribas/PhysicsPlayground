using UnityEngine;

public class PendulumController : MonoBehaviour
{
    Rigidbody2D rb;
    HingeJoint2D hj;


    public float mass = 1f;           // Massa de l'objecte
    public float gravityScale = 1f;   // Intensitat de la gravetat
    public float leftAngle = -60f;    // Angle màxim esquerra
    public float rightAngle = 60f;    // Angle màxim dreta
    public float damping = 0.05f;     // Reducció gradual de la velocitat

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();

        rb.mass = mass;
        rb.gravityScale = gravityScale;

        // Configura els límits del HingeJoint2D
        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = leftAngle;
        limits.max = rightAngle;
        hj.limits = limits;
        hj.useLimits = true;

        // Reducció gradual (damping) per evitar oscil·lacions eternes
        rb.angularDamping = damping;
    }

    void Update()
    {
        // Permet canviar la massa en temps real
        rb.mass = mass;
    }
}