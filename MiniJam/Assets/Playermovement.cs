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

    public int health;
    public int damage;
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
        
        
            switch(typE)
            {
                case TypeofEvolution.DefaultEvelution:
             
                player.health = 100;
                player.damage = 100;
                health = player.health;
                damage = player.damage;
                // implement evolution default
                if (isdead)
                {
                    typE = TypeofEvolution.Stage1Evolution;
                   
                }
                break;

            case TypeofEvolution.Stage1Evolution:

                player.health = 200;
                player.damage = 200;
                health = player.health;
                damage = player.damage;
                if (isdead)
                {
                    typE = TypeofEvolution.Stage2Evolution;

                }
                break;

          
                case TypeofEvolution.Stage3Evolution:

                player.health = 300;
                player.damage = 300;
                health = player.health;
                damage = player.damage;
                if (isdead)
                {
                    typE = TypeofEvolution.FinalStageEvolution;

                }
                break;

                case TypeofEvolution.FinalStageEvolution:

                player.health = 400;
                player.damage = 400;
                health = player.health;
                damage = player.damage;
                // implement evolution Final Stage
                break;
                    
            }
        //FIRE PROJECTILES

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {

        // MOVEMENTS UPDATE


        if (Input.GetKey(KeyCode.W))
        {


            playerobject.transform.Translate(Vector3.up * playermovement * Time.deltaTime);
            if(playerobject.transform.position.y >0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerobject.transform.Translate(Vector3.down * playermovement * Time.deltaTime);

           if(playerobject.transform.position.y < -360)
            {
                transform.position = new Vector3(transform.position.x, -360, transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerobject.transform.Translate(Vector3.left * playermovement * Time.deltaTime);

            if (playerobject.transform.position.x< -770)
            {
                transform.position = new Vector3(-770,transform.position.y , transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerobject.transform.Translate(Vector3.right * playermovement * Time.deltaTime);
            if (playerobject.transform.position.x > 770)
            {
                transform.position = new Vector3(770, transform.position.y, transform.position.z);
            }
        }

       
    }

    public void Shoot()
    {
        canfire = Time.time + firerate;
       
       
            Instantiate(shootout, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
   
    }




    







}
