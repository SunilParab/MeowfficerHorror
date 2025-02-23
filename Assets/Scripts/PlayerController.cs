using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerControls {

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    GameObject model;
    [SerializeField]
    float moveAcceleration = 5;
    [SerializeField]
    float maxSpeed = 50;
    [SerializeField]
    float sensitivity = 5;

    public int score = 0;
    
    //Input systems
    InputAction moveAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        //Rotate to mouse
        float rotateHorizontal = Input.GetAxis("Mouse X");
        //Turn player
        transform.Rotate(transform.up * rotateHorizontal * sensitivity * Time.deltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveValue = new Vector3(moveInput.x, 0, moveInput.y);

        
        rb.AddForce(transform.rotation*(moveAcceleration*moveValue),ForceMode.Force);
        

        if (rb.linearVelocity.magnitude > maxSpeed) {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
 
    }


    void OnCollisionEnter(Collision collision) {
        GameObject other = collision.gameObject;
        if (other.tag.Equals("Enemy")) {
            //die
        }
    }

}

}