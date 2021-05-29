using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playermovement : MonoBehaviour



{
   public GameObject playerobject;
  public  PlayerObject player;
    public float playermovement;
    public float firerate;
    public bool isfiring;
   public TypeofEvolution typE;
    public float horizontal;
    public float vertical;
    public Rigidbody rb;
    public bool isdead;
    public GameObject shootout;
    public float canfire = 1f;
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
                    typE = TypeofEvolution.Stage1Evolution;
                    break;

                case TypeofEvolution.Stage1Evolution:
                    typE = TypeofEvolution.Stage2Evolution;
                    break;


                case TypeofEvolution.Stage3Evolution:
                    typE = TypeofEvolution.DefaultEvelution;
                    break;
                    
            }
        }

    }

    private void FixedUpdate()
    {


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



        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canfire)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        canfire = Time.time + firerate;
       
       
            Instantiate(shootout, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
   
    }




    







}
