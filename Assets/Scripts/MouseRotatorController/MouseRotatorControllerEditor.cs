using UnityEditor;

[CustomEditor(typeof(MouseRotatorController))]
[CanEditMultipleObjects]
class MouseRotatorControllerEditor : Editor
{
    private SerializedProperty useHorizRot;
    private SerializedProperty horizSens;
    private SerializedProperty useHorizClamp;
    private SerializedProperty horizClamp;

    private SerializedProperty useVertRot;
    private SerializedProperty vertSens;
    private SerializedProperty useVertClamp;
    private SerializedProperty vertClamp;

    private void OnEnable()
    {
        #region Horizontal Values
        useHorizRot = serializedObject.FindProperty("useHorizRot");
        horizSens = serializedObject.FindProperty("horizSens");
        useHorizClamp = serializedObject.FindProperty("useHorizClamp");
        horizClamp = serializedObject.FindProperty("horizClamp");
        #endregion

        #region Vertical Values
        useVertRot = serializedObject.FindProperty("useVertRot");
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

        horizSens.floatValue = EditorGUILayout.FloatField("Sensitivity", horizSens.floatValue);

        useHorizClamp.boolValue = EditorGUILayout.BeginToggleGroup("Use Clamp", useHorizClamp.boolValue);
        horizClamp.vector2Value = EditorGUILayout.Vector2Field("Clamp", horizClamp.vector2Value);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndToggleGroup();
        #endregion

        EditorGUILayout.Space(10);

        #region Vertical Rotation
        useVertRot.boolValue = EditorGUILayout.BeginToggleGroup("Use Vertical Rotation", useVertRot.boolValue);

        vertSens.floatValue = EditorGUILayout.FloatField("Sensitivity", vertSens.floatValue);

        useVertClamp.boolValue = EditorGUILayout.BeginToggleGroup("Use Clamp", useVertClamp.boolValue);
        vertClamp.vector2Value = EditorGUILayout.Vector2Field("Clamp", vertClamp.vector2Value);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndToggleGroup();
        #endregion

        serializedObject.ApplyModifiedProperties();
    }
}

