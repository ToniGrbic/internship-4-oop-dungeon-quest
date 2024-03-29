﻿
using Data.Constants;
using Data.InputOutputUtils;

namespace Domain.Repositories
{
    public class Enchanter : Hero
    {
        public int Mana { get; set; }
        public int ManaCostAttack { get; set; }
        public int ManaThreshold { get; set; }
        public bool HasRevive { get; set; }
        public Enchanter(string name) : base(name)
        {
            this.Trait = "Enchanter";
            this.HPThreshold = (int)HeroHP.Enchanter;
            this.HP = HPThreshold;
            this.Damage = (int)HeroDamage.Enchanter;

            ManaThreshold = Constants.BASE_MANA_AMOUNT_ENCHANTER;
            Mana = ManaThreshold;
            ManaCostAttack = Constants.ATTACK_MANA_COST_ENCHANTER;
            HasRevive = true;
        }

        public void HealAbility()
        {
            if (Mana >= Constants.BASE_MANA_AMOUNT_ENCHANTER && HP < HPThreshold)
            {
                if(HP + Constants.HEAL_HP_AMOUNT >= HPThreshold)
                {
                    var missingHP = HPThreshold - HP;
                    HP = HPThreshold;
                    Console.WriteLine($"+{missingHP}HP, Healed to full!\n");
                }
                else {  
                    HP += Constants.HEAL_HP_AMOUNT;
                    Console.WriteLine("Healed for +250 HP!\n");
                }
                Mana -= Constants.HEAL_MANA_COST;
                PrintHeroStats();
            }
        }

        public void ReviveAbility()
        { 
            HP = HPThreshold;
            Mana = ManaThreshold; 
            HasRevive = false;
        }

        public override void BasicAttack(Enemy enemy)
        {
            if (Mana >= ManaCostAttack)
            {
                Mana -= ManaCostAttack;
                Console.WriteLine($"-15 Mana for attack\n");
                
                enemy.HP -= Damage;
                Console.WriteLine($"You damaged the {enemy.Type} for {Damage}");
            }
            else
            {
                Console.WriteLine("Not enough mana for attack, regaining mana for this round.\n");
                Mana = ManaThreshold;
            }
        }

        public override void UseHeroAbility()
        {
            if (Mana < 50)
                Console.WriteLine("Not enough mana to use Heal Ability\n");
            else if(HP == HPThreshold)
            {
                Console.WriteLine("HP is already full, can't use Heal\n");
            }
            else
            {
                Console.WriteLine("Do you want to use Heal Ablity? (yes/no)");
                if (Utils.ConfirmationDialog() == GameLoop.CONTINUE)
                    HealAbility();
            }
        }
    }
}
