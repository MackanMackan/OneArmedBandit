using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SlotCylinder))]
public class SlotCylinderDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SlotCylinder cylinder = target as SlotCylinder;

        if(GUILayout.Button("Get Slot Effect"))
        {
            cylinder.ActivateSlot();
        }
    }
}
