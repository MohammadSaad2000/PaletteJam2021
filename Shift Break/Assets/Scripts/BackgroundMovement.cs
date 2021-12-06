using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    public float scrollSpeed = 2.0f;

    private float bufferZone = 1.0f;
    private bool createdCopy = false;
    SpriteRenderer spriteRenderer;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        float height = 2f * camera.orthographicSize;
        float width = height * camera.aspect;
        float sideSize = Mathf.Max(height, width);
        spriteRenderer.size = new Vector2(camera.aspect * camera.orthographicSize + 1.0f, camera.orthographicSize + 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime);

        Vector2 screenBottomPoint = camera.ScreenToWorldPoint(Vector3.zero);
        Vector2 screenTopPoint = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2 backgroundBottomPoint = spriteRenderer.bounds.min;
        Vector2 backgroundTopPoint = spriteRenderer.bounds.max;

        if (!createdCopy && backgroundTopPoint.y <= screenTopPoint.y + bufferZone) {
            CreateBackgroundCopy();
        }


        if (backgroundTopPoint.y + bufferZone <= screenBottomPoint.y)
        {
            Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        spriteRenderer.size = new Vector2(camera.aspect * camera.orthographicSize + 1.0f, camera.orthographicSize + 1.0f);
    }

    void CreateBackgroundCopy()
    {
        Vector2 screenBottomPoint = camera.ScreenToWorldPoint(new Vector3(0, -camera.pixelHeight, 0));
        Vector2 backgroundBottomPoint = spriteRenderer.bounds.min;
        Vector2 backgroundTopPoint = spriteRenderer.bounds.max;

        Instantiate(this.gameObject, new Vector2(0, (spriteRenderer.bounds.max.y + (spriteRenderer.bounds.size.y / 2)) - 0.01f), Quaternion.identity);
        createdCopy = true;
    }
}
