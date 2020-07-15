using UnityEngine;

[CreateAssetMenu(fileName = "NPC Generator", menuName = "ScriptableObjects/NPC_Generator")]
public class NPCScriptableObject : ScriptableObject
{
    private NPCObjectController npcController;
    private GameObject npcObject;

    public EnemyType npcType;
    public Vector3 npcLocation;

    public float health;
    public float speed;
    public float damage;
    public float defence;

    public void GenerateEnemy(NPCScriptableObject npcScriptableObject, EnemyType npcType)
    {
        npcObject = GameObject.Find("NPCObjectReference");
        GameObject newNPCObject = Instantiate(npcObject, npcObject.transform.position, Quaternion.identity);
        newNPCObject.AddComponent<NPCObjectController>();

        npcController = newNPCObject.GetComponent<NPCObjectController>();
        npcController.npcType = npcType;
        npcController.npcScriptableObject = npcScriptableObject;
        newNPCObject.transform.position = npcLocation;

        switch (npcType)
        {
            case EnemyType.SMALL:
                npcController.AssignVariablesSMALL();
                break;
            case EnemyType.NORMAL:
                npcController.AssignVariablesNORMAL();
                break;
            case EnemyType.BIG:
                npcController.AssignVariablesBIG();
                break;
        }
    }
}
