using UnityEngine;
using System.Collections;

public class Player : MovingObject
{
    private Animator animator;

    public bool isDraging = false;
    public float originRopeLen = 0f;

    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        baseSpeed = GameConfig.PlayerSpeed;
    }

    private void Update()
    {
        // hero input here
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir = new Vector2(x, y).normalized;
    }

    private void LateUpdate()
    {
        MoveDir(moveDir);
    }

    /// <summary>
    /// 计算绳子牵引力
    /// </summary>
    /// <returns></returns>
    public override Vector2 CalForce()
    {
        return Vector2.zero;
    }
}
