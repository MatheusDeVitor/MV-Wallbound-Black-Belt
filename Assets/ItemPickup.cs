using UnityEngine;
using TMPro;
public class ItemPickup : MonoBehaviour
{
    public GameObject pickupText;
    public GameObject bombPrefab;
    public TextMeshProUGUI bombCounterText;
    private GameObject bombItem;
    private int BombCount;

    // Start is called before the first frame update
    void Start()
    {
        pickupText.SetActive(false);
        bombItem = null;
        BombCount = 0;
        bombCounterText.SetText("0");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (bombItem != null)
            {
                BombCount += 1;
                Destroy(bombItem);
                bombItem = null;
                bombCounterText.SetText(BombCount.ToString());
                Debug.Log("Bomb#: " + BombCount);
            }
        }
    }

    void ThrowBomb()
    {
        if (bombPrefab == null) return;
        Instantiate(bombPrefab);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            pickupText.SetActive(true);
            bombItem = collision.gameObject;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            pickupText.SetActive(false);
            bombItem = null;
        }
    }
}
