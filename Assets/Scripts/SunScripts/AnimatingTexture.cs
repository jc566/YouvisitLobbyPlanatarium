using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatingTexture : MonoBehaviour {

    public float speed = 0.1f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();        
    }

    void FixedUpdate()
    {
        float offset = speed * Time.time;

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
