

namespace Gameplay.Weapons
{
    public interface IDamagable
    {
    
        UnitBattleIdentity BattleIdentity { get; }

        void ApplyDamage(IDamageDealer damageDealer);

        void ApplyHeal(float healAmount); //Для ремонта кораблей

        float MaxHealth { get; } //Максимальное количество ХП

        float Health { get; } //ХП)

    }


    public enum UnitBattleIdentity
    {
        Neutral,
        Ally,
        Enemy
    }
}


