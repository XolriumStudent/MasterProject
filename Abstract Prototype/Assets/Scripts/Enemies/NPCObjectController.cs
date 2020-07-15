using UnityEngine;
using UnityEngine.AI;

public class NPCObjectController : MonoBehaviour
{
    public EnemyType npcType;
    public NPCScriptableObject npcScriptableObject;

    public float health;
    public float speed;
    public float damage;
    public float defence;

    private void Awake()
    {
        transform.SetParent(GameObject.Find("NPCObjectManager").transform);
    }

    private void Start()
    {
        switch (npcType)
        {
            case EnemyType.SMALL:
                AssignVariablesSMALL();
                break;
            case EnemyType.NORMAL:
                AssignVariablesNORMAL();
                break;
            case EnemyType.BIG:
                AssignVariablesBIG();
                break;
        }
    }

    public void AssignVariablesSMALL()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
    public void AssignVariablesNORMAL()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
    public void AssignVariablesBIG()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
