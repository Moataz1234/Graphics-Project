using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
public float speed=5f;
public float jumpspeed=5f; 
 private float movment=0f;

 private Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
    Rigidbody=GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
    movment=Input.GetAxis("Horizontal");
    if(movment>0f){
    Rigidbody.velocity=new Vector2(movment*speed,Rigidbody.velocity.y);
    }
    else if(movment<0f){
    Rigidbody.velocity=new Vector2(movment*speed,Rigidbody.velocity.y);    
    }
    else{
        Rigidbody.velocity=new Vector2(0,Rigidbody.velocity.y);
    }
    if(Input.GetKeyDown(KeyCode.Space)){
        Rigidbody.velocity=new Vector2(Rigidbody.velocity.x,jumpspeed);
    }
}
}