using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject bulletPrefab, turretPivot, turretBody, firePoint, bulletPool;

    private List<Bullet> bullets = new();
    void Awake()
    {
        for(int i = 0; i <= 50; i++)
        {
            var instance = Instantiate(bulletPrefab, bulletPool.transform);
            var bullet = instance.GetComponent<Bullet>();
            bullets.Add(bullet);
            instance.SetActive(false);
            }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (true)
        { 
            var availableBullet = bullets.FirstOrDefault(b => !b.gameObject.activeInHierarchy);
            if (availableBullet){
                availableBullet.direction = firePoint.transform.up;
                availableBullet.transform.position = firePoint.transform.position;
                availableBullet.gameObject.SetActive(true);
            }
            //Corrutina permite comportamientos que se repite ajeno al hilo principal
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
