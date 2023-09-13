using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float steerSpeed = 270f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 10f;

    void Update()
    {
        float userSteer = Input.GetAxis("Horizontal") * steerSpeed;
        float userMove = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, (-userSteer * Time.deltaTime));
        transform.Translate(0, (userMove * Time.deltaTime), 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            Debug.Log("Boostin'!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
        Debug.Log("Ouch!");
    }
}
