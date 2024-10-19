using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
<<<<<<< Updated upstream
=======
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
>>>>>>> Stashed changes

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    private float timeSinceLastChange = float.MaxValue;

    private CharacterStatsHandler statHandler;
    
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OninvinciblilityEnd;

    [SerializeField] public float CurrentHealth { get; private set; }
<<<<<<< Updated upstream
=======
    private int MaxHealth => statHandler.CurrentStat.maxHealth;

>>>>>>> Stashed changes
    public bool IsAttacked { get; private set; }

    private int MaxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
<<<<<<< Updated upstream
        if(true == IsAttacked && timeSinceLastChange < healthChangeDelay)
=======
        if (true == IsAttacked && timeSinceLastChange < healthChangeDelay)
>>>>>>> Stashed changes
        {
            timeSinceLastChange += Time.deltaTime;

            if(timeSinceLastChange >= healthChangeDelay )
            {
                OninvinciblilityEnd?.Invoke();
                IsAttacked = false;
            }
        }
    }


    public bool ChangeHealth(float change)
    {
        if(change > 0)
        {
            CurrentHealth += change;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
            OnHeal?.Invoke();

            return true;
        }

        if (false == CheackHealthChangeDelayEnd())
            return false;

        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        OnDamage?.Invoke();
        IsAttacked = true;

        timeSinceLastChange = 0f;

        if(CurrentHealth == 0)
            OnDeath?.Invoke();

        return true;
    }

    private bool CheackHealthChangeDelayEnd()
    {
        return timeSinceLastChange >= healthChangeDelay;
    }
}
