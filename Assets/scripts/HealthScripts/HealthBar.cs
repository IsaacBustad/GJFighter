using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float hBScale;
    private float strtHealthScale;
    [SerializeField]private PlayerHealth plyerHealth;

    private void Start()
    {
        strtHealthScale = gameObject.transform.localScale.x;
    }

    public void UpdateHB()
    {
        float changeAmt;
        changeAmt = plyerHealth.curHealth / plyerHealth.maxHealth;
        //strtScale = gameObject.transform.localScale.x;
        hBScale = strtHealthScale * changeAmt;

        // change health bar scale
        gameObject.transform.localScale = new Vector3(hBScale, 1, 1);

    }

}
