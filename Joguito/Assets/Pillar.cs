using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public RegenBar regenBar;
    public float maxRegen = 4;
    public float currentRegen;

    public GameObject Pillar1;
    public GameObject Pillar2;
    public GameObject Pillar3;
    public GameObject Pillar4;
    public int PillarCount = 4;

    void Start()
    {
        currentRegen = maxRegen;
        regenBar.SetMaxRegen(maxRegen);
    }

    void Update()
    {
       
    }
    void TakeDamage(int damage)
    {
        currentRegen = regenBar.GetRegen();
        currentRegen -= damage;
        regenBar.SetRegen(currentRegen);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Impact"))
        {
            PillarCount--;
            TakeDamage(1);  
        }
    }
}
