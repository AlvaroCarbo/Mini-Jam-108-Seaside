using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5)
        {
            this.transform.SetPositionAndRotation(new Vector3(0, 15), Quaternion.identity);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
