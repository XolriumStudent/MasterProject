using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private InteractableManager interactableManager;

    public InteractableType InteractableType;
    public ObjectModifierScriptableObject objectModifierScriptableObject;
    public InteractableInfluence interactableInfluence;
    public Vector3 interactableObjectLocation;

    public UpgradeObjectType upgradeObjectType;
    public int upgradeModifier;

    public PowerupObjectType powerupObjectType;
    public float powerupAmount;

    private void Awake()
    {
        interactableManager = GameObject.Find("InteractableObjectManager").GetComponent<InteractableManager>();
        transform.SetParent(interactableManager.transform);
    }

    private void Start()
    {
        switch (InteractableType)
        {
            case InteractableType.SMALL:
                gameObject.layer = LayerMask.NameToLayer("EI_Small");
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case InteractableType.NORMAL:
                gameObject.layer = LayerMask.NameToLayer("EI_Normal");
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case InteractableType.BIG:
                gameObject.layer = LayerMask.NameToLayer("EI_Big");
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
}
