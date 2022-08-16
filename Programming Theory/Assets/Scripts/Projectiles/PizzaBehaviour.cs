using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaBehaviour : FoodBehaviour
{
    [SerializeField] float jetDelay = 2f;
    private bool moving = false;


    private void Start(){
        StartCoroutine(DelayMovement());
    }
    
    // INHERITANCE
    private void FixedUpdate() {
        moveForward();
    }

    // POLYMORPHISM
    public override void moveForward(){
        if(moving){
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * MoveSpeed * 10);
        }
    }

    IEnumerator DelayMovement(){
        moving = false;
        yield return new WaitForSeconds(jetDelay);
        moving = true;
    }
}
