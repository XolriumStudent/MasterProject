using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Object Modifier", menuName = "ScriptableObjects")]
public class ObjectModifierScriptableObject : ScriptableObject
{
    public GameObject interactableObject;
    public InteractableInfluence interactableInfluence;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;
}

public enum UpgradeObjectType { WEAPON, ARMOR}
public enum PowerupObjectType { HEALTH, SPEED}