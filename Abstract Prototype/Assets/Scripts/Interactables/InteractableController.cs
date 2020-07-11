using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    public InteractableInfluence interactableInfluence;
    public Vector3 interactableObjectLocation;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;
    public ObjectModifierScriptableObject objectModifierScriptableObject;

    private InteractableManager interactableManager;

    private void Awake()
    {
        interactableManager = GameObject.Find("InteractableObjectManager").GetComponent<InteractableManager>();
        transform.SetParent(interactableManager.transform);
    }
}
