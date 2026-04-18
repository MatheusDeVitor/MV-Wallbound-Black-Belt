using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float rotateSpeed = 5f;

    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Codey").GetComponent<Transform>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

}
