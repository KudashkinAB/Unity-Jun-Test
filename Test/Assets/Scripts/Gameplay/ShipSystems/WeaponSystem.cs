using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;
        [SerializeField]
        private List<Weapon> _alternativeWeapons; //Вторичное оружие



        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
            _alternativeWeapons.ForEach(w => w.Init(battleIdentity));
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        public void TriggerAlternativeFire()
        {
            _alternativeWeapons.ForEach(w => w.TriggerFire());
        }

        public void MultiplyMainWeaponCooldown(float value) //Модификация скорости стрельбы оружия
        {
            foreach(Weapon w in _weapons)
            {
                w.MultiplyCooldown(value);
            }
        }

    }
}
