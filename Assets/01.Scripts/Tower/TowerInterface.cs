using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TowerInterface
{
    public enum AttackType
    {
        Normal, Splash
    }
    public enum TowerClass
    {
        Common, Magic, Rare, Unique, Eqic
    }

    public enum TowerName
    {
        ElfShotter, ElfMagician, HumanGunner, HumanWarrior, DevilMagician, DevilShotter , Robat, Mutant
    }
}
