using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOccluder : MonoBehaviour
{
    [Header("Max Distance Off Screen Before Occluding")] 
    public float maxYDistance = 1.0f;
    public float maxXDistance = 5.0f;

    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenTopRightPoint = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        Vector2 screenBottomLeftPoint = camera.ScreenToWorldPoint(Vector3.zero);
        if (transform.position.y > screenTopRightPoint.y + maxYDistance
            || transform.position.y < screenBottomLeftPoint.y - maxYDistance
            || transform.position.x > screenTopRightPoint.x + maxXDistance
            || transform.position.x < screenBottomLeftPoint.x - maxXDistance)
        {
            Destroy(this.gameObject);
        }

    }
}
