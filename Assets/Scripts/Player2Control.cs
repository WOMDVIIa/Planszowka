using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    [SerializeField] float moveForce;
    [SerializeField] float jumpForce;

    Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float forwardBackwardInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");
        //playerRb.AddForce(gameObject.transform.forward * forwardBackwardInput * moveForce);

        transform.Translate(Vector3.forward * forwardBackwardInput * moveForce);
        transform.Rotate(Vector3.up * rotationInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
