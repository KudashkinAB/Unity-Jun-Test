using System;
using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using Effects;
using GameUI;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        float maxHealth = 100f;

        float health;

        [SerializeField]
        float scoreOnDestroy = 1f;


        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public float MaxHealth => maxHealth;
        public float Health => health;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
            health = maxHealth;
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            health = Mathf.Clamp(health - damageDealer.Damage, 0, maxHealth);
            if(_shipController is ShipControllers.CustomControllers.PlayerShipController)
            {
                UIController.UIControllerSingleton.SetHealth(health / maxHealth);
            }
            if (health <= 0)
            {
                Death();
            }
        }

        public void Death() //Смерть от рук игрока
        {
            GameController.gameControllerSingleton.AddScore(scoreOnDestroy);
            ExplosionController.explosionControllerSingleton.Explode(transform.position);
            Destroy(gameObject);
        }

        public void ApplyHeal(float healAmount)
        {
            health = Mathf.Clamp(health + healAmount, 0, maxHealth);
            UIController.UIControllerSingleton.SetHealth(health / maxHealth);
        }

        private void OnDestroy()
        {
            if(_shipController is ShipControllers.CustomControllers.PlayerShipController)
            {
                GameController.gameControllerSingleton.GameOver();
            }
        }
        
        public IEnumerator WeaponBonusCoroutine(float value, float time) //Выдача бонуса для основных орудий корабля
        {
            _weaponSystem.MultiplyMainWeaponCooldown(value);
            yield return new WaitForSeconds(time);
            _weaponSystem.MultiplyMainWeaponCooldown(1f / value);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Spaceship>())
            {
                collision.gameObject.GetComponent<Spaceship>().SpaceshipsCollision(this, _battleIdentity);
            }
        }

        public void SpaceshipsCollision(Spaceship spaceship,UnitBattleIdentity unitBattleIdentity) //Столкновение кораблей
        {
            if (_battleIdentity == unitBattleIdentity)
                return;
            spaceship.Death();
            Death();
        }
    }

    
}
