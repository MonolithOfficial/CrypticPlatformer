using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Rigidbody rigidBody;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        //if (!shootSFX.isPlaying)
        //{
        //    shootSFX.Play();
        //}
        player = GameObject.FindGameObjectWithTag("player");
        rigidBody.AddForce(player.transform.forward * 25, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2f);
    }
}
