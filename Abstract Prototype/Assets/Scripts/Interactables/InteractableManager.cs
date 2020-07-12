using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public List<InteractableTypes> PowerupList = new List<InteractableTypes>();
    public List<InteractableTypes> UpgradeList = new List<InteractableTypes>();


    private void Start()
    {
        for (int i = 0; i < PowerupList.Count; i++)
        {
            PowerupList[i].objectModifierScriptableObject.GeneratePowerupObject(PowerupList[i].objectModifierScriptableObject, PowerupList[i].objectModifier);
        }
        for (int i = 0; i < UpgradeList.Count; i++)
        {
            UpgradeList[i].objectModifierScriptableObject.GenerateUpgradeObject(UpgradeList[i].objectModifierScriptableObject, UpgradeList[i].objectModifier);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectModifierScriptableObject instanceTest = ObjectModifierScriptableObject.Create(new ObjectModifierScriptableObjectConfig()
            {
                interactableType = InteractableType.NORMAL,
                interactableInfluence = InteractableInfluence.POWERUP,
                interactableObjectLocation = new Vector3(-18, 0.5f, -17),
                upgradeObjectType = UpgradeObjectType.WEAPON,
                upgradeModifier = 0,
                powerupAmount = 10,
                powerupObjectType = PowerupObjectType.SPEED
            });
            instanceTest.GeneratePowerupObject(instanceTest, instanceTest.interactableType);
        }
    }
}

/// <summary>
/// Custom Editor functie voor mijn Objecten te laten werken. In de InteractableController.cs zijn twee lijsten: powerupList en upgradeList. Deze worden in deze class opgeroepen en bijgevuld door de Custom InspectorField.
/// Hier kan ik door behulp van de struct InteractableTypes ook meteen aangeven hoeveel van elk Object in de scene zullen komen. Hier zal later meer functionaliteit bij komen.
/// Date: 11/07/2020
/// </summary>
[CustomEditor(typeof(InteractableManager))]
public class InteractableManagerEditor : Editor
{
    private ReorderableList powerupList;
    private ReorderableList upgradeList;

    private void OnEnable()
    {
        powerupList = new ReorderableList(serializedObject, serializedObject.FindProperty("PowerupList"), true, true, true, true);
        upgradeList = new ReorderableList(serializedObject, serializedObject.FindProperty("UpgradeList"), true, true, true, true);

        powerupList.drawElementCallback = (Rect rectangle, int index, bool isActive, bool isFocused) =>
        {
            var element = powerupList.serializedProperty.GetArrayElementAtIndex(index);
            rectangle.y += 2;
            EditorGUI.PropertyField(new Rect(rectangle.x, rectangle.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("objectModifier"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rectangle.x + 60, rectangle.y, rectangle.width - 60 - 30, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("objectModifierScriptableObject"), GUIContent.none);
        };

        upgradeList.drawElementCallback = (Rect rectangle, int index, bool isActive, bool isFocused) =>
        {
            var element = upgradeList.serializedProperty.GetArrayElementAtIndex(index);
            rectangle.y += 2;
            EditorGUI.PropertyField(new Rect(rectangle.x, rectangle.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("objectModifier"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rectangle.x + 60, rectangle.y, rectangle.width - 60 - 30, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("objectModifierScriptableObject"), GUIContent.none);
        };

        powerupList.drawHeaderCallback = (Rect rectangle) =>
        {
            EditorGUI.LabelField(rectangle, "Power Up List");
        };

        upgradeList.drawHeaderCallback = (Rect rectangle) =>
        {
            EditorGUI.LabelField(rectangle, "Upgrade List");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        powerupList.DoLayoutList();
        upgradeList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

[Serializable]
public struct InteractableTypes
{
    public InteractableType objectModifier;
    public ObjectModifierScriptableObject objectModifierScriptableObject;
}
