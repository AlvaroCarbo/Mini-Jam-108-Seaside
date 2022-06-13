using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallManager ballManager;
    public bool isChecked = false;
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
        if (!isChecked)
        {
            if (other.gameObject.transform.parent.gameObject.Equals(ballManager.RedDoor) && this.gameObject.Equals(ballManager.RedBall))
            {
                Debug.Log("Red ball in red door");
                isChecked = true;
                ballManager.spawnCoin(0);
                ballManager.downLockDoor(ballManager.BlueLockDoor);
            }
            if (other.gameObject.transform.parent.gameObject.Equals(ballManager.BlueDoor) && this.gameObject.Equals(ballManager.BlueBall))
            {
                Debug.Log("Blue ball in blue door");
                isChecked = true;
                ballManager.spawnCoin(1);
                ballManager.downLockDoor(ballManager.YellowLockDoor);
            }
            if (other.gameObject.transform.parent.gameObject.Equals(ballManager.YellowDoor) && this.gameObject.Equals(ballManager.YellowBall))
            {
                Debug.Log("Yellow ball in yellow door");
                isChecked = true;
                ballManager.spawnCoin(2);
            }
        }
    }
}
