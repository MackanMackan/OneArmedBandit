using System.Collections;
using UnityEngine;
using _Scripts.Extensions;
using UnityEngine.Events;

public class SlotCylinder : MonoBehaviour
{

    [SerializeField] private GameObject m_cylinder;
    [SerializeField] private GameObject m_rayCastPosition;
    [SerializeField] private float m_spinSpeed;
    [SerializeField] private Vector2 m_slowDownTimeRange;

    private bool m_willStopSpinning;

    public bool m_isSpinning;
    public UnityEvent OnStoppedSpinning;

    public void StartSpinning()
    {
        m_isSpinning = true;
        StartCoroutine(SpinCylinder());
    }

    private IEnumerator SpinCylinder()
    {
        while (m_isSpinning)
        {
            if (m_willStopSpinning) break;

            m_cylinder.transform.Rotate(Vector3.forward, m_spinSpeed * Time.deltaTime);
            yield return null;
        }

        float slowDownTime = Random.Range(m_slowDownTimeRange.x, m_slowDownTimeRange.y);

        for (float timeSpent = 0; timeSpent < slowDownTime; timeSpent += Time.deltaTime) {
            float speed = Mathf.Lerp(m_spinSpeed, 0, MathX.Normalize(timeSpent, slowDownTime));
            m_cylinder.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            yield return null;
        }


        m_isSpinning = false;
        m_willStopSpinning = false;
        OnStoppedSpinning?.Invoke();
    }

    public void StopSpinning()
    {
        m_willStopSpinning = true;
    }

    public void ActivateSlot()
    {
        Physics.Raycast(m_rayCastPosition.transform.position, m_rayCastPosition.transform.forward, out RaycastHit hit);

        if(hit.collider.transform.parent.TryGetComponent<SlotHandler>(out SlotHandler slotHandler))
        {
            slotHandler.TriggerSlotEffect();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(m_rayCastPosition.transform.position, m_rayCastPosition.transform.forward);
    }
}
