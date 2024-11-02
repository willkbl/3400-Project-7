using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVChange : MonoBehaviour
{

    Camera thisCamera;
    public float scaling = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        thisCamera.fieldOfView = 60 + gameObject.transform.parent.position.z * scaling;
    }
}
