using UnityEngine;
using System.Collections;

/// <summary>
/// 范围触发器
/// </summary>
public class TriggerRange : TriggerBase
{
    /// <summary>
    /// <para>物体名</para>
    /// <para>空则是隐形的</para>
    /// </summary>
    public string m_strItemName;

    void Awake()
    {
        if (this.transform.GetComponent<BoxCollider2D>() != null)
        {
            this.transform.GetComponent<BoxCollider2D>().enabled = false;
        }

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

        if (this.transform.GetComponent<BoxCollider2D>() != null)
        {
            this.transform.GetComponent<BoxCollider2D>().enabled = true;
        }

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            OnFinish();
        }
    }
}
