using UnityEngine;
using UnityEngine.AI;

public class NPCObjectController : MonoBehaviour
{
    public EnemyType npcType;
    public NPCScriptableObject npcScriptableObject;

    public void Awake()
    {
        transform.SetParent(GameObject.Find("NPCObjectManager").transform);
    }

    public void AssignVariablesSMALL()
    {

    }
    public void AssignVariablesNORMAL()
    {

    }
    public void AssignVariablesBIG()
    {

    }
}
