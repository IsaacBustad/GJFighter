// Isacc Bustad
// 10/10/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stanima : MonoBehaviour
{
    // vars
    [SerializeField] protected float maxStamina = 100;
    [SerializeField] protected float curStamina = 100;


    // regen vars
    [SerializeField] protected float regenSpeed = 100;
    protected bool onDelay = false;
    protected bool canRegen = true;
    protected WaitForSeconds waitToStamRegen;
    protected float timeToStamDelay = 3;



    // functions
    protected void Start()
    {
        waitToStamRegen = new WaitForSeconds(timeToStamDelay);
    }

    protected void FixedUpdate()
    {
        RegenerateStamina();
    }

    protected void StaminaSystem()
    {
        if (canRegen)
        {
            RegenerateStamina();
        }
        else if (!onDelay)
        {
            ResetStamDelay();
        }
    }

    public float GiveStamina(float reqStam)
    {
        float retStam = 0;

        if (curStamina > reqStam)
        {
            curStamina -= reqStam;
            retStam = reqStam;
        }

        else if (curStamina < reqStam && curStamina > 0)
        {
            retStam = curStamina;
            curStamina = 0;
        }

        //ResetStamDelay();

        return retStam;
    }

    protected void RegenerateStamina()
    {
        if (curStamina < maxStamina)
        {
            curStamina += regenSpeed * Time.deltaTime;
            curStamina = Mathf.Clamp(curStamina, 0, maxStamina);
        }
    }

    public void ResetStamDelay()
    {
        canRegen = false;
        StopAllCoroutines();
        StartCoroutine(DelayStamRegen());
    }

    // coroutines 
    protected IEnumerator DelayStamRegen()
    {
        onDelay = true;
        yield return waitToStamRegen;
        canRegen = true;
    }





    // accessors
    public float CurStamina { get { return curStamina; } }
    public float MaxStamina { get { return maxStamina; } }
}
