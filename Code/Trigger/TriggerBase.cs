using UnityEngine;
using System.Collections;

/// <summary>
/// 触发器基类
/// </summary>
public class TriggerBase : MonoBehaviour
{
    /// <summary>
    /// ID
    /// </summary>
    public int m_iUniqueID;

    /// <summary>
    /// 是否是通关触发器
    /// </summary>
    public bool m_bIsPassTrigger;

    /// <summary>
    /// 触发器结束
    /// </summary>
    public delegate void OnTriggerFinish(TriggerBase trigger);

    /// <summary>
    /// 触发器结束事件
    /// </summary>
    public event OnTriggerFinish onTriggerFinish = null;

    /// <summary>
    /// 是否还有效
    /// </summary>
    protected bool m_bIsLive = true;

    /// <summary>
    /// 父亲
    /// </summary>
    public TriggerBase m_Father;

    /// <summary>
    /// 初始化
    /// </summary>
    public virtual void Init(TriggerBase config)
    {
        m_iUniqueID = config.m_iUniqueID;
        m_bIsPassTrigger = config.m_bIsPassTrigger;
        m_Father = config.m_Father;
    }

    /// <summary>
    /// 开始
    /// </summary>
    public virtual void Start()
    {
        if (m_Father == null)
        {
            OnTrigger();
        }
        else
        {
            m_Father.onTriggerFinish += OnFatherTriggerFinish;
        }
    }

    /// <summary>
    /// 父节点结束
    /// </summary>
    /// <param name="trigger"></param>
    public void OnFatherTriggerFinish(TriggerBase trigger)
    {
        OnTrigger();
    }

    /// <summary>
    /// 触发
    /// </summary>
    public virtual void OnTrigger()
    {

    }

    /// <summary>
    /// 结束
    /// </summary>
    public virtual void OnFinish()
    {
        m_bIsLive = false;

        if (onTriggerFinish != null)
        {
            onTriggerFinish(this);
        }

        if(this.transform.gameObject != null)
        {
            UnityEngine.Object.Destroy(this.transform.gameObject);
        }
    }

    void OnDestroy()
    {
        if (m_bIsLive)
        {
            OnFinish();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (m_Father != null)
        {
            Gizmos.DrawLine(m_Father.transform.position, this.transform.position);
            m_Father.OnDrawGizmosSelected();
        }
    }
}
