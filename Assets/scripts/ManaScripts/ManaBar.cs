using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    private float manaScale;
    private float strtManaScale;
    [SerializeField] private Stanima playerMana;

    void Start()
    {
        strtManaScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float changeAmt;
        changeAmt = playerMana.CurStamina / playerMana.MaxStamina;
        //strtScale = gameObject.transform.localScale.x;
        manaScale = strtManaScale * changeAmt;

        // change health bar scale
        gameObject.transform.localScale = new Vector3(manaScale, 80, 80);
    }
}
