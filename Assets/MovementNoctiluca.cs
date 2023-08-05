using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoctiluca : MonoBehaviour
{

    public float movementSpeed = 1;
    public float rotationRange = 1;
    
    private float xRotation;
    private float yRotation;
    private float zRotation;

    private float rotateTime = 0;
    public float timeBeforeChangeDirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        xRotation = Random.Range(-1 * rotationRange, rotationRange);
        yRotation = Random.Range(-1 * rotationRange, rotationRange);
        zRotation = Random.Range(-1 * rotationRange, rotationRange);
    }

    // Update is called once per frame
    void Update()
    {

        rotateTime += Time.deltaTime;

        if(rotateTime >= timeBeforeChangeDirection)
        {
            xRotation = Random.Range(-1 * rotationRange, rotationRange);
            yRotation = Random.Range(-1 * rotationRange, rotationRange);
            zRotation = Random.Range(-1 * rotationRange, rotationRange);

            rotateTime = 0;
        }

        this.transform.Rotate(xRotation, 0, zRotation, Space.World);

        this.transform.Translate(this.transform.forward * movementSpeed * Time.deltaTime, Space.World);


    }
}
