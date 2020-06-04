using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Weapons.Projectiles;

public class Rocket : Projectile //Ракета, снаряд меняющий угол поворота
{
    private float rocketStartingPosition;
    [SerializeField]
    private float maxDeviation;
    [SerializeField]
    private float maxDeviationSpeed; //Максимальная скорость поворота

    private void Start()
    {
        rocketStartingPosition = transform.localEulerAngles.z;
    }

    protected override void Move(float speed)
    {
        transform.localEulerAngles = new Vector3 (0f, 0f, transform.localEulerAngles.z + Random.Range(-maxDeviationSpeed, maxDeviationSpeed));
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }
}
