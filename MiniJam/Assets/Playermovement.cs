using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovement : MonoBehaviour



{
   public GameObject playerobject;
 
    public  PlayerObject player; // PlayerObject is a scriptableobject
    
    public float playermovement;// amount of speed

    public float firerate;
    
    public bool isfiring;
   
    public TypeofEvolution typE; // Enum in PlayerObject for checking what is the current stage of evolution
    
    public float horizontal;
    
    public float vertical;
    
    public Rigidbody rb;
    
    public bool isdead;// check if the player is dead
    
    public GameObject shootout; // game object to be instantiated as bullets
  
    public float canfire = 1f;// to stop players from bombarding the game with too many key presses
    void Awake()
    {
        
        playermovement = player.playermovement;
        firerate = player.firerate;
        isfiring = player.isfiring;
        typE = player.typE;

        isdead = false;
    }   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead)
        {
            switch(typE)
            {
                case TypeofEvolution.DefaultEvelution:
                    // implement evolution default

                    typE = TypeofEvolution.Stage1Evolution;
                    break;

                case TypeofEvolution.Stage1Evolution:

                    // implement evolution stage 2
                    typE = TypeofEvolution.Stage2Evolution;
                    break;

          
                case TypeofEvolution.Stage3Evolution:

                    // implement evolution stage 3
                    typE = TypeofEvolution.FinalStageEvolution;
                    break;

                case TypeofEvolution.FinalStageEvolution:
                    // implement evolution Final Stage
                    break;
                    
            }
        }

    }

    private void FixedUpdate()
    {

        // MOVEMENTS UPDATE


        if (Input.GetKey(KeyCode.W))
        {
            playerobject.transform.Translate(Vector3.up * playermovement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerobject.transform.Translate(Vector3.down * playermovement * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerobject.transform.Translate(Vector3.left * playermovement * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerobject.transform.Translate(Vector3.right * playermovement * Time.deltaTime);
        }

        //FIRE PROJECTILES

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        canfire = Time.time + firerate;
       if(canfire>5)
        {
            canfire = 0.02f;
        }
       
            Instantiate(shootout, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
   
    }




    







}
