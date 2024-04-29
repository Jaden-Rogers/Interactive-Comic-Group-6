using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class ClearRenderTexture : MonoBehaviour
{
    public VideoPlayer videoPlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        ClearRenderTextureMethod();
        
    }
    private void Awake()
    {
        ClearRenderTextureMethod();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearRenderTextureMethod()
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = videoPlayerObject.targetTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
}
