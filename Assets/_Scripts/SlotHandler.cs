using System;
using UnityEngine;

public class SlotHandler : MonoBehaviour
{
    [SerializeField] private Slot m_slot;
    [SerializeField] private MeshRenderer m_slotRenderer;
    private void Start()
    {
        UpdateSlotType(m_slot);
    }

    public void UpdateSlotType(Slot newSlot)
    {
        if (newSlot == null) {
            Debug.LogError("Slot was null.");
            return;
        }

        m_slotRenderer.material = newSlot.Material;
        m_slot = newSlot;
    }

    public void TriggerSlotEffect()
    {
        switch (m_slot.Type)
        {
            case Slot.SlotType.Damage:
                DealDamageEnemy();
                break;
            case Slot.SlotType.Heal:
                HealPlayer();
                break;
            case Slot.SlotType.Coin:
                GiveCoinsToPlayer();
                break;

        }
    }

    private void DealDamageEnemy()
    {
        EnemyControls.Instance.DamageEnemy(UnityEngine.Random.Range(m_slot.MinValue, m_slot.MaxValue));
    }

    private void HealPlayer()
    {
        PlayerControls.Instance.HealPlayer(UnityEngine.Random.Range(m_slot.MinValue, m_slot.MaxValue));
    }

    private void GiveCoinsToPlayer()
    {
        PlayerControls.Instance.TransactionCoins(UnityEngine.Random.Range(m_slot.MinValue, m_slot.MaxValue));
    }
}
