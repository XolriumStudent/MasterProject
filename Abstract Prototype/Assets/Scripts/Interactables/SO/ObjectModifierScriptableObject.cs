using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "Object Modifier", menuName = "ScriptableObjects/Object_Modifier")]
public class ObjectModifierScriptableObject : ScriptableObject
{
    private InteractableController interactableController;

    private GameObject interactableObject;
    public InteractableType interactableType;
    public InteractableInfluence interactableInfluence;
    public Vector3 interactableObjectLocation;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;

    public void SpawnObject()
    {
        interactableObject = GameObject.Find("InteractableObjectReference");
        GameObject newInteractableObject = Instantiate(interactableObject, interactableObjectLocation, Quaternion.identity);
        newInteractableObject.AddComponent<InteractableController>();

        interactableController = newInteractableObject.GetComponent<InteractableController>();
        interactableController.interactableInfluence = interactableInfluence;
        interactableController.interactableObjectLocation = interactableObjectLocation;
    }

    public void GenerateUpgradeObject(ObjectModifierScriptableObject objectModifierScriptableObject, InteractableType interactableType)
    {
        SpawnObject();
        interactableController.upgradeObjectType = upgradeObjectType;
        interactableController.upgradeModifier = upgradeModifier;
        interactableController.objectModifierScriptableObject = objectModifierScriptableObject;
        interactableController.InteractableType = interactableType;
    }

    public void GeneratePowerupObject(ObjectModifierScriptableObject objectModifierScriptableObject, InteractableType interactableType)
    {
        SpawnObject();
        interactableController.powerupObjectType = powerupObjectType;
        interactableController.powerupAmount = powerupAmount;
        interactableController.objectModifierScriptableObject = objectModifierScriptableObject;
        interactableController.InteractableType = interactableType;
    }

    public static ObjectModifierScriptableObject Create(ObjectModifierScriptableObjectConfig config)
    {
        return CreateInstance<ObjectModifierScriptableObject>().Init(config);
    }

    public ObjectModifierScriptableObject Init(ObjectModifierScriptableObjectConfig config)
    {
        interactableType = config.interactableType;
        interactableInfluence = config.interactableInfluence;
        interactableObjectLocation = config.interactableObjectLocation;
        upgradeObjectType = config.upgradeObjectType;
        upgradeModifier = config.upgradeModifier;
        powerupAmount = config.powerupAmount;
        powerupObjectType = config.powerupObjectType;
        return this;
    }
}

public struct ObjectModifierScriptableObjectConfig
{
    public GameObject interactableObject;
    public InteractableType interactableType;
    public InteractableInfluence interactableInfluence;
    public Vector3 interactableObjectLocation;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;
}

public enum UpgradeObjectType { WEAPON, ARMOR}
public enum PowerupObjectType { HEALTH, SPEED}