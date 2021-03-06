﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 时间触发器
/// </summary>
public class TriggerTimer : TriggerBase
{
    /// <summary>
    /// 等待时长
    /// </summary>
    public float m_fTimerTime;

    /// <summary>
    /// <para>物体名</para>
    /// <para>空则是隐形的</para>
    /// </summary>
    public string m_strItemName;

    void Awake()
    {
        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 触发
    /// </summary>
    public override void OnTrigger()
    {
        base.OnTrigger();
        
        StopCoroutine("CountTime");
        StartCoroutine("CountTime");

        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (!string.IsNullOrEmpty(m_strItemName))
            {
                TriggerModelLoader.Get(this).Load("Item/" + m_strItemName);
            }
        }
    }

    /// <summary>
    /// 计时
    /// </summary>
    /// <returns></returns>
    private IEnumerator CountTime()
    {
        yield return new WaitForSeconds(m_fTimerTime);
        OnFinish();
        yield return null;
    }
}
