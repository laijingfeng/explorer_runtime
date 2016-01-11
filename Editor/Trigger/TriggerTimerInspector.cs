using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TriggerTimer))]
public class TriggerTimerInspector : BaseTriggerInspector
{
    /// <summary>
    /// 时间触发器
    /// </summary>
    public TriggerTimer m_TriggerTimer;

    /// <summary>
    /// 绘制属性
    /// </summary>
    public override void DrawAttr()
    {
        base.DrawAttr();

        m_TriggerTimer = m_BaseTrigger as TriggerTimer;

        m_TriggerTimer.m_fTimerTime = EditorGUILayout.FloatField("等候时长(秒)", m_TriggerTimer.m_fTimerTime);
    }
}
