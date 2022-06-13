using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] public GameObject RedDoor, BlueDoor, YellowDoor;
    [SerializeField] public GameObject BlueLockDoor, YellowLockDoor;
    [SerializeField] public GameObject RedBall, BlueBall, YellowBall;
    [SerializeField] public GameObject[] Coins;
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
            RedBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }if (BlueBall.transform.position.y < -5) {
            BlueBall.transform.SetPositionAndRotation(BlueBallSpawn.position, BlueBallSpawn.rotation);
            BlueBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (YellowBall.transform.position.y < -5) {
            YellowBall.transform.SetPositionAndRotation(YellowBallSpawn.position, YellowBallSpawn.rotation);
            YellowBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void downLockDoor(GameObject lockdoor) {
        lockdoor.GetComponent<Animator>().SetTrigger("Open");
    }

    public void spawnCoin(int i) {
        Coins[i].SetActive(true);
    }
}
