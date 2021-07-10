using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour
{
    public float baseSpeed;


    protected Vector2 moveDir;

    protected Rigidbody2D rg2d;

    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    public void MoveDir(Vector2 dir)
    {
        Vector2 force = CalForce();
        Vector2 velocity = ApplyForce(force);
        rg2d.velocity = velocity;

        Debug.Log(string.Format(
    $"hero velocity is : x = {0}, y = {1}, speed = {2}",
    rg2d.velocity.x, rg2d.velocity.y, rg2d.velocity.magnitude));
    }

    public abstract Vector2 CalForce();

    /// <summary>
    /// 对物体应用一个力，返回应用之后的速度
    /// </summary>
    /// <param name="force"></param>
    /// <returns></returns>
    public Vector2 ApplyForce(Vector2 force)
    {
        // 绳子无作用力的时候，使用默认的速度参数
        if (force == Vector2.zero) {
            return moveDir * baseSpeed;
        }
        //Vector2 manualyForce = 
        Vector2 adjustedSpeed = moveDir * baseSpeed + rg2d.velocity;
        if (adjustedSpeed.magnitude > baseSpeed)
        {
            adjustedSpeed = adjustedSpeed.normalized * baseSpeed;
        }
        return adjustedSpeed + force * Time.fixedDeltaTime;
    }
}
