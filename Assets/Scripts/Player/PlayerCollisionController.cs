using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField]
    private Vector3 force;
    [SerializeField]
    private float pushPower = 2f;
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
        if (other.CompareTag("DeadZone"))
        {
            Debug.Log("I died :c");
            //Player is dead
        }

        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.LevelCoins++;
            Destroy(other.gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      
        //JumpBoost code
        if (hit.collider.gameObject.CompareTag("JumpBoost") && hit.collider.gameObject.GetComponent<Transform>().position.y + 0.2f < this.gameObject.GetComponent<Transform>().position.y) {
            this.GetComponent<PlayerMovement>().jumpHeight = 5f;
            hit.collider.gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }
        body = hit.collider.attachedRigidbody;
        //No RB
        if (body == null || body.isKinematic)
        {
            return;
        }

        if (!this.GetComponent<PlayerMovement>().groundedPlayer) {
            return;
        }

        if (hit.moveDirection.y < -0.3f)
            return;

        force = hit.gameObject.transform.position - transform.position;
        force.y = 0;
        force.Normalize();
        body.AddForceAtPosition(force * pushPower, transform.position, ForceMode.Impulse);
       
    }
  
}
