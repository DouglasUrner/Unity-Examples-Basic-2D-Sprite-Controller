using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float speedStep = 0;
    public string axisX = "Horizontal";
    public string axisY = "Vertical";

    private Rigidbody2D rb;
    public int sceneNumber = 0;

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

    /*
     * OnCollisionEnter() is called whenever we collide with another game
     * object with a collider component. We are passed a Collision 2D object,
     * other, that we can examine to determine what we collided with. When we
     * collide with an object the behavior of our sprite and of the object we
     * collided with is determined by the Unity physics engine - if you just
     * want to detect the collision, use OnTriggerEnter() and set the IsTrigger
     * property on the game object's collider.
     */
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Memory":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Memory: '"
                          + other.gameObject.name + "'");
                // Inform the player about the memory.
                Describe(other.gameObject);
                break;

            case "Obstacle":
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Obstacle: '"
                          + other.gameObject.name + "'");
                // Destroy the obstacle.
                Destroy(other.gameObject);
                break;

            case "Passage":
                /*
                 * This could also happen in an OnTriggerEnter() handler, but for now we set up an
                 * invisible sprite and use the collision to trigger loading the next scene...
                 */
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with Passage: '"
                          + other.gameObject.name + "'");

                LoadNextScene(++sceneNumber);
                // Go a little faster on the next level.
                speed = speed + speedStep;
                break;

            case "Wall":
                // Nothing to do here (at least for now).
                break;

            default:
                Debug.Log("Player Controller: OnCollisionEnter2D(): collision with untagged object: '"
                          + other.gameObject.name + "'");
                // TODO: throw exception?
                break;
        }
    }

    void Describe(GameObject memory)
    {
        throw new System.NotImplementedException();
    }

    void LoadNextScene(int sceneNumber)
    {
        Scene scene;
        var parameters = new LoadSceneParameters(LoadSceneMode.Single);
        
        // throw new System.NotImplementedException();
        Debug.Log("PlayerController: LoadNextScene(): loading scene '" + sceneNumber + "'");
        scene = SceneManager.LoadScene("Scene_" + sceneNumber, parameters);
        Debug.Log("sceneNumber = '" + sceneNumber + "'");
        Debug.Log("scene = '" + scene.name + "'");
    }
}
