using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemPickup : MonoBehaviour
{
    public GameObject pickupText;
    // Start is called before the first frame update
    void Start()
    {
        pickupText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            pickupText.SetActive(false);
        }
    }
}
