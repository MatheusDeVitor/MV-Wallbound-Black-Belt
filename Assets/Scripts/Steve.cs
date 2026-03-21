using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour
{
    public GameObject toast;

    public GameObject meat;

    public string cookedFood = "";

    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
        cookedFood = "";
        smoke.Stop();
        complete.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToastBread()
    {
        isCooking = true;
        smoke.Play();
        toast.SetActive(true);
        cookedFood = "toast";
        Invoke("CompleteCooking", 6f);
    }

    public void CookMeat()
    {
        isCooking = true;
        smoke.Play();
        meat.SetActive(true);
        cookedFood = "meat";
        Invoke("CompleteCooking", 8f);
    }

    public void CleanStove()
    {
        if (isCooking == false)
        {
            toast.SetActive(false);
            meat.SetActive(false);
            cookedFood = "";
            complete.Stop();
        }
    }

    private void CompleteCooking()
    {
        isCooking = false;
        smoke.Stop();
        complete.Play();
    }

}
