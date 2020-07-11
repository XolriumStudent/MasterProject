using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Object Modifier", menuName = "ScriptableObjects")]
public class ObjectModifierScriptableObject : ScriptableObject
{
    private InteractableController interactableController;

    public GameObject interactableObject;
    public InteractableInfluence interactableInfluence;
    public Vector3 interactableObjectLocation;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;

    public void SpawnObject()
    {
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
}

public enum UpgradeObjectType { WEAPON, ARMOR}
public enum PowerupObjectType { HEALTH, SPEED}