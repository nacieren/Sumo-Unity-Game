using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    public Transform target;
    public float timeRemaining = 0;

    void Update()
    {
        transform.rotation = Quaternion.Euler(8.2f, 0f, 0f);
        Vector3 targetPosition = target.transform.position;
        targetPosition.y += 0.292f;
        targetPosition.z += 0.160f;//-0.001/0.018/-0.372  /0.3105315/0.317
        //kamera takip
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        
        //Giriş animasyonunun bitirilişi
        if (timeRemaining > 5)
        {
            GetComponent<Animator>().enabled = false;
        }
        else timeRemaining += Time.deltaTime;
    }

}
