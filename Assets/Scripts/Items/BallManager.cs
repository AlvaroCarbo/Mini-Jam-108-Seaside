using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] public GameObject RedDoor, BlueDoor, YellowDoor;
    [SerializeField] public GameObject BlueLockDoor, YellowLockDoor;
    [SerializeField] public GameObject RedBall, BlueBall, YellowBall;
    [SerializeField] public Transform RedBallSpawn, BlueBallSpawn, YellowBallSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RedBall.transform.position.y < -5) {
            RedBall.transform.SetPositionAndRotation(RedBallSpawn.position, RedBallSpawn.rotation);
        }if (BlueBall.transform.position.y < -5) {
            BlueBall.transform.SetPositionAndRotation(BlueBallSpawn.position, BlueBallSpawn.rotation);
        }if (YellowBall.transform.position.y < -5) {
            YellowBall.transform.SetPositionAndRotation(YellowBallSpawn.position, YellowBallSpawn.rotation);
        }
    }

    public void downLockDoor() {
    
    }
}
