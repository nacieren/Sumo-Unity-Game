using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterKontrolMobil : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float timeRemaining = 0;
    [Range(1, 20)] public float rotationSpeed;
    public DynamicJoystick variableJoystick;
    Vector3 characterDirection;
    Camera mainCam;
    public Transform karakter;
    bool ileri = true;
    public float puan;
    public bool joysKontrol=true;
    public GameObject ölümMenü;
    public GameObject şeker;
    public int player = 6;
    public bool şekerBool=true;
    private float minX= -1.14f;
    private float maxX= 0.82f;
    private float minZ= -1f;
    private float maxZ= 1.4f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
        ölümMenü.SetActive(false);
        //Oyundaki itemlerin spawnlanma yeri
    }
    public void Update()
    {
        //Şeker fonksiyonu
        if(şekerBool==true) { 
        StartCoroutine(şekerYarat());
            şekerBool = false;
        }

        //Karakterin hareket kodu
        if (joysKontrol == true) {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.velocity = direction * Time.fixedDeltaTime;
        
        //Karakterin yön kodu
        characterDirection = new Vector3(variableJoystick.Horizontal,0,variableJoystick.Vertical);
        InputRotation();
        }

        //Karakterin sürekli hareket etmesi
        if (ileri) {
            if (timeRemaining > 5.3f) {
                
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else timeRemaining += Time.deltaTime;
        }
    }
    
    //Karakterin yön fonksiyonu
    void InputRotation()
    {
        Vector3 rotOfset = mainCam.transform.TransformDirection(characterDirection);
        rotOfset.y = 0;
        karakter.forward = Vector3.Slerp(karakter.forward, rotOfset, Time.deltaTime * rotationSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ölüm")
        {
         ölümMenü.SetActive(true);
         Time.timeScale = 0;
         Debug.Log("öldün");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "şeker")
        {
            puan += 100;
            Destroy(other.gameObject);
            transform.localScale *= 1.1f;
        }
    }
    public IEnumerator şekerYarat ()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(şeker, new Vector3(Random.Range(minX, maxX), 0.072f, Random.Range(minZ, maxZ)), şeker.transform.rotation);
            şekerBool = true;
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "AI") { 
        
            if (puan == collision.gameObject.GetComponent<yapayZeka>().puan)
            {
                Vector3 awayFromEnemy = (this.transform.position - collision.gameObject.transform.position);
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
                rb.AddForce(awayFromEnemy * 20, ForceMode.Impulse);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 9, ForceMode.Impulse);
                this.GetComponent<karakterKontrolMobil>().speed = 0;
                this.GetComponent<karakterKontrolMobil>().joysKontrol = false;
                StartCoroutine(kısa());
                Debug.Log("1");
            }

            if (puan < collision.gameObject.GetComponent<yapayZeka>().puan)
            {
                Vector3 awayFromEnemy = (this.transform.position - collision.gameObject.transform.position);
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
                rb.AddForce(awayFromEnemy * 20, ForceMode.Impulse);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 4, ForceMode.Impulse);
                this.GetComponent<karakterKontrolMobil>().speed = 0;
                this.GetComponent<karakterKontrolMobil>().joysKontrol = false;
                StartCoroutine(kısa());
                Debug.Log("2");
            }

            if (puan-400 > collision.gameObject.GetComponent<yapayZeka>().puan)
            {
                Vector3 awayFromEnemy = (this.transform.position - collision.gameObject.transform.position);
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 15, ForceMode.Impulse);
                Debug.Log("3");
            }
            else if (puan > collision.gameObject.GetComponent<yapayZeka>().puan)
            {
                Vector3 awayFromEnemy = (this.transform.position - collision.gameObject.transform.position);
                Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);
                rb.AddForce(awayFromEnemy * 17, ForceMode.Impulse);
                collision.gameObject.GetComponent<Rigidbody>().AddForce(awayFromPlayer * 5, ForceMode.Impulse);
                this.GetComponent<karakterKontrolMobil>().speed = 0;
                this.GetComponent<karakterKontrolMobil>().joysKontrol = false;
                StartCoroutine(kısa());
                Debug.Log("4");
            }
        }
    }

    public IEnumerator kısa()
    {
        yield return new WaitForSeconds(.75f);
        this.GetComponent<karakterKontrolMobil>().speed = 0.24f;
        this.GetComponent<karakterKontrolMobil>().joysKontrol = true;
    }

}