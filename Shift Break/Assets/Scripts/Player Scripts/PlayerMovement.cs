using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementXSpeed = 2.0f;
    public float movementYSpeed = 2.0f;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = InputManager.GetMovement(this.name);

        transform.position = new Vector2(transform.position.x + movement.x * movementXSpeed * Time.deltaTime, transform.position.y + movement.y * movementYSpeed * Time.deltaTime);

        Vector2 screenBottomPoint = camera.ScreenToWorldPoint(Vector3.zero);
        Vector2 screenTopPoint = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.y > screenTopPoint.y)
        {
            transform.position = new Vector2(transform.position.x, screenTopPoint.y);
        } else if (transform.position.y < screenBottomPoint.y)
        {
            transform.position = new Vector2(transform.position.x, screenBottomPoint.y);
        }

        if (transform.position.x > screenTopPoint.x)
        {
            transform.position = new Vector2(screenTopPoint.x, transform.position.y);
        }
        else if (transform.position.x < screenBottomPoint.x)
        {
            transform.position = new Vector2(screenBottomPoint.x, transform.position.y);
        }

    }

    
}
