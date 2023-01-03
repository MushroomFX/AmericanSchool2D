using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;


    // sprint vars
    public float sprintMax = 25f;
    public float sprintDrain = .1f;
    public float sprintRecharge = .05f;
    public float sprintSpeed = 2f;

    private float sprinState = 1f;
    private float sneakState = 1f;
    private float sprintChrage = 0f;

    public Transform sprintBar; 
    // end of sprint vars

    // Start is called before the first frame update
    void Start()
    {
        sprintChrage = sprintMax;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        sprinState = 1f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(sprintChrage > 0)
            {
                sprinState = sprintSpeed;
                sprintChrage -= sprintDrain;
            }
        } else if(sprintChrage < sprintMax)
        {
            sprintChrage += sprintRecharge;
            if(sprintChrage > sprintMax)
            {
                sprintChrage = sprintMax;
            }
        }
        
        sneakState = 1;
        if(Input.GetKey(KeyCode.LeftControl))
        {
            sneakState = sprintSpeed;
            if(!Input.GetKey(KeyCode.LeftShift)){
                sprintChrage += sprintRecharge;
                if(sprintChrage > sprintMax)
                {
                    sprintChrage = sprintMax;
                }
            }
            
        }

        rb2d.velocity = moveInput * moveSpeed * sprinState / sneakState;

        sprintBar.transform.localScale = new Vector3(sprintChrage/sprintMax, sprintBar.transform.localScale.y, sprintBar.transform.localScale.z);
    }
}
