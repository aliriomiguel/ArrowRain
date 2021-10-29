using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public CharacterController2D controller;
    float horizontalMove = 0f;
    [SerializeField]
    private float _runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        Debug.Log("This is a test");
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
