using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    bool hit = false;
    float depth = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (!hit && !other.CompareTag("Player"))
        {
            StickArrow(other);
            hit = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }

    private void StickArrow(Collider col) {
        col.transform.Translate(depth * -Vector2.right);
        transform.parent = col.transform;
        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<BoxCollider>());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
