using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(TriggerBase))]
public class TriggerBaseInspector : Editor
{
    /// <summary>
    /// 基类
    /// </summary>
    protected TriggerBase m_BaseTrigger;

    public override void OnInspectorGUI()
    {
        m_BaseTrigger = target as TriggerBase;
        DrawAttr();
    }

    /// <summary>
    /// 绘制属性
    /// </summary>
    public virtual void DrawAttr()
    {
        m_BaseTrigger.m_Father = EditorGUILayout.ObjectField("触发者", m_BaseTrigger.m_Father, typeof(TriggerBase), true) as TriggerBase;
    }
}
