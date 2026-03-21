using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject meatPrefab;

    public GameObject cheesePrefab;

    public GameObject lettucePrefab;

    public GameObject heldItem;

    public string heldItemName;

    public Steve stove;

    public GameObject bun1;

    public GameObject bun2;

    // Start is called before the first frame update
    void Start()
    {
        bun1 = GameObject.Find("Recievers/Bun1");

        bun1.SetActive(false);
        bun2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(triggerName);

            if (triggerName == "Loaf")
            {
                PickUpItem(breadPrefab, "breadSlice");
            }

            if (triggerName == "Meat")
            {
                PickUpItem(meatPrefab, "Meat");
            }

            if (triggerName == "Cheese")
            {
                PickUpItem(cheesePrefab, "Cheese");
            }

            if (triggerName == "Lettuce")
            {
                PickUpItem(lettucePrefab, "Lettuce");
            }

            if (triggerName == "Will")
            {
                print("I has bread");
                if (heldItemName == "breadSlice")
                {
                    print("Codey's ready to toast bread");
                    stove.ToastBread();
                    //eldItem.SetActive(false);
                    PlaceHeldItem();
                }
                else if (heldItemName == "Meat")
                {
                    stove.CookMeat();
                    PlaceHeldItem();
                }
                else
                {
                    print("Codey is empty handed.");
                    if (stove.cookedFood == "toast")
                    {
                        PickUpItem(breadPrefab, "toastSlice");
                        stove.CleanStove();
                    }

                    if (stove.cookedFood == "meat")
                    {
                        PickUpItem(meatPrefab, "cookedMeat");
                        stove.CleanStove();
                        
                    }
                }
            }

            Debug.Log(heldItem);

            if (triggerName == "Plate")
            {
                if (heldItemName == "toastSlice")
                {
                    PlaceHeldItem();
                    bun1.SetActive(true);
                    bun2.SetActive(true);

                }

                if (heldItemName == "cookedMeat")
                {
                    PlaceHeldItem();
                    GameObject.Find("Recievers/meat/LunchMeat").SetActive(true);
                }

                if (heldItemName == "Cheese")
                {
                    PlaceHeldItem();
                    GameObject.Find("Recievers/Cheese/Cheese Thin").SetActive(true);
                }

                if (heldItemName == "Lettuce")
                {
                    PlaceHeldItem();
                    GameObject.Find("Recievers/Lettuce123/_Lettuce").SetActive(true);
                }

                print("I'm ready to make a dish!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string ItemName)
    {
        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItemName = ItemName;
    }
}
