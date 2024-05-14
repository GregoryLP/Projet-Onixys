using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controler : MonoBehaviour {
    public float speed = 10f;
    public float sensitivity = 2f;
    private float xAxisClamp = 0.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController player;
    public GameObject eyes;

    float rotX;
    float rotY;

    bool Sprint = false;

    private void Awake()
    {
        player = GetComponent<CharacterController>();
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update () {
        if (Input.GetKeyDown("r")) Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown("t")) Cursor.lockState = CursorLockMode.None;


            if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Sprint == true)
            {
                Sprint = false;
                speed = 10f;
            }
            else Sprint = true;
        }
        if (Sprint == true) speed = 20f;
 
            if (player.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            rotX = Input.GetAxis("Mouse X") * sensitivity;
            rotY = Input.GetAxis("Mouse Y") * sensitivity;

        xAxisClamp += rotY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            rotY = 0.0f;
        }
        if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            rotY = 0.0f;
        }
        transform.Rotate(0, rotX, 0);
        eyes.transform.Rotate(-rotY, 0, 0);
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        player.Move(moveDirection * Time.deltaTime);
    }
}