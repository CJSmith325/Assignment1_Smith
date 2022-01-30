using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public float lifeCounter;

    public GameObject bullet;
    public GameObject player;

    public float bulletSpeed;

    GameObject gun = GameObject.Find("gun");
    GameObject gunTip = GameObject.Find("gunTip");

    private Vector3 target;
    
    // get mouse position in scene
    public static Vector3 GetMousePosition()
    {
        Vector3 vec = GetMousePositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    // get mouse position with 2 parameters
    public static Vector3 GetMousePositionWithZ(Vector3 screenPosition, Camera mainCamera)
    {
        Vector3 vec = mainCamera.ScreenToWorldPoint(screenPosition);
        return vec;
    }

    private Transform gunPivot;
    private void Awake()
    {
        gunPivot = transform.Find("gunPivot");
    }

    public void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x);
        //Aiming();

        Vector3 mousePosition = GetMousePosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunPivot.eulerAngles = new Vector3(0, 0, angle + 180);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = player.transform.position;
            b.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + 180);
            b.GetComponent<Rigidbody2D>().velocity = aimDirection * bulletSpeed;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }
    }
    
}
