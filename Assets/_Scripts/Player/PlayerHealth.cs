using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;

    public float health { get; set; }
    public float MaxHealth { get { return maxHealth; } }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }
}
