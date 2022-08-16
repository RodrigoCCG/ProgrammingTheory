using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] float moveSpeed = 5;
    public float MoveSpeed{get{return moveSpeed;}}
    [SerializeField] float shotDelay = 0.1f;
    public float ShotDelay{get{return shotDelay;}}

    // INHERITANCE
    public virtual void moveForward(){
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * moveSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
