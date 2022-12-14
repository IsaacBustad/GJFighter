using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float hBScale;

    private float strtScale;

    [SerializeField]private PlayerHealth plyerHealth;

    private void Start()
    {
        strtScale = gameObject.transform.localScale.x;
    }

    public void Update()
    {
        float changeAmt;

        changeAmt = plyerHealth.CurHealth / plyerHealth.MaxHealth;

        //strtScale = gameObject.transform.localScale.x;
        hBScale = strtScale * changeAmt;

        // change health bar scale
        gameObject.transform.localScale = new Vector3(hBScale, 80, 80);

    }

}
