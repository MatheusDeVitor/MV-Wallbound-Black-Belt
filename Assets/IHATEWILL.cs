using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IHATEWILL : MonoBehaviour
{
    Rigidbody a;
    Material m;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Rigidbody>();
        m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void aaa()
    {
        a.AddForce(new Vector3(0, 10,0), ForceMode.Impulse); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aaa();

            m.color = new Color(1, 0, 1, 1);
            Random.Range(0, 1);
        }
    }
}

