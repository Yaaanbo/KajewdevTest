using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public float maxHealth { get; private set; } = 100;

    public float health { get; set; }

    [Header("On Player Dead")]
    [SerializeField] private GameObject originalBody;
    [SerializeField] private GameObject ragDollBody;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void OnDead()
    {
        originalBody.SetActive(false);
        ragDollBody.SetActive(true);
    }
}
