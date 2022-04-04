using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    [SerializeField] GameObject player;
    [SerializeField] int jumpForce;
    [SerializeField] int moveAmount;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float distance;
    [SerializeField] float distanceUp;
    [SerializeField] BoxCollider2D[] colliderOmar;
    [SerializeField] float time;
    float timeReset;
    [SerializeField] float radius;
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(player.transform.position, -Vector2.up, distance,layerMask);
        if(Physics2D.OverlapCircle((Vector2)this.transform.position-new Vector2(0,1), radius, layerMask))
        {
            foreach (var collider in colliderOmar)
            {
                collider.isTrigger = false;
            }
        }
        RaycastHit2D hitInfoOfSquare = Physics2D.Raycast(player.transform.position, Vector2.up, distanceUp, layerMask);
        if(hitInfoOfSquare.collider != null)
        {
            foreach(var collider in colliderOmar)
            {
                collider.isTrigger = true;
            }
        }
        isGrounded = hitInfo;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // player.transform.position = player.transform.position + new Vector3(0, jumpForce, 0)*Time.deltaTime;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
       //float horizontalMovement = Input.GetAxis("Horizontal");
       // Debug.Log(horizontalMovement);
        if (Input.GetKey(KeyCode.RightArrow)){
            rigidBody.AddForce(new Vector2(moveAmount, 0) * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(new Vector2(-moveAmount, 0) * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(player.transform.position, -transform.up * distance,Color.red);
        Debug.DrawRay(player.transform.position, Vector3.up * distanceUp, Color.green);
    }
    
}
