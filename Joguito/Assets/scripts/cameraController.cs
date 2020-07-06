using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        UnityEngine.Camera.main.orthographicSize = 6;
    }
    void Update()
    {
        UnityEngine.Camera.main.orthographicSize = UnityEngine.Camera.main.orthographicSize + 1.5f * Time.deltaTime;
        if (UnityEngine.Camera.main.orthographicSize > 10)
        {
            UnityEngine.Camera.main.orthographicSize = 10; // Max size
        }
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        else
        {
            print("player n encontrado");
            enabled = false;
        }
    }
}
