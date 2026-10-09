using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private List<SlotCylinder> m_slotCylinders;
    [SerializeField] private bool m_allSlotsStopped = true;
    private int slotIndex = 0;
    private int m_stoppedSlots = 0;

    private void Start()
    {
        foreach (SlotCylinder slot in m_slotCylinders)
        {
            slot.OnStoppedSpinning.AddListener(CheckIfAllCylindersStopped);
        }

        StartSpinningSlots();
    }

    private void StartSpinningSlots()
    {
        m_allSlotsStopped = false;

        foreach (SlotCylinder slotCylinder in m_slotCylinders)
        {
            slotCylinder.StartSpinning();
        }
    }

    public void StopNextSlotCylinder(InputAction.CallbackContext context) {
        if (!m_allSlotsStopped && context.started)
        {
            if (slotIndex == m_slotCylinders.Count) return;

            m_slotCylinders[slotIndex].StopSpinning();
            slotIndex++;
            return;
        }

        if (m_allSlotsStopped && context.started)
        {
            StartSpinningSlots();
        }
    }

    public void CheckIfAllCylindersStopped()
    {
        m_stoppedSlots++;

        if(m_stoppedSlots  == m_slotCylinders.Count)
        {
            m_allSlotsStopped = true;
            m_stoppedSlots = 0; 
            slotIndex = 0;
            foreach (SlotCylinder slotCylinder in m_slotCylinders)
            {
                slotCylinder.ActivateSlot();
            }
        }
    }
}
