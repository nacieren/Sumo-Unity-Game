using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class yapayZeka : MonoBehaviour
{
    NavMeshAgent agent;
    private Rigidbody rb;
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform target7;
    public Transform target8;
    public Transform target9;
    public Transform target10;
    public Transform target11;
    public Transform þeker;
    public float timeRemaining;
    public float puan;
    int rastgeleDüþman;
    private bool AIyakala=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(yakala());
    }

    // Update is called once per frame
    void Update()
    {
        //2.3saniyede bir kendini yenileyip þeker klonlayan kod
        if (timeRemaining > 2.3f)
        {
            if (AIyakala == true)
            {
                AIyakala = false;
                StartCoroutine(yakala());
            }
        }
        else timeRemaining += Time.deltaTime;
        
    }
    //Hiç durmamalarý için
    public IEnumerator yakala()
    {
        for (int x = 0; x < 1; x++)
        {
            yield return new WaitForSeconds(5.3f);
            rastgeleDüþman = Random.Range(1, 23);
            if (rastgeleDüþman == 1)
            {
             agent.destination = target1.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 2)
            {
                agent.destination = target2.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 3)
            {
                agent.destination = target3.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 4)
            {
                agent.destination = target4.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 5)
            {
                agent.destination = target5.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 6)
            {
                agent.destination = target6.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 7)
            {
                agent.destination = target7.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 8)
            {
                agent.destination = target8.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 9)
            {
                agent.destination = target9.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 10)
            {
                agent.destination = target10.position;
                AIyakala = true;
            }
            if (rastgeleDüþman == 11)
            {
                agent.destination = target11.position;
                AIyakala = true;
            }
            if (rastgeleDüþman > 11)
            {
                agent.destination = þeker.position;
                AIyakala = true;
            }

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "AI" || collision.gameObject.name == "sumoMain")
        {
            Vector3 awayFromEnemy = (this.transform.position - collision.gameObject.transform.position);
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
            rb.AddForce(awayFromEnemy * 18, ForceMode.Impulse);
            this.GetComponent<NavMeshAgent>().speed = 0;
            StartCoroutine(kýsa());
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "þeker")
        {
            puan += 100;
            Destroy(other.gameObject);
            transform.localScale *= 1.2f;
        }

        if (other.gameObject.tag == "AIölüm")
        {
            Destroy(gameObject);
            Debug.Log("UI oyun dýþý");
        }
        
    }

    public IEnumerator kýsa()
    {
        yield return new WaitForSeconds(.85f);
        this.GetComponent<NavMeshAgent>().speed = 0.2f;
    }
    
}
