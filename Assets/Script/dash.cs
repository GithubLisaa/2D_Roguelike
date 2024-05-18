using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool isdashing = false;
    public float MoveSpeed;
    public Rigidbody2D rb2d;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;
    public GameObject Hitbox;

    private Vector2 MoveInput;
    private float activeMoveSpeed;
    private float dashCounter;
    private float dashCoolCounter;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        MoveInput.Normalize();

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                isdashing = false;
                gameObject.GetComponent<TrailRenderer>().emitting = false;
                activeMoveSpeed = MoveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                isdashing = true;
                gameObject.GetComponent<TrailRenderer>().emitting = true;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

            }
        }

        rb2d.velocity = MoveInput * activeMoveSpeed;
    }
}