using UnityEngine;
using System.Collections;

/// <summary>
/// 触发器模型加载器
/// </summary>
public class TriggerModelLoader : MonoBehaviour
{
    /// <summary>
    /// 触发器
    /// </summary>
    private TriggerBase m_Trigger;

    /// <summary>
    /// 模型加载成功
    /// </summary>
    /// <param name="go"></param>
    public delegate void OnModelLoaded(GameObject go);

    /// <summary>
    /// 模型加载成功
    /// </summary>
    public OnModelLoaded onModelLoaded = null;

    /// <summary>
    /// 获取
    /// </summary>
    /// <param name="trigger"></param>
    /// <returns></returns>
    public static TriggerModelLoader Get(TriggerBase trigger)
    {
        TriggerModelLoader loader = null;
        if (trigger == null)
        {
            return loader;
        }

        loader = trigger.transform.GetComponent<TriggerModelLoader>();
        
        if (loader == null)
        {
            loader = trigger.gameObject.AddComponent<TriggerModelLoader>();
        }
        
        loader.m_Trigger = trigger;

        return loader;
    }

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="modelPath">模型名，Item/Name</param>
    public void Load(string modelPath)
    {
        if(string.IsNullOrEmpty(modelPath))
        {
            return;
        }

        Resource res = ResourceManager.Instance.LoadResource(string.Format("{0}.unity3d", modelPath), false);
        res.onLoaded += OnLoaded;
    }

    /// <summary>
    /// <para>模型加载成功</para>
    /// </summary>
    /// <param name="res"></param>
    private void OnLoaded(Resource res)
    {
        if(m_Trigger == null)
        {
            return;
        }

        GameObject go = UnityEngine.Object.Instantiate(res.MainAsset) as GameObject;
        go.transform.parent = m_Trigger.transform;
        go.transform.localPosition = Vector3.zero;

        if (onModelLoaded != null)
        {
            onModelLoaded(go);
        }
    }
}
