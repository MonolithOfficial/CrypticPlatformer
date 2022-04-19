using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public float speed;
    [SerializeField] GameObject player;
    [SerializeField] GameManager gameManager;
    private void Reset()
    {
        speed = 0.6f;
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public void reactToHit()
    {
        double posY = transform.position.y;
        if (posY >= 0 && posY <= 1)
        {
            gameManager.setLevelObjective(1, "monolithKilled", "true");
        }
        if (posY >= 1.3 && posY <= 2.5)
        {
            gameManager.setLevelObjective(2, "monolithKilled", int.Parse(gameManager.getLevelObjective(2, "monolithKilled")) + 1 + "");
        }
        if (posY >= 2.6 && posY <= 4)
        {
            gameManager.setLevelObjective(3, "monolithKilled", int.Parse(gameManager.getLevelObjective(3, "monolithKilled")) + 1 + "");
        }
        StartCoroutine(enemyDeath());
    }

    private IEnumerator enemyDeath()
    {
        GetComponent<NavMeshAgent>().destination = transform.position;
        yield return new WaitForSeconds(0.0001f);

        Destroy(this.gameObject);
    }

    
}
