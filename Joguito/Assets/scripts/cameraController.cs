using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player;
    void Update()
    {
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
