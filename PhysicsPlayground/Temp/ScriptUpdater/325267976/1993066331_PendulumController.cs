using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PendulumController : MonoBehaviour
{


    Rigidbody2D rb;
    HingeJoint2D hj;

    [Header("Pendulum Settings")]
    public float mass = 1f;           // massa del pèndol
    public float gravityScale = 1f;   // gravetat
    public float damping = 0.05f;     // fricció angular
    public float initialTorque = 1f;  // impuls inicial

    [Header("Joint Limits")]
    public float leftAngle = -60f;
    public float rightAngle = 60f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();

        rb.mass = mass;
        rb.gravityScale = gravityScale;
        rb.angularDamping = damping;

        // Configura els límits del HingeJoint
        JointAngleLimits2D limits = new JointAngleLimits2D();
        limits.min = leftAngle;
        limits.max = rightAngle;
        hj.limits = limits;
        hj.useLimits = true;

        // Impuls inicial per començar el moviment
        rb.AddTorque(initialTorque, ForceMode2D.Impulse);
    }

    void Update()
    {
        // Permet canviar massa i gravetat en temps real si vols
        rb.mass = mass;
        rb.gravityScale = gravityScale;
    }

}