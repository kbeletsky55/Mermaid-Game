using UnityEngine;

public class SeaweedMotion : MonoBehaviour
{

    private float moveSpeed = 7;
    private float offScreenPos = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < offScreenPos)
        {
            Debug.Log("Seaweed Destroyed");
            Destroy(gameObject);
        }
    }
}
