using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed;
    public ParticleSystem blossoms;
    public bool isGrounded;
    public Animator running;
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update ()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (running.GetBool("running") == true)
        {
            Speed = 4;
            blossoms.enableEmission = true;
        } else
        {
            Speed = 2;
            blossoms.enableEmission = false;
        }
    }
}