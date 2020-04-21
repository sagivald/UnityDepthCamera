using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DepthCamera : MonoBehaviour
{
    [Range(1, 100)]
    public float distance = 10.0f;
	Material material;
	float depthLevel = 1;
	Matrix4x4 projMat;
	public Camera depthCam;
	RenderTexture depthImage;
	public Shader Shade;

    void Start()
    {
		depthCam = GetComponent<Camera>();
		material = new Material(Shade);
		projMat = depthCam.projectionMatrix;
		//autoFOV();

    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (Shade != null)
        {
            material.SetFloat("_DepthLevel", depthLevel);
            Graphics.Blit(src, dest, material);
            depthCam.farClipPlane = distance;
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
