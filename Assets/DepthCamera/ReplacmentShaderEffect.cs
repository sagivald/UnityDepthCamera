using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ReplacmentShaderEffect : MonoBehaviour
{
    [Range(1, 100)]
    public float distance = 10.0f;
    public Shader ReplacmentShader;
    void OnEnable()
    {
        if (ReplacmentShader != null)
        {
            GetComponent<Camera>().SetReplacementShader(ReplacmentShader, "RenderType");
            GetComponent<Camera>().farClipPlane = distance;
        }
    }

    void OnDisable()
    {
            GetComponent<Camera>().ResetReplacementShader();

    }
}
