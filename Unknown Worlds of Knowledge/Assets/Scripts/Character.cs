using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb; // ������ ���������
    public Animator anim; // �������� ���������
    public float speed; // ��������
    public bool isMove; // �������� �� ��������?

    private Vector2 moveVector; // ������ �����������

    public int direction { get; set; } // �����������

    /// <summary>
    /// ��������� ����������
    /// </summary>
    public void Attack()
    {
        direction = 0;
        anim.SetBool("isAttack", true);
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    public void StopAttack()
    {
        anim.SetBool("isAttack", false);
    }

    /// <summary>
    /// �����������
    /// </summary>
    private void Update()
    {
        if (isMove)
            Move(direction);
        else
            StopMovement();
    }

    /// <summary>
    /// ������� �����������
    /// </summary>
    /// <param name="direction">�����������</param>
    private void Move(int direction)
    {
        ChangeDirection(direction);
        moveVector.x = direction;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    /// <summary>
    /// �������� ����������� ��������
    /// </summary>
    /// <param name="direction">�����������</param>
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
    /// ���������� �����������
    /// </summary>
    private void StopMovement()
    {
        anim.SetBool("isRun", false);
    }

    /// <summary>
    /// ����������� �����
    /// </summary>
    private void LeftMovement()
    {
        Flip(180);
        anim.SetBool("isRun", true);
    }

    /// <summary>
    /// ����������� ������
    /// </summary>
    private void RightMovement()
    {
        Flip(0);
        anim.SetBool("isRun", true);
    }

    /// <summary>
    /// ������� ���������
    /// </summary>
    /// <param name="rotation">������ ��������</param>
    private void Flip(int rotation)
    {
        rb.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
