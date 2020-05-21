using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactOb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
