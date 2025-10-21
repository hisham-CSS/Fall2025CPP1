using UnityEngine;

//This will be attached to the player gameobject to control its movement
public class PlayerController : MonoBehaviour
{
    //a speed value that will control how fast the player moves horizontally
    public float speed = 10f;

    //reference to the Rigidbody2D component
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the Rigidbody2D component attached to the same gameobject - we assume that it exists
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //grab our horizontal input value - negative button is moving to the left (A/Left Arrow), positive button is moving to the right (D/Right Arrow) - cross platform compatible so it works with keyboard, joystick, etc. -1 to 1 range where zero means no input
        float hValue = Input.GetAxis("Horizontal");

        //set the rigidbody's horizontal velocity based on the input value multiplied by our speed - vertical velocity remains unchanged
        rb.linearVelocityX = hValue * speed;
    }
}