using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private static int m_currentHealth = 100;

    public static EnemyControls Instance { get; private set; }
  

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

    public void DamageEnemy(int damage)
    {
        m_currentHealth -= damage;

        if(m_currentHealth <= 0)
        {
            Debug.Log("Enemy Dead");
        }


        Debug.Log($"Damaged Enemy: {damage}. Remaining Health: {m_currentHealth}");
    }
}
