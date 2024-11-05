using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraEffects : MonoBehaviour
{
    public float aberrationMaxIntensity = 1.0f;
    public float grainMaxIntensity = 1.0f;
    public float grainMaxSize = 3.0f;

    public Grain gr;
    public ChromaticAberration ab;
    public LensDistortion ld;
    public Bloom b;
    public PostProcessVolume volume;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        volume.profile.TryGetSettings(out ab);
        volume.profile.TryGetSettings(out gr);
        volume.profile.TryGetSettings(out ld);
        volume.profile.TryGetSettings(out b);
        ab.intensity.value = (player.position.z / 30) * aberrationMaxIntensity;
        gr.intensity.value = (player.position.z / 30) * grainMaxIntensity;
        gr.size.value = (player.position.z / 30) * grainMaxSize;
        ld.intensity.value = (player.position.z);
        b.intensity.value = (player.position.z / 5);
        //Debug.Log(ab.intensity.value);
    }
}
