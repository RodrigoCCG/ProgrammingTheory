using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject defaultFood;
    [SerializeField] GameObject currentFood;
    [SerializeField] float moveSpeed;
    private float shotDelay;
    private bool shotReady;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        shotReady = true;
        currentFood = defaultFood;
        shotDelay = currentFood.GetComponent<FoodBehaviour>().ShotDelay;
        playerRB = GetComponent<Rigidbody>();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveCharacter();
        LookAtMouse();
    }


    // ABSTRACTION
    void LookAtMouse(){
        Vector3 cameraCenter = new Vector3(mainCamera.pixelWidth/2, 0, mainCamera.pixelHeight/2);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        Quaternion lookAngle = Quaternion.LookRotation(mousePos - cameraCenter, Vector3.up);
        transform.rotation = lookAngle;
    }

    void MoveCharacter(){
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0,Input.GetAxis("Vertical") * moveSpeed);
        playerRB.AddForce(direction);
    }

    void Shoot(){
        if(shotReady){
            Instantiate(currentFood,transform.position + Vector3.up*2,transform.rotation);
            StartCoroutine(ShotCooldown());
        }
    }

    IEnumerator ShotCooldown(){
        shotReady = false;
        yield return new WaitForSeconds(shotDelay);
        shotReady = true;
    }
}
