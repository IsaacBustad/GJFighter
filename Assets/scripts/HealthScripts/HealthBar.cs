using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float hBScale;
    private float strtScale;
    [SerializeField]private Health3 plyerHealth;

    private void Start()
    {
        strtScale = gameObject.transform.localScale.x;
    }

    public void UpdateHB()
    {
        float changeAmt;
        changeAmt = plyerHealth.currentHealth / plyerHealth.StartingHealth;
        //strtScale = gameObject.transform.localScale.x;
        hBScale = strtScale * changeAmt;

        // change health bar scale
        gameObject.transform.localScale = new Vector3(hBScale, 1, 1);

    }

}
