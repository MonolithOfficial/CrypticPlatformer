using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_collector : MonoBehaviour
{
    private Vector3 levelPosition = Constants.playerPos;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] GameObject levelTwoMonolithPrefab;
    private int hitCount = -1;
    public GameManager gameManager;
    private Vector3 playerInitPos;
    private Vector3 playerLastPos;
    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = levelPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            audioSource.Play();
            particleSystem.Play();
            gameManager.updateScore();

            double posY = other.gameObject.transform.position.y;
            if (posY >= 0 && posY <= 1)
            {
                gameManager.setLevelObjective(1, "coinsCollected", int.Parse(gameManager.getLevelObjective(1, "coinsCollected")) + 1 + "");
            }
            if (posY >= 1.3 && posY <= 4)
            {
                gameManager.setLevelObjective(2, "coinsCollected", int.Parse(gameManager.getLevelObjective(2, "coinsCollected")) + 1 + "");
            }
            if (posY >= 4 && posY <= 7)
            {
                gameManager.setLevelObjective(3, "coinsCollected", int.Parse(gameManager.getLevelObjective(3, "coinsCollected")) + 1 + "");
            }
            if (posY > 6)
            {
                gameManager.setLevelObjective(4, "coinsCollected", int.Parse(gameManager.getLevelObjective(4, "coinsCollected")) + 1 + "");
            }
        }

        if (other.gameObject.tag == "killzone")
        {
            playerLastPos = transform.position;
            gameManager.PlayerDeath();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "level2doorcollider")
        {
            GameObject.Find("EnemyMonolith2").GetComponent<EnemyAI>().enabled = true;
            GameObject.Find("EnemyMonolith3").GetComponent<EnemyAI>().enabled = true;
            gameManager.setLevelObjective(2, "levelEntered", "true");
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "level3doorcollider")
        {
            GameObject.Find("EnemyMonolith4").GetComponent<EnemyAI>().enabled = true;
            GameObject.Find("EnemyMonolith5").GetComponent<EnemyAI>().enabled = true;
            GameObject.Find("EnemyMonolith6").GetComponent<EnemyAI>().enabled = true;
            gameManager.setLevelObjective(3, "levelEntered", "true");
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "level4doorcollider")
        {
            gameManager.setLevelObjective(4, "levelEntered", "true");
            //Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            hitCount++;
            bool isDead = gameManager.removeHitpoint();
            Debug.Log(isDead);
            if (isDead)
            {
                gameManager.PlayerDeath();
                Destroy(gameObject);
            }
        }
    }

    public void positionPlayerOnLevel(Vector3 pos)
    {
        levelPosition = pos;
        Debug.Log(levelPosition);
    }
}
