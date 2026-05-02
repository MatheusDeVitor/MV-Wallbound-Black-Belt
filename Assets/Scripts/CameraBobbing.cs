using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobbing : MonoBehaviour
{
    public Rigidbody playerRB;
    public float BobbingSpeed = 1f;
    public float BobbingAmplitude = 1f;
    public float BobbingOffset = 0f;

    private Vector3 originalPosition;
    private Vector3 bufferPosition;
    private float bobBuffer;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        bufferPosition = originalPosition;
        bobBuffer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRB.velocity.magnitude > 0f)
        {
            bufferPosition = transform.position;

            bobBuffer += Time.deltaTime * BobbingSpeed;
            bufferPosition.y += Mathf.Sin(bobBuffer) * (BobbingAmplitude / 20f);
            gameObject.transform.position = bufferPosition;

        }
            //Debug.Log(transform.position.y);
    }
}
