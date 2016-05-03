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
            "CurveEvaluation",
            "AnimationCurve",
            "OnFinish",
            "m_Script");
        GUILayout.Space(7);

        BetweenBase trans = this.target as BetweenBase;
        trans.Duration = EditorGUILayout.FloatField("Duration", trans.Duration);
        trans.style = (BetweenBase.Style)EditorGUILayout.EnumPopup("Style", trans.style);
        trans.DeactivateOn = (BetweenBase.Deactivate)EditorGUILayout.EnumPopup("Deactivate On", trans.DeactivateOn);
        trans.CurveEvaluation = EditorGUILayout.BeginToggleGroup("Curve Evaluation", trans.CurveEvaluation);
        trans.AnimationCurve = EditorGUILayout.CurveField("Animation Curve", trans.AnimationCurve);
        EditorGUILayout.EndToggleGroup();
        GUILayout.Space(7);
        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("OnFinish"), true);

        this.serializedObject.ApplyModifiedProperties();
    }
}
