using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb; // физика персонажа
    public Animator anim; // анимации персонажа
    public float speed; // скорость
    public bool isMove; // возможно ли движение?

    private Vector2 moveVector; // вектор перемещения

    public int direction { get; set; } // направление

    /// <summary>
    /// атаковать противника
    /// </summary>
    public void Attack()
    {
        direction = 0;
        anim.SetBool("isAttack", true);
    }

    /// <summary>
    /// закончить атаку
    /// </summary>
    public void StopAttack()
    {
        anim.SetBool("isAttack", false);
    }

    /// <summary>
    /// перемещение
    /// </summary>
    private void Update()
    {
        if (isMove)
            Move(direction);
        else
            StopMovement();
    }

    /// <summary>
    /// функция перемещения
    /// </summary>
    /// <param name="direction">направление</param>
    private void Move(int direction)
    {
        ChangeDirection(direction);
        moveVector.x = direction;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    /// <summary>
    /// изменить направление движения
    /// </summary>
    /// <param name="direction">направление</param>
    private void ChangeDirection(int direction)
    {
        if (direction == 0)
        {
            StopMovement();
        }
        else if (direction < 0)
        {
            LeftMovement();
        }
        else if (direction > 0)
        {
            RightMovement();
        }
    }

    /// <summary>
    /// остановить перемещение
    /// </summary>
    private void StopMovement()
    {
        anim.SetBool("isRun", false);
    }

    /// <summary>
    /// перемещение влево
    /// </summary>
    private void LeftMovement()
    {
        Flip(180);
        anim.SetBool("isRun", true);
    }

    /// <summary>
    /// перемещение вправо
    /// </summary>
    private void RightMovement()
    {
        Flip(0);
        anim.SetBool("isRun", true);
    }

    /// <summary>
    /// поворот персонажа
    /// </summary>
    /// <param name="rotation">градус поворота</param>
    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
