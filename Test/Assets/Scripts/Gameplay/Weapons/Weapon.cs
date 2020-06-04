using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private Projectile _projectile;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;

        [SerializeField]
        private float _spread; //параметр разброса оружия


        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;
        
        
        
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        
        
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.transform.localEulerAngles += new Vector3(0f, 0f, Random.Range(-_spread, _spread)); //поворот на случайный угол
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }


        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }

        public void MultiplyCooldown(float value)
        {
            _cooldown *= value;
        }
    }
}
