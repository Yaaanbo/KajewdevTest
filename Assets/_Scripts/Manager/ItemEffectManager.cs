using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{
    public static ItemEffectManager instance;

    [field: SerializeField] public PlayerHealth playerHealth { get; set; }
    [field: SerializeField] public PlayerController playerController { get; set; }

    //UI Events
    public Action<float, float> OnHpUpdated;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    public void AddHealthPercentage(float _healthPercentage)
    {
        playerHealth.health += playerHealth.health * _healthPercentage / 100;

        OnHpUpdated?.Invoke(playerHealth.health, playerHealth.maxHealth);

        if (playerHealth.health >= playerHealth.maxHealth)
            playerHealth.health = playerHealth.maxHealth;
    }

    public void AddHealthOverTime(int _healAmount, float _healDelay, float _hpToAdd)
    {
        StartCoroutine(HOTCouroutine());

        IEnumerator HOTCouroutine()
        {
            while (_healAmount > 0)
            {
                _healAmount--;
                playerHealth.health += _hpToAdd;
                OnHpUpdated?.Invoke(playerHealth.health, playerHealth.maxHealth);

                if (playerHealth.health >= playerHealth.maxHealth)
                {
                    playerHealth.health = playerHealth.maxHealth;
                    yield break;
                }

                yield return new WaitForSeconds(_healDelay);
            }
        }
    }

    public void ApplyDamageOverTime(int _dotAmount, float _dotDelay, float _hpToSubtract)
    {
        StartCoroutine(DOTCoroutine());

        IEnumerator DOTCoroutine()
        {
            while(_dotAmount > 0)
            {
                _dotAmount--;
                playerHealth.health -= _hpToSubtract;
                OnHpUpdated?.Invoke(playerHealth.health, playerHealth.maxHealth);

                if(playerHealth.health <= 0)
                {
                    playerHealth.health = 0;
                    playerHealth.OnDead();
                    yield break;
                }

                yield return new WaitForSeconds(_dotDelay);
            }
        }
    }

    public void IncreaseRunSpeed(float _buffDuration, float _speedMultiplier)
    {
        StartCoroutine(IncreaseSpeedCoroutine());

        IEnumerator IncreaseSpeedCoroutine()
        {
            playerController.moveSpeed *= _speedMultiplier;
            yield return new WaitForSeconds(_buffDuration);
            playerController.moveSpeed /= _speedMultiplier;
        }
    }

    public void DecreaseRunSpeed(float _debuffDuration, float _speedDivisor)
    {
        StartCoroutine(DecreaseSpeedCoroutine());

        IEnumerator DecreaseSpeedCoroutine()
        {
            playerController.moveSpeed /= _speedDivisor;
            yield return new WaitForSeconds(_debuffDuration);
            playerController.moveSpeed *= _speedDivisor;
        }
    }
}
