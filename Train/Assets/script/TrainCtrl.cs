using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCtrl : MonoBehaviour
{
    public float f;
    public Vector2 move;
    public bool PcTest;
    public bool mode1;
    public Vector2 muBiao;
    public Vector2 point;

    // Start is called before the first frame update
    void Start()
    {
        muBiao = transform.position + Random.insideUnitSphere * 10;
    }

    private void FixedUpdate()
    {

    }

    private void PCInput()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        move.x = muBiao.x - transform.position.x;
        move.y = muBiao.y - transform.position.y;

        if (PcTest)
        {
            PCInput();
            this.transform.GetComponent<Rigidbody2D>().AddForce(move.normalized * f, ForceMode2D.Force);//给脚添加力
        }

        if (mode1)
        {
            if (move.magnitude<0.1)
            {
                muBiao = transform.position + Random.insideUnitSphere * 10;
            }
            this.transform.GetComponent<Rigidbody2D>().AddForce(move.normalized * f, ForceMode2D.Impulse);//给脚添加力
        }
    }
}
