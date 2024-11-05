using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatVolume : MonoBehaviour
{

    AudioSource heartbeat;

    // Start is called before the first frame update
    void Start()
    {
        heartbeat = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        heartbeat.volume = (this.transform.parent.transform.parent.position.z / 30) - 0.2f;
        heartbeat.pitch = (this.transform.parent.transform.parent.position.z / 30) + 0.7f;
    }
}
