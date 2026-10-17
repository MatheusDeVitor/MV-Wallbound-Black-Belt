using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_PushAway : MonoBehaviour
{
    public float TimeDelay = 2.0f;
    public float PushForce = 500f;

    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        if (enemies == null)
        {
            enemies = new List<GameObject>();
        }

        Invoke("DoPush", TimeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DoPush()
    {
        foreach(GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Rigidbody rb = enemy.GetComponent<Rigidbody>();
                Follow enemyScript = enemy.GetComponent<Follow>();

                if (enemyScript != null)
                {
                    enemyScript.Attacked();
                }

                if (rb != null)
                {
                    Vector3 pushDirection = (enemy.transform.position - transform.position).normalized;
                    rb.AddForce(pushDirection * PushForce);
                }
            }
        }

        Invoke("DeSpawn", 0.5f);
    }

    private void DeSpawn()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skeleton")
        {
            enemies.Add(other.gameObject);
            Debug.Log(enemies.Count);
        }
    }
}
