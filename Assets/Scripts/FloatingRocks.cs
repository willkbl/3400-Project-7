using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 0.03f;

    public float lowerY = -0.5f;
    public float upperY = 0.5f;

    float actualLowerY;
    float actualUpperY;
    float randomOffset;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        actualLowerY = transform.position.y + lowerY;
        actualUpperY = transform.position.y + upperY;

        randomOffset = Random.Range(0f, 3.1f);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.y = startPos.y + Mathf.Sin(randomOffset + Time.time * speed) * distance;

        transform.position = newPos;
    }
}
