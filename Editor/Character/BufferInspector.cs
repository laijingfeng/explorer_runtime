using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Buffer))]
public class BufferInspector : Editor
{
    /// <summary>
    /// Buff
    /// </summary>
    protected Buffer m_Buffer;

    public override void OnInspectorGUI()
    {
        m_Buffer = target as Buffer;
        DrawAttr();
    }

    /// <summary>
    /// 绘制属性
    /// </summary>
    public virtual void DrawAttr()
    {
        m_Buffer.m_type = (Buffer.BuffType)EditorGUILayout.EnumPopup("类型", m_Buffer.m_type);
        m_Buffer.m_iValue = EditorGUILayout.IntField("价值", m_Buffer.m_iValue);
        m_Buffer.m_fTime = EditorGUILayout.FloatField("持续时间", m_Buffer.m_fTime);

        if (m_Buffer.GetComponent<BoxCollider2D>() == null)
        {
            BoxCollider2D box = m_Buffer.gameObject.AddComponent<BoxCollider2D>();
            box.isTrigger = true;
        }
    }
}
