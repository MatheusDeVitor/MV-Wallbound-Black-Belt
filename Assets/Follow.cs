using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Follow : MonoBehaviour
{
    public float rotateSpeed = 5f;

    private Transform player;

    private Rigidbody rb;

    private float distance;
    
    public float speed;

    public float chaseDistance;

    public bool isAttacked;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Codey").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = true;
    }
    void Update()
    {     
        Vector3 direction = player.position - transform.position;

        
        if (direction.magnitude <= chaseDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            transform.position += speed * direction.normalized;
            rb.isKinematic = false;

        }
        if (direction.magnitude > chaseDistance && !isAttacked)
        {
            rb.isKinematic = true;
        }



    }
   
    public void Attacked()
    {
        isAttacked = true;
        rb.isKinematic = false;
        Vector3 direction = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        targetRotation.x = 0f;
        targetRotation.z = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
        //rb.AddForce(direction * speed, ForceMode.VelocityChange);
    /* private void OnCollisionEnter(Collision collision)
     {
         if(collision.gameObject.tag == "Player")
         {
             Vector3 direction = player.position - transform.position;
             rb.AddForce(-direction * 1000, ForceMode.Impulse);
         }

     }
    */
  

}
