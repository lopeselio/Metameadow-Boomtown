using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedwater : MonoBehaviour
{
    public float scrlspeedX = 0.1f;
    public float scrlspeedY = 0.1f;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * scrlspeedX, Time.realtimeSinceStartup * scrlspeedY);
    }
}
