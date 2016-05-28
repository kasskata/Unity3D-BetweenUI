using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BetweenBase), true)]
public class CTransBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawPropertiesExcluding(this.serializedObject,
            "Duration",
            "style",
            "DeactivateOn",
            "WantCurve",
            "AnimationCurve",
            "OnFinish",
            "m_Script");
        GUILayout.Space(7);

        BetweenBase trans = this.target as BetweenBase;
        if (trans != null)
        {
            trans.Duration = EditorGUILayout.FloatField("Duration", trans.Duration);
            trans.Style = (BetweenBase.StyleType)EditorGUILayout.EnumPopup("Style", trans.Style);
            trans.DeactivateOn = (BetweenBase.Deactivate)EditorGUILayout.EnumPopup("Deactivate On", trans.DeactivateOn);
            trans.WantCurve = EditorGUILayout.BeginToggleGroup("Curve Evaluation", trans.WantCurve);
            trans.AnimationCurve = EditorGUILayout.CurveField("Animation Curve", trans.AnimationCurve);
        }

        EditorGUILayout.EndToggleGroup();
        GUILayout.Space(7);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("OnFinish"), true);

        this.serializedObject.ApplyModifiedProperties();
    }
}
