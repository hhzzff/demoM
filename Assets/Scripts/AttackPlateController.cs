using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlateController : MonoBehaviour
{
    public int damage;
    public float CD;
    private float CDTimer = 0;
    private AttackPlateEffectController attackPlateEffectController;
    // Start is called before the first frame update
    void Start()
    {
        attackPlateEffectController = transform.GetChild(0).gameObject.GetComponent<AttackPlateEffectController>();
    }

    // Update is called once per frame
    void Update()
    {
        CDTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && CDTimer <= Mathf.Epsilon) {
            GameManager.GetInstance().enemyBase.TakeDamage(damage);
            CDTimer = CD;
            attackPlateEffectController.Play();
        }
    }
}
