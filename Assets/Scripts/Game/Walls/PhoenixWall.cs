using System.Collections;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(BoxCollider2D))]
public class PhoenixWall : BreakableWall
{
    [SerializeField] private float _delay;
    [SerializeField] private Sprite _aliveSprite;
    [SerializeField] private Sprite _deadSprite;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    protected override void Start()
    {
        base.Start();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private IEnumerator DelayedRespawn()
    {
        yield return new WaitForSeconds(_delay);
        _spriteRenderer.sprite = _aliveSprite;
        _collider.isTrigger = false;
    }

    protected override void Die()
    {
        _spriteRenderer.sprite = _deadSprite;
        _collider.isTrigger = true;
        StartCoroutine(DelayedRespawn());
    }
}
