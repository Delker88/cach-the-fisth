using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    private bool _isMoving;
    private Transform myTransform;
    private float leftLimitViewPort;
    private float rightLimitViewPort;
    private float playerOffset = 2;

    [SerializeField]
    private float speedMovement;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        leftLimitViewPort = Camera.main.ViewportToWorldPoint(Vector3.zero).x + playerOffset;
        rightLimitViewPort = Camera.main.ViewportToWorldPoint(Vector3.one).x - playerOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving)
        {
            SetMovement();
        }
        if (transform.position.x > rightLimitViewPort)
        {
            SetLimit(rightLimitViewPort);
        }
        if (transform.position.x < leftLimitViewPort)
        {
            SetLimit(leftLimitViewPort);
        }
    }
    

    private void SetLimit(float limit)
    {
        myTransform.position = new Vector3(limit, myTransform.position.y, 0);
    }

    private void SetMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        myTransform.position += Vector3.right * ( speedMovement * inputX * Time.deltaTime);
    }
}
