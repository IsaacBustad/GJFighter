using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpellFactory")]
public class SpellFactory : ScriptableObject
{
    // vars
    PoolGeneric<Spell> pool = new PoolGeneric<Spell>();
    [SerializeField] protected GameObject spell;
    [SerializeField] protected Score score;

    // Update is called once per frame

    public GameObject SpawnSpell(Vector3 aV3, bool aHeading)
    {
        Spell aSpell = null;

        pool.ChPool(ref aSpell);

        if (aSpell != null)
        {
            return SpawnUsedSpell(aSpell, aV3, aHeading);

        }
        else { return SpawnNewSpell(aV3, aHeading); }
    }

    protected GameObject SpawnNewSpell(Vector3 aV3, bool aHeading)
    {
        GameObject newSpell = Instantiate(spell, aV3, Quaternion.identity);
        Spell enemC = newSpell.GetComponent<Spell>();
        enemC.Pool = pool;
        enemC.headLeft = aHeading;

        return newSpell;
    }

    protected GameObject SpawnUsedSpell(Spell aSpell, Vector3 aV3, bool aHeading)
    {
        aSpell.Activate(aV3);
        aSpell.headLeft = aHeading;
        return aSpell.gameObject;
    }
}
