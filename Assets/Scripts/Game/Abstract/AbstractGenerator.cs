using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class AbstractGenerator<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] protected T _template;
    [SerializeField] protected List<GameObject> _generatedObjects = new List<GameObject>();
    
    protected virtual void Generate()
    {
        for (int i = 0; i < _capacity; i++)
        {
            var temp = Instantiate(_template, transform);
            temp.gameObject.SetActive(false);
            _generatedObjects.Add(temp.gameObject);
        }
    }

    public virtual T TryGetObject()
    {
        var temp = _generatedObjects.FirstOrDefault(t => !t.activeSelf);
        if (temp == null)
            return null;
        
        temp.transform.position = transform.position;
        temp.SetActive(true);
        return temp.GetComponent<T>();
    }
}
