using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BaseTrigger))]
public class BaseTriggerInspector : Editor
{
    /// <summary>
    /// 基类
    /// </summary>
    protected BaseTrigger m_BaseTrigger;

    public override void OnInspectorGUI()
    {
        m_BaseTrigger = target as BaseTrigger;
        DrawAttr();
    }

    /// <summary>
    /// 绘制属性
    /// </summary>
    public virtual void DrawAttr()
    {
        m_BaseTrigger.m_Father = EditorGUILayout.ObjectField("触发者", m_BaseTrigger.m_Father, typeof(BaseTrigger), true) as BaseTrigger;
    }
}
