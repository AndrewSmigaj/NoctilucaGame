using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera playerCamera;
    private float xRot;
    private float yRot;

    private float deltaX;
    private float deltaY;

    private Vector3 direction;

    public float speed = 50;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        this.playerCamera = Camera.main;
        rb = GetComponent<Rigidbody>();

    }

    public float turnSpeed = 0.5f;

    // Update is called once per frame
    void LateUpdate()
    {

        yRot += deltaX;
        xRot -= deltaY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        //x uses y deltas and rotates everything
        // playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        this.transform.rotation = Quaternion.Euler(xRot * turnSpeed, yRot * turnSpeed, 0);

        //this.transform.Translate(direction * speed * Time.deltaTime);
        //y only rotates camera

        //transform from world to local coordinates
        Vector3 localDirection = this.transform.TransformDirection(direction);

        //apply move
        rb.MovePosition(this.gameObject.transform.position + (localDirection * speed * Time.deltaTime));


    }

    void OnLook(InputValue value)
    {
        Vector2 deltas = value.Get<Vector2>();
        deltaX = deltas.x;
        deltaY = deltas.y;

        Debug.Log("Hey, Camera Look!");
    }

    void OnMovement(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        direction = new Vector3(input.x, 0, input.y);

        Debug.Log(value.Get<Vector2>());
    }

}
