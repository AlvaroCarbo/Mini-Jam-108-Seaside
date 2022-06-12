using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallManager ballManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(ballManager.RedDoor) && this.gameObject.Equals(ballManager.RedBall)) {
            Debug.Log("Red ball in red door");
        }if (other.gameObject.Equals(ballManager.BlueDoor) && this.gameObject.Equals(ballManager.BlueBall)) {
            Debug.Log("Blue ball in blue door");
        }if (other.gameObject.Equals(ballManager.YellowDoor) && this.gameObject.Equals(ballManager.YellowBall)) {
            Debug.Log("Yellow ball in yellow door");
        }
    }
}
