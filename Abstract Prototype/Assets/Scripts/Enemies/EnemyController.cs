using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private const int MAXHEALTH = 100;
    private int currentHealth = 0;
    private NavMeshAgent agent;
    private float timer;
    private float timeToKillWithoutItem;
    private float timeToKillWithItem;
    [SerializeField]
    private EnemyType enemyType;

    //Testing purpose to check for the distance
    public float playerHealth;
    public float damage;
    public float attackSpeed;
    public float enemyCount;
    public float multiplierNoItem;
    public float multiplierWithItem;

    private void Awake()
    {
        currentHealth = MAXHEALTH;
        agent = GetComponent<NavMeshAgent>();
        AssignAttributes();
    }

    private void Update()
    {
        Movement();
    }

    private void AssignAttributes()
    {
        switch (enemyType)
        {
            case EnemyType.SMALL:

                break;

            case EnemyType.NORMAL:

                break;

            case EnemyType.BIG:

                break;
        }
    }

    /// <summary>
    /// We controleren doormiddel van een algorithme als de vijand eerst een object gaat oprapen of meteen naar de speler gaat.
    /// </summary>
    private void CheckAlgorithm()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject interactable = GameObject.FindGameObjectWithTag("Interactable");

        float distancePlayer = Vector3.Distance(transform.position, player.transform.position);
        float distanceInteractable = Vector3.Distance(transform.position, interactable.transform.position);
        float distancePlayerInteractable = Vector3.Distance(player.transform.position, interactable.transform.position);

        print("Distance Item: " + distanceInteractable);
        print("Distance Player: " + distancePlayer);
        print("Distance Player to Item: " + distancePlayerInteractable);

        //Het algorithme werkt als volgt: Afhankelijk van hoeveel levenspunten de speler heeft en hoeveel DPS de vijand heeft, weten we hoelang het duurt in seconden om de speler te doden
        //Met de speed: 8 legt de vijand 7 units van distance of elke seconden. Daarom doe gebruik ik een deling door 7 bij de afstand. 
        //Als we deze twee combineren (+) weten we hoelang het duurt voor beide gevallen.
        float noI = playerHealth / (damage * multiplierNoItem * attackSpeed) + (distancePlayer / 7);
        float wI = playerHealth / (damage * multiplierWithItem * attackSpeed) + ((distanceInteractable + distancePlayerInteractable) / 7);

        timeToKillWithoutItem = noI;
        timeToKillWithItem = wI;
    }

    public void Dead()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void Movement()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject interactable = GameObject.FindGameObjectWithTag("Interactable");

        CheckAlgorithm();

        //Ik voeg de timeToKillWithoutItem / 4 er extra bij toe, zodat het niet al te vreemd voelt voor de speler.
        //Dit moet geplaytest worden voor een goede formule!
        if ((timeToKillWithItem + (timeToKillWithoutItem / 4)) < timeToKillWithoutItem)
            agent.SetDestination(interactable.transform.position);
        else
            agent.SetDestination(player.transform.position);
        print("Time to kill without item: " + timeToKillWithoutItem);
        print("Time to kill with item: " + (timeToKillWithItem + (timeToKillWithoutItem / 4)));
    }
}
