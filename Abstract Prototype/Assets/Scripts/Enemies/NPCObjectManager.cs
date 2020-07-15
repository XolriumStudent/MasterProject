using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class NPCObjectManager : MonoBehaviour
{
    public List<NPCTypes> npcScriptableObjects = new List<NPCTypes>();

    private void Start()
    {
        for (int i = 0; i < npcScriptableObjects.Count; i++)
        {
            npcScriptableObjects[i].npcScriptableObject.GenerateEnemy(npcScriptableObjects[i].npcScriptableObject, npcScriptableObjects[i].npcType);
        }
    }
}

[CustomEditor(typeof(NPCObjectManager))]
public class NPCObjectManagerEditor : Editor
{
    private ReorderableList npcScriptableObjects;

    private void OnEnable()
    {
        npcScriptableObjects = new ReorderableList(serializedObject, serializedObject.FindProperty("npcScriptableObjects"), true, true, true, true);

        npcScriptableObjects.drawElementCallback = (Rect rectangle, int index, bool isActive, bool isFocused) =>
        {
            var element = npcScriptableObjects.serializedProperty.GetArrayElementAtIndex(index);
            rectangle.y += 2;
            EditorGUI.PropertyField(new Rect(rectangle.x, rectangle.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("npcType"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rectangle.x + 60, rectangle.y, rectangle.width - 60 - 30, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("npcScriptableObject"), GUIContent.none);
        };

        npcScriptableObjects.drawHeaderCallback = (Rect rectangle) =>
        {
            EditorGUI.LabelField(rectangle, "NPC List");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        npcScriptableObjects.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

[Serializable]
public struct NPCTypes
{
    public EnemyType npcType;
    public NPCScriptableObject npcScriptableObject;
}
