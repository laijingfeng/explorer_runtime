using UnityEngine;
using System.Collections;

/// <summary>
/// Boss触发器
/// </summary>
public class TriggerBoss : TriggerBase
{
    /// <summary>
    /// Boss名称
    /// </summary>
    public string m_strBossName;

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

        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (!string.IsNullOrEmpty(m_strBossName))
            {
                TriggerModelLoader.Get(this).Load("Boss/" + m_strBossName);
            }
        }
    }
}
