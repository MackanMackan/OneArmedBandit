using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "Scriptable Objects/Slot")]
public class Slot : ScriptableObject
{
    public Material Material;
    [TextArea] public string Description;
    public int MinValue;
    public int MaxValue;
    public SlotType Type;

    public enum SlotType {Damage, Heal, Coin}

}
