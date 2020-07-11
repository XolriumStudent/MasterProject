using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectModifierScriptableObject))]
public class ObjectModifierScriptableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectModifierScriptableObject objectModifierScriptableObject = target as ObjectModifierScriptableObject;

        //objectModifierScriptableObject.interactableObject = (GameObject)EditorGUILayout.ObjectField(objectModifierScriptableObject.interactableObject, typeof(GameObject), false);
        objectModifierScriptableObject.interactableInfluence = (InteractableInfluence)EditorGUILayout.EnumPopup("Object Modifier Type: ", objectModifierScriptableObject.interactableInfluence);
        EditorGUILayout.Space();
        objectModifierScriptableObject.interactableObjectLocation = EditorGUILayout.Vector3Field("Spawn Location: ", objectModifierScriptableObject.interactableObjectLocation);
        EditorGUILayout.Space();

        switch (objectModifierScriptableObject.interactableInfluence)
        {
            case InteractableInfluence.POWERUP:
                objectModifierScriptableObject.upgradeModifier = 0;
                objectModifierScriptableObject.upgradeObjectType = UpgradeObjectType.WEAPON;
                objectModifierScriptableObject.powerupObjectType = (PowerupObjectType)EditorGUILayout.EnumPopup("Powerup Type: ", objectModifierScriptableObject.powerupObjectType);
                EditorGUILayout.Space();
                switch (objectModifierScriptableObject.powerupObjectType)
                {
                    case PowerupObjectType.HEALTH:
                        objectModifierScriptableObject.powerupAmount = EditorGUILayout.FloatField("Health Amount: ", objectModifierScriptableObject.powerupAmount);
                        break;
                    case PowerupObjectType.SPEED:
                        objectModifierScriptableObject.powerupAmount = EditorGUILayout.FloatField("New Speed Value: ", objectModifierScriptableObject.powerupAmount);
                        break;
                }
                break;

            case InteractableInfluence.UPGRADE:
                objectModifierScriptableObject.powerupAmount = 0f;
                objectModifierScriptableObject.powerupObjectType = PowerupObjectType.HEALTH;
                objectModifierScriptableObject.upgradeObjectType = (UpgradeObjectType)EditorGUILayout.EnumPopup("Upgrade Type: ", objectModifierScriptableObject.upgradeObjectType);
                EditorGUILayout.Space();
                objectModifierScriptableObject.upgradeModifier = EditorGUILayout.IntField("Upgrade Modifier: ", objectModifierScriptableObject.upgradeModifier);
                break;
        }
    }
}
