using System.Collections;
using UnityEngine;

public class EnemyGenerator : AbstractGenerator<Enemy>
{
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private int _spawnCooldown;
    [SerializeField] private Transform _targetTransform;
    
    private void Start()
    {
        Generate();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var cooldown = new WaitForSeconds(_spawnCooldown);
        while (_enemiesToSpawn > 0)
        {
            TryGetObject();
            yield return cooldown;
        }
    }

    
    public override Enemy TryGetObject()
    {
        var newEnemy = base.TryGetObject();
        if (_enemiesToSpawn > 0 && newEnemy != null)
        {
            _enemiesToSpawn--;
            newEnemy.SetTarget(_targetTransform);
            newEnemy.ResetHealth();
        }
        
        return newEnemy;
    }
}
