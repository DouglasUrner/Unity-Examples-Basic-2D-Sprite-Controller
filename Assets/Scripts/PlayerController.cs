using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public string axisX = "Horizontal";
    public string axisY = "Vertical";

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxis(axisX);
        var moveY = Input.GetAxis(axisY);

        rb.velocity = new Vector2(moveX * speed, moveY * speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Memory":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Memory: '"
                          + other.gameObject.name + "'");
                break;
            
            case "Obstacle":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Obstacle: '"
                          + other.gameObject.name + "'");
                break;
            
            case "Passage":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Passage: '"
                          + other.gameObject.name + "'");
                break;
            
            default:
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with untagged object: '"
                          + other.gameObject.name + "'");
                // TODO: throw exception?
                break;
        }
    }
}
