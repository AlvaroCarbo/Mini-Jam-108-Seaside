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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        body = hit.collider.attachedRigidbody;
        if (hit.collider.gameObject.CompareTag("JumpBoost") && hit.collider.gameObject.GetComponent<Transform>().position.y < this.gameObject.GetComponent<Transform>().position.y) {
            this.GetComponent<PlayerMovement>().jumpHeight = 5f;
            hit.collider.gameObject.GetComponent<Animator>().SetBool("Jump", true);
        }
        //No RB
        if (body == null || body.isKinematic)
        {
            return;
        }

        if (!this.GetComponent<PlayerMovement>().groundedPlayer) {
            return;
        }

        force = hit.gameObject.transform.position - transform.position;
        force.y = 0;
        force.Normalize();
        body.AddForceAtPosition(force * pushPower, transform.position, ForceMode.Impulse);
       
    }
  
}
