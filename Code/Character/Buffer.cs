using UnityEngine;
using System.Collections;

/// <summary>
/// Buffer
/// </summary>
public class Buffer : MonoBehaviour
{
    /// <summary>
    /// 玩家属性
    /// </summary>
    private PlayerAttr m_PlayerAttr;

    /// <summary>
    /// Buff类型
    /// </summary>
    public enum BuffType
    {
        /// <summary>
        /// 加血
        /// </summary>
        BLOOD = 0,

        /// <summary>
        /// 连跳次数
        /// </summary>
        JUMP_COUNT,
    }

    /// <summary>
    /// 类型
    /// </summary>
    public BuffType m_type;

    /// <summary>
    /// 值
    /// </summary>
    public int m_iValue = 0;

    /// <summary>
    /// <para>作用时长</para>
    /// <para>小于等于0表示永久</para>
    /// </summary>
    public float m_fTime = 1f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Buffer newBuff = col.gameObject.AddComponent<Buffer>();
            newBuff.Work(this);
        }
    }

    /// <summary>
    /// 工作
    /// </summary>
    public void Work(Buffer buff)
    {
        m_PlayerAttr = this.gameObject.GetComponent<PlayerAttr>();
        if (m_PlayerAttr == null)
        {
            return;
        }

        m_fTime = buff.m_fTime;
        m_iValue = buff.m_iValue;
        m_type = buff.m_type;

        StartCoroutine("WorkBuff");
    }

    /// <summary>
    /// 执行Buff
    /// </summary>
    private IEnumerator WorkBuff()
    {
        ChangeAttr(true);

        if (m_fTime <= 0f)
        {
            yield break;
        }

        yield return new WaitForSeconds(m_fTime);

        ChangeAttr(false);

        Destroy(this);
    }

    /// <summary>
    /// 变化属性
    /// </summary>
    /// <param name="add"></param>
    private void ChangeAttr(bool add)
    {
        if (m_PlayerAttr == null)
        {
            return;
        }

        int sign = add ? 1 : -1;

        switch (m_type)
        {
            case Buffer.BuffType.BLOOD:
                {
                    m_PlayerAttr.Blood += sign * m_iValue;
                }
                break;
            case Buffer.BuffType.JUMP_COUNT:
                {
                    m_PlayerAttr.JumpCount += sign * m_iValue;
                }
                break;
        }
    }
}
