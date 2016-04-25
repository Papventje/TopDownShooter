using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public Projectile projectile;
    public Laser laser;
    public Bomb bomb;
    public Transform muzzle;
    public Transform muzzle2;
    public Transform bombDrop;
    public float bulletSpeed;
    public float laserSpeed;
    public float fireRate = 0.5f;
    public float laserRate = 0.5f;
    public float bombRate = 0.5f;
    public float nextFire = 0.0f;
    public float nextLaser = 0.0f;
    public float nextBomb = 0.0f;
    public int ammo = 18;
    public int ammoCount = 20;
    public int maxAmmo = 40;
    public int laserAmmo = 2;
    public int laserMaxAmmo = 4;
    public int bombAmmo = 1;
    public int bombMaxAmmo = 3;
    public int score;
    public Text AmmoText;
    public Text LaserAmmoText;
    public Text BombAmmoText;
    public Text scoreText;
    public bool shootCondition = true;
    public bool laserCondition = true;
    public bool bombCondition = true;
    public AudioSource shot;
    public AudioSource shot2;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire && shootCondition == true)
        {
            Shoot();
            ammo -= 2;
            ammoCount -= 2;
            if (ammo == 0)
            {
                fireRate = 2f;
            }
            if (ammo == -2 && maxAmmo == 0)
            {
                shootCondition = false;
               
            }
            if (ammo == -2 && shootCondition == true)
            {
                fireRate = 0.5f;
                ammo = 18;
                ammoCount = 20;
                maxAmmo = maxAmmo - 20;
            }
                
            
        }
      
        if(Input.GetMouseButton(1) && Time.time > nextLaser && laserCondition == true)
        {
            ShootLaser();
            laserAmmo -= 2;
            if(laserAmmo == 0)
            {
                laserRate = 2f;
            }
            if(laserAmmo == 0 && laserMaxAmmo == 0)
            {
                laserCondition = false;
            }
            if(laserAmmo == 0 && laserCondition == true)
            {
                laserRate = 0.5f;
                laserAmmo = 2;
                laserMaxAmmo -= 2;
            }
        }
        if (Input.GetKeyDown("space") && Time.time > nextBomb && bombCondition == true)
        {
            DropBomb();
            bombAmmo -= 1;
            if(bombAmmo == 0)
            {
                bombRate = 2f;
            }
            if(bombAmmo == 0 && bombMaxAmmo == 0)
            {
                bombCondition = false;
            }
            if(bombAmmo == 0 && bombCondition == true)
            {
                bombRate = 0.5f;
                bombAmmo = 1;
                bombMaxAmmo -= 1;
            }
        }

        AmmoText.text = "Ammo : " + ammoCount + "/ " + maxAmmo;
        LaserAmmoText.text = "Laser Ammo : " + laserAmmo + "/ " + laserMaxAmmo;
        BombAmmoText.text = "Bomb Ammo : " + bombAmmo + "/ " + bombMaxAmmo;
        scoreText.text = "Score : " + score;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            if (ammoCount != 0)
            {
                maxAmmo += 40;
                Destroy(other.gameObject);
            }
            if(ammoCount == 0)
            {
                ammo += 18;
                ammoCount += 20;
                maxAmmo += 20;
                shootCondition = true;
                fireRate = 0.5f;
                Destroy(other.gameObject);
            }
            
        }
        if (other.CompareTag("Ammo"))
        {
            if(laserAmmo != 0)
            {
                laserMaxAmmo += 4;
                Destroy(other.gameObject);
            }
            if(laserAmmo == 0)
            {
                laserAmmo += 2;
                laserMaxAmmo += 2;
                laserCondition = true;
                laserRate = 0.5f;
                Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("Ammo"))
        {
            if(bombAmmo != 0)
            {
                bombMaxAmmo += 3;
                Destroy(other.gameObject);
            }
            if(bombAmmo == 0)
            {
                bombAmmo += 1;
                bombMaxAmmo += 2;
                bombCondition = true;
                bombRate = 0.5f;
                Destroy(other.gameObject);
            }
        }
    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
      
        Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
        Projectile newProjectile2 = Instantiate(projectile, muzzle2.position, muzzle2.rotation) as Projectile;

        newProjectile.SetSpeed(bulletSpeed);
        newProjectile2.SetSpeed(bulletSpeed);

        shot.Play();
    }

    private void ShootLaser()
    {
        nextLaser = Time.time + laserRate;

        Laser newLaser = Instantiate(laser, muzzle.position, muzzle.rotation) as Laser;
        Laser newLaser2 = Instantiate(laser, muzzle2.position, muzzle2.rotation) as Laser;

        newLaser.SetSpeed(laserSpeed);
        newLaser2.SetSpeed(laserSpeed);

        shot2.Play();

    }

    private void DropBomb()
    {
        nextBomb = Time.time + bombRate;

        Bomb newBomb = Instantiate(bomb, bombDrop.position, bombDrop.rotation) as Bomb;
    }
}
