using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(KeyRotatorController))]
[CanEditMultipleObjects]
class KeyRotatorControllerEditor : Editor
{
    private SerializedProperty useHorizRot;
    private SerializedProperty horizKeyNeg;
    private SerializedProperty horizKeyPos;
    private SerializedProperty horizSens;
    private SerializedProperty useHorizClamp;
    private SerializedProperty horizClamp;

    private SerializedProperty useVertRot;
    private SerializedProperty vertKeyNeg;
    private SerializedProperty vertKeyPos;
    private SerializedProperty vertSens;
    private SerializedProperty useVertClamp;
    private SerializedProperty vertClamp;

    private void OnEnable()
    {
        #region Horizontal Values
        useHorizRot = serializedObject.FindProperty("useHorizRot");
        horizKeyNeg = serializedObject.FindProperty("horizKeyNeg");
        horizKeyPos = serializedObject.FindProperty("horizKeyPos");
        horizSens = serializedObject.FindProperty("horizSens");
        useHorizClamp = serializedObject.FindProperty("useHorizClamp");
        horizClamp = serializedObject.FindProperty("horizClamp");
        #endregion

        #region Vertical Values
        useVertRot = serializedObject.FindProperty("useVertRot");
        vertKeyNeg = serializedObject.FindProperty("vertKeyNeg");
        vertKeyPos = serializedObject.FindProperty("vertKeyPos");
        vertSens = serializedObject.FindProperty("vertSens");
        useVertClamp = serializedObject.FindProperty("useVertClamp");
        vertClamp = serializedObject.FindProperty("vertClamp");
        #endregion
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        #region Horizontal Rotation
        useHorizRot.boolValue = EditorGUILayout.BeginToggleGroup("Use Horizontal Rotation", useHorizRot.boolValue);

        horizKeyNeg.intValue = (int)(KeyCode)EditorGUILayout.EnumPopup("Negative Key", (KeyCode)horizKeyNeg.intValue);
        horizKeyPos.intValue = (int)(KeyCode)EditorGUILayout.EnumPopup("Positive Key", (KeyCode)horizKeyPos.intValue);

        horizSens.floatValue = EditorGUILayout.FloatField("Sensitivity", horizSens.floatValue);

        useHorizClamp.boolValue = EditorGUILayout.BeginToggleGroup("Use Clamp", useHorizClamp.boolValue);
        horizClamp.vector2Value = EditorGUILayout.Vector2Field("Clamp", horizClamp.vector2Value);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndToggleGroup();
        #endregion

        EditorGUILayout.Space(10);

        #region Vertical Rotation
        useVertRot.boolValue = EditorGUILayout.BeginToggleGroup("Use Vertical Rotation", useVertRot.boolValue);

        vertKeyNeg.intValue = (int)(KeyCode)EditorGUILayout.EnumPopup("Negative Key", (KeyCode)vertKeyNeg.intValue);
        vertKeyPos.intValue = (int)(KeyCode)EditorGUILayout.EnumPopup("Positive Key", (KeyCode)vertKeyPos.intValue);

        vertSens.floatValue = EditorGUILayout.FloatField("Sensitivity", vertSens.floatValue);

        useVertClamp.boolValue = EditorGUILayout.BeginToggleGroup("Use Clamp", useVertClamp.boolValue);
        vertClamp.vector2Value = EditorGUILayout.Vector2Field("Clamp", vertClamp.vector2Value);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndToggleGroup();
        #endregion

        serializedObject.ApplyModifiedProperties();
    }
}

