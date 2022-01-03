using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Control player movements.
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float speed;
    public int health = 5;
    private int score = 0;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        speed = speed * 100f;
    }

    /// <summary>
    /// Update for physics.
    /// </summary>
    void FixedUpdate()
    {
        PlayerMovement();
    }

    /// <summary>
    /// Handles player movements.
    /// </summary>
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        m_Rigidbody.AddForce(playerMovement);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("<color=#DE4B00>Game Over!</color>");
            SceneManager.LoadScene("maze");
        }
    }

    /// <summary>
    /// Detect if current game object trigger another game object.
    /// </summary>
    /// <param name="other">Other game object.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            Debug.Log($"<color=#FFFF00>Score: {score}</color>");
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log($"<color=#FF0000>Health {health}</color>");
        }
        if (other.tag == "Goal")
        {
            Debug.Log("<color=#00FF00>You win!</color>");
        }
    }
}
