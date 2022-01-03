using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Control the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; // Distance between player and camera

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    /// <summary>
    /// Better function to handle camera
    /// </summary>
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
