using UnityEngine;
using System.Collections;

/// <summary>
/// 移除器
/// </summary>
public class Remover : MonoBehaviour
{
    /// <summary>
    /// 死亡动画
    /// </summary>
	public GameObject splash;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
            PlayerAttr.Instance.Blood = 0;   
		}

        Instantiate(splash, col.transform.position, transform.rotation);
        Destroy(col.gameObject);
	}
}
