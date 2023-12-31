using System.Collections;
using System.Collections.Generic;
using RObo;
using Sirenix.OdinInspector;
using UnityEngine;

public class Robot : Singleton<Robot>
{
    [SerializeField] private SpriteRenderer anh;
    private GameDataManager gameDataManager;

    public Rigidbody2D rigidbody;
    public Collider2D collider;

    void Start()
    {
        gameDataManager = GameDataManager.Instance;
    }

    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    [Button]
    public void FrogJump(float power)
    {
        rigidbody.constraints = RigidbodyConstraints2D.None;
        rigidbody.AddForce(Vector2.one * power, ForceMode2D.Force);
    }

    
    
    public void EndRun()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        collider.isTrigger = false;
    }

    public void Run()
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        collider.isTrigger = true;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    
}