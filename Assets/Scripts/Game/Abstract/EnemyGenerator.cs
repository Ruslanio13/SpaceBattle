using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : AbstractGenerator<Enemy>
{
    [SerializeField] private int _spawnCooldown;
    [SerializeField] private List<Entity> _targets;
    [SerializeField] private int _startEnemiesToSpawn;
    private int _enemiesToSpawn;
    
    private List<Transform> _targetsTransforms;

    private void Start()
    {
        _enemiesToSpawn = _startEnemiesToSpawn;
        _targetsTransforms = new List<Transform>();
        foreach (var target in _targets)
            _targetsTransforms.Add(target.transform);
        
        GameStateMachine.Instance.OnGameOver.AddListener(StopAllCoroutines);
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
        var random = Random.Range(0, _targets.Count);
        var newEnemy = base.TryGetObject();
        if (newEnemy is null)
            return null;

        _enemiesToSpawn--;
        newEnemy.SetTarget(_targetsTransforms[random]);
        newEnemy.ResetHealth();
        GameStateMachine.Instance.OnGameOver.AddListener(newEnemy.RunAway);
        
        return newEnemy;
    }

    public int GetEnemiesAmount() => _startEnemiesToSpawn;
}
