using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{

    public float rotateSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + rotateSpeed * Time.deltaTime);
    }
}
