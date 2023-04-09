using System.Collections.Generic;
using UnityEngine;

// 只存放一种类型物体的简单对象池
public class SimplePool : MonoBehaviour
{
    // 私有字段加SerializeField，可以在编辑器中编辑，但其它脚本不可访问
    [SerializeField]
    private GameObject _prefab;

    // 队列，与List类似的容器，先进先出。
    private Queue<GameObject> _pooledInstanceQueue = new Queue<GameObject>();

    // 通过对象池创建物体
    public GameObject Create()
    {
        if (_pooledInstanceQueue.Count > 0)
        {
            // 如果队列中有，直接取出来一个
            GameObject go = _pooledInstanceQueue.Dequeue();
            go.SetActive(true);
            return go;
        }

        // 如果队列空了，就创建一个
        return Instantiate(_prefab);
    }

    // 通过对象池销毁物体
    public void Destroy(GameObject go)
    {
        // 将不再使用的物体放回队列
        _pooledInstanceQueue.Enqueue(go);
        go.SetActive(false);
        // 为方便管理，所有的物体都以 对象池 为父物体
        go.transform.SetParent(gameObject.transform);
    }
}