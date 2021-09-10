using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;

    private Rigidbody rigidbody;
    private bool movingX = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Has the mouse been clicked
        if(Input.GetMouseButtonDown(0))
        {
            movingX = !movingX;
        }

        if (!GameManager.instance.GameOver)
        {
            // Move the ball according to the direction
            if (movingX)
            {
                Vector3 ballSpeed = new Vector3(speed, 0, 0);
                rigidbody.velocity = ballSpeed;
            }
            else
            {
                Vector3 ballSpeed = new Vector3(0, 0, speed);
                rigidbody.velocity = ballSpeed;
            }
        }

        // Debug ray, makes it visual
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        // If our ball is not on a platform, game
        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rigidbody.useGravity = true;
            GameManager.instance.SetGameOver(true);
        }
    }
}
