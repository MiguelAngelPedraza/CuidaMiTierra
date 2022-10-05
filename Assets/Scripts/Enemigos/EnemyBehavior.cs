using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] WayPointsMovement ruta;
    [SerializeField] NavMeshAgent enemyAgent;
    [SerializeField] GameObject nextPosition;
    [SerializeField] Animator anim;
    [SerializeField] Vector3 searchPosition;
    [SerializeField] float speed = 3.5f;
    [SerializeField] int nextIndex;
    [SerializeField] Vector3 alarm;
    [SerializeField] GameObject alarmObject;
    [SerializeField] FieldOfView fov;
    [SerializeField] GameObject target;
    [SerializeField] GameObject cazadores;

    [SerializeField] bool search;
    [SerializeField] bool alert;
    [SerializeField] int rutina = 0;
    [SerializeField] float temp = 0;
    [SerializeField] float lookTemp = 0;
    [SerializeField] float lookTempLimit = 7;
    [SerializeField] float limitTemp = 2;
    [SerializeField] float shootTemp = 0;
    [SerializeField] float shootTempLimit = 4;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        cazadores = GameObject.FindGameObjectWithTag("Cazadores");
        
        if(alarmObject != null)
        alarm = alarmObject.transform.position;
        alarm = new Vector3(alarm.x,0,alarm.z);
        nextPosition = ruta.waypoints[0];
        nextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextIndex >= ruta.waypoints.Length)
        {
            nextIndex = 0;
        }

        if(fov.LookForPlayer() && !alert)
        {
            target = fov.animalDetected;
            nextPosition = alarmObject;
            Alert();
        }

        if(transform.tag == "Worker")
        {
            ComportamientoWorker();
        }
        else
        {
            if(transform.tag == "Hunter")
            {
                ComportamientoHunter();
            }
        }
        
        
    }

    void ComportamientoWorker()
    {
        enemyAgent.speed = speed;

        if(rutina == 0)
        {
            temp += Time.deltaTime;
            if(temp > limitTemp)
            {
                rutina = 1;
                temp = 0;
            }
        }


        switch(rutina)
        {
            case 0:
                anim.SetBool("Walk", false);
                break;
            case 1:
                speed = 3.5f;
                anim.SetBool("Walk", true);
                enemyAgent.destination = nextPosition.transform.position;
                break;
            case 2:
                speed = 0f;
                anim.SetBool("React", true);
                break;
            case 3:
                speed = 2f;
                anim.SetBool("Sneak", true);
                enemyAgent.destination = searchPosition;

                if(Vector3.Distance(transform.position,searchPosition) < 0.5f)
                {
                    rutina = 4;
                }
                break;
            case 4:
                anim.SetBool("Look", true);
                speed = 0f;
                lookTemp += Time.deltaTime;
                if(lookTemp > lookTempLimit)
                {
                    EndLook();
                }

                break;
            case 5:
                anim.SetBool("Run", true);
                speed = 6;
                
                enemyAgent.destination = nextPosition.transform.position;
                break;
        }
    }

    void ComportamientoHunter()
    {
        enemyAgent.speed = speed;

        if(rutina == 0)
        {
            temp += Time.deltaTime;
            if(temp > limitTemp)
            {
                rutina = 1;
                temp = 0;
            }
        }


        switch(rutina)
        {
            case 0:
                anim.SetBool("Walk", false);
                break;
            case 1:
                speed = 3.5f;
                anim.SetBool("Walk", true);
                enemyAgent.destination = nextPosition.transform.position;
                break;
            case 2:
                speed = 0f;
                anim.SetBool("React", true);
                break;
            case 3:
                speed = 2f;
                anim.SetBool("Sneak", true);
                enemyAgent.destination = searchPosition;

                if(Vector3.Distance(transform.position,searchPosition) < 0.1f)
                {
                    rutina = 4;
                }
                break;
            case 4:
                anim.SetBool("Look", true);
                speed = 0f;
                lookTemp += Time.deltaTime;
                if(lookTemp > 10)
                {
                    EndLook();
                }

                break;
            case 5:
                anim.SetBool("Aim", true);
                speed = 0;
                shootTemp += Time.deltaTime;
                enemyAgent.destination = alarm;
                transform.LookAt(new Vector3(target.transform.position.x,transform.position.y,
                target.transform.position.z));

                if(shootTemp >= shootTempLimit)
                {
                    rutina++;
                }

                break;

            case 6:
                anim.SetBool("Fire",true);

                break;
                    
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WayPoint"))
        {
            if(!search && !alert)
            {
                rutina = 0;
                nextPosition = ruta.NextWaypoint(nextIndex);
                nextIndex++;
            }
        }

        if(other.CompareTag("Sound"))
        {
            if(!alert)
            {
                rutina = 2;
                search = true;
                anim.SetBool("Walk",false);
                anim.SetBool("Sneak",false);
                anim.SetBool("Look",false);
                searchPosition = new Vector3(other.transform.position.x,transform.position.y,other.transform.position.z);
            }
            
        }

        if(other.CompareTag("Alarm"))
        {
            anim.SetBool("Walk",false);
            anim.SetBool("React",false);
            anim.SetBool("Sneak",false);
            anim.SetBool("Look",true);

            cazadores.SetActive(true);
        }
    }

    public void EndReact()
    {
        anim.SetBool("Walk",false);
        anim.SetBool("React",false);
        anim.SetBool("Sneak",false);
        anim.SetBool("Look",false);

        if(alert)
        {
            rutina = 5;
        }
        else
        {        
            if(search)
            {
                rutina = 3;
            }
        }
    }

    public void EndLook()
    {
        anim.SetBool("Walk",false);
        anim.SetBool("React",false);
        anim.SetBool("Sneak",false);
        anim.SetBool("Look",false);

        search = false;
        alert = false;

        rutina = 1;
        lookTemp = 0;
    }

    public void Alert()
    {
        anim.SetBool("Walk",false);
        anim.SetBool("React",false);
        anim.SetBool("Sneak",false);
        anim.SetBool("Look",false);
        anim.SetBool("Aim", false);
        anim.SetBool("Fire", false);
        alert = true;
        rutina = 2;
    }

    public void EndShoot()
    {
        anim.SetBool("Walk",false);
        anim.SetBool("React",false);
        anim.SetBool("Sneak",false);
        anim.SetBool("Look",false);
        anim.SetBool("Aim", false);
        anim.SetBool("Fire", false);

        Debug.Log("Dispare");

        search = false;
        alert = false;

        shootTemp = 0;
        rutina = 0;

        GameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

}
