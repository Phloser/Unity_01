using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject BulletSpawn;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float RotateSense = 100f;

    private float _boostDamage = 2f;
    private Vector3 _direction = Vector3.zero;
    private float _angle;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire();
       // _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        _angle = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move() 
    {
        var _speed = _direction.normalized * Time.fixedDeltaTime * speed;
        transform.Translate(_speed);
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, _angle * Time.fixedDeltaTime * RotateSense, 0f),Space.Self);
    }

    private void Fire()
    {
        var bullet = GameObject.Instantiate(BulletPrefab, BulletSpawn.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Booster(_boostDamage);

    }
}
