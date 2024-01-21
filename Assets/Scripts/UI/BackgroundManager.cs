using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float bgScrollSpeed;

    private Renderer bgRenderer;

    private void Awake()
    {
        bgRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        ScalingBackground();
        ScrollingBackground();
    }

    private void ScrollingBackground()
    {
        float y = Mathf.Repeat(Time.time * bgScrollSpeed, 1);
        Vector2 offset = new(0, y);
        bgRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    private void ScalingBackground()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect;

        transform.localScale = new Vector3(width, height, 1f);
    }
}
