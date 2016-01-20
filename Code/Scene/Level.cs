using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 关卡
/// </summary>
public class Level : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    private static Level m_instance;

    /// <summary>
    /// 单例
    /// </summary>
    public static Level Instance
    {
        get
        {
            if (m_instance == null)
            {
                GameObject instGo = GameObject.FindGameObjectWithTag("Level");
                if (instGo != null)
                {
                    m_instance = instGo.GetComponent<Level>();
                }
            }
            return m_instance;
        }
    }

    /// <summary>
    /// 主角位置
    /// </summary>
    public Vector3 m_PlayerPos;

    /// <summary>
    /// 触发器
    /// </summary>
    public List<TriggerBase> m_listTrigger;

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        CreateTrigger();
    }

    /// <summary>
    /// 触发器结束
    /// </summary>
    public delegate void OnTriggerFinish(TriggerBase trigger);

    /// <summary>
    /// 触发器结束事件
    /// </summary>
    public event OnTriggerFinish onTriggerFinish = null;

    /// <summary>
    /// 触发器结束
    /// </summary>
    /// <param name="trigger"></param>
    private void OnTriggerDead(TriggerBase trigger)
    {
        if (onTriggerFinish != null)
        {
            onTriggerFinish(trigger);
        }
    }

    /// <summary>
    /// 创建触发器
    /// </summary>
    private void CreateTrigger()
    {
        foreach (TriggerBase config in m_listTrigger)
        {
            config.enabled = true;
            config.onTriggerFinish -= OnTriggerDead;
            config.onTriggerFinish += OnTriggerDead;
        }
    }
}
