using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveEnemyCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fireball")
        {
            GameObject parent = gameObject.transform.parent.gameObject;
            EnemyAI aiComponent = parent.GetComponent<EnemyAI>();
            aiComponent.reactToHit();
        }
    }
}
