using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{
    public static ItemEffectManager instance;

    [field: SerializeField] public PlayerHealth playerHealth { get; set; }
    [field: SerializeField] public PlayerController playerController { get; set; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void AddHealth(float _health)
    {
        playerHealth.health += _health;

        if (playerHealth.health >= playerHealth.MaxHealth)
            playerHealth.health = playerHealth.MaxHealth;
    }


    public IEnumerator IncreasePlayerSpeed(float _buffDuration, float _speedMultiplier)
    {
        playerController.moveSpeed *= _speedMultiplier;
        yield return new WaitForSeconds(_buffDuration);
        playerController.moveSpeed /= _speedMultiplier;
    }

}
