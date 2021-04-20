using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 2f;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void Booster(float newDamage)
    {
        _damage = newDamage;
    }


}
