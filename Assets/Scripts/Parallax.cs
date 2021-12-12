using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float animationSpeed = 1f;
    
    private MeshRenderer _meshRender;

    private void Awake()
    {
        _meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshRender.material.mainTextureOffset += new Vector2(Time.deltaTime * animationSpeed, 0);
    }
}
