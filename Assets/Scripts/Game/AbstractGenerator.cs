using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class AbstractGenerator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _template;
    [SerializeField] protected Transform _startPoint;
    [SerializeField] protected List<GameObject> _generatedObjects = new List<GameObject>();

    protected virtual void Generate(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            var temp = Instantiate(_template, _startPoint);
            temp.gameObject.SetActive(false);
            _generatedObjects.Add(temp.gameObject);
        }
    }

    public virtual T GetObject()
    {
        var temp = _generatedObjects.FirstOrDefault(t => !t.activeSelf);
        if (temp == null)
            return null;
        
        temp.transform.position = _startPoint.position;
        temp.SetActive(true);
        return temp.GetComponent<T>();
    }

    public virtual void ReturnObject(T obj)
    {
        obj.transform.parent = _startPoint;
        obj.gameObject.SetActive(false);
    }
}
