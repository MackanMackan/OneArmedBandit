using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private static int m_maxHealth = 100;
    private static int m_currentHealth = 100;
    private static int m_currentCoins = 0;

    public static PlayerControls Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void DamagePlayer(int damage)
    {
        m_currentHealth -= damage;

        if(m_currentHealth <= 0)
        {
            Debug.Log("Dead");
        }


        Debug.Log($"Damaged: {damage}");
    }
    public void HealPlayer(int healValue)
    {
        m_currentHealth += healValue;

        if(m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }

        Debug.Log($"Damaged: {healValue}");
    }

    public void TransactionCoins(int transaction)
    {
        if(m_currentCoins + transaction <= 0)
        {
            Debug.Log("Cant afford that item");
            return;
        }

        m_currentCoins += transaction;
    }
}
