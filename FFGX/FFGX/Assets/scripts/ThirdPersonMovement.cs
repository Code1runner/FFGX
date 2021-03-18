using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float MoveAmount = 0.0007f;
    //movement
    public Vector3 playerVelocity;
    public float jumpForce = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public bool groundedPlayer,collisionOnLeft, collisionOnRight;
    public GameObject feet, RightCollision, LeftCollision;
    //kucanie
    public Vector3 playerCenter;
    public Vector3 originalCenter;
    public float originalHeight;
    public float reducedHeight = 0.5f;
    //zmiana torów
    float LeftTrackX,RightTrackX;
    Vector3 MoveLeft = new Vector3(-1, 0, 0).normalized;
    Vector3 MoveRight = new Vector3(1, 0, 0).normalized;
    public bool isMovingRight, isMovingLeft;
    public bool CooldownOK=true;
    public float timer=0;
    public float waitTime = 0.4f;
    //zmienne eksportowane
    public bool buildTerrain;
    public Vector3 wspolrzedne;
    public GameObject ProceduralTerain;
    public GameObject canvas;
    public int BuildNr;

    public void Start()
    {
        canvas.GetComponent<PauseMenu>().GameIsPaused = false;
        originalHeight = controller.height;
        originalCenter = controller.center;
        buildTerrain = true;
    }

    void Update()
    {
        BuildNr = ProceduralTerain.GetComponent<ProceduralTerrain>().BuildNr;
        wspolrzedne = controller.transform.position;
        if((int)(wspolrzedne.z%((BuildNr-1)*300+150))>145+ (BuildNr - 1) * 300)
        {
            buildTerrain = true;
        }
        else
        {
            buildTerrain = false;
        }

        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.height = reducedHeight;
            controller.center = playerCenter;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.center = originalCenter;
            controller.height = originalHeight;
        }


        groundedPlayer = feet.GetComponent<groundTouch>().isGrounded;
        collisionOnRight = RightCollision.GetComponent<RightCollision>().isRightCollide;
        collisionOnLeft = LeftCollision.GetComponent<LeftCollision>().isLeftCollide;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        //float horizontal=0;
        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
       

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


      

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CooldownOK && !collisionOnLeft)
        {
            CooldownOK = false;
            isMovingLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && CooldownOK && !collisionOnRight)
        {
            CooldownOK = false;
            isMovingRight = true;
        }
       

       


        if (!CooldownOK && isMovingLeft)
        {
            controller.Move(MoveLeft * MoveAmount * Time.deltaTime);
            timer += Time.deltaTime;
        }

        if (!CooldownOK && isMovingRight)
        {
            
            controller.Move(MoveRight * MoveAmount * Time.deltaTime);
            timer += Time.deltaTime;
        }

        if (timer > waitTime)
        {
            timer = 0;
            isMovingLeft = false;
            isMovingRight = false;
            CooldownOK = true;
        }

        Vector3 direction = new Vector3(0f, 0f, 1f).normalized;
        

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        


    }
}
