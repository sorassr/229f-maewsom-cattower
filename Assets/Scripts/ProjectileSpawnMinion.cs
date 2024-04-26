using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnMinion : MonoBehaviour
{
    [SerializeField] private Transform shootPointBlue;
    [SerializeField] private Transform targetBlue;
    [SerializeField] private Rigidbody2D bulletPrefabBlue;
    
    [SerializeField] private Transform shootPointRed;
    [SerializeField] private Transform targetRed;


    
    public void SpawnBlueMinion(Rigidbody2D PrefabtoSpawn)
    {
        Vector2 projectile = CalculateProjectileVelocity(shootPointBlue.position, targetBlue.position, 1f);
        Rigidbody2D fireBullet = Instantiate(PrefabtoSpawn, shootPointBlue.position,Quaternion.identity);
        fireBullet.velocity = projectile;
    }
    
    public void SpawnRedMinion(Rigidbody2D PrefabtoSpawn)
    {
        Vector2 projectile = CalculateProjectileVelocity(shootPointRed.position, targetRed.position, 1f);
        Rigidbody2D fireBullet = Instantiate(PrefabtoSpawn, shootPointRed.position,Quaternion.identity);
        fireBullet.velocity = projectile;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin,Vector2 target, float t)
    {
        Vector2 distance = target - origin;
        float VelocityX = distance.x / t;
        float VelocityY = distance.y / t + 0.5f * Mathf.Abs(Physics2D.gravity.y) * t;

        Vector2 result = new Vector2(VelocityX, VelocityY);
        return result;
    }
}
