using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform player;
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3((player.position.x - 3f), (player.position.y + 2f), transform.position.z);
        }
        else
        {
            print("player n encontrado");
            enabled = false;
        }
    }
}
