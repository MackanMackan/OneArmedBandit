using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "Scriptable Objects/Slot")]
public class Slot : ScriptableObject
{
    [SerializeField] private Sprite m_image;
    [SerializeField, TextArea] private string m_description;
    [SerializeField] private int m_minValue;
    [SerializeField] private int m_maxValue;
}
