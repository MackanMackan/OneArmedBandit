using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private List<SlotHandler> m_slotHandlers;
    [SerializeField] private bool m_allSlotsStopped = true;
    [SerializeField] private int m_amountOfSlotsSpinning;

    private void StartSpinningSlots()
    {
        m_allSlotsStopped = false;
        m_amountOfSlotsSpinning = m_slotHandlers.Count;
    }

    public void StopNextSlotCylinder(InputAction.CallbackContext context) {
        if (!m_allSlotsStopped && context.started)
        {

        }
    }
}
