using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public float maxHealth { get; private set; } = 100;

    public float health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void OnDead()
    {
        Debug.Log("Player Dead");
    }
}
