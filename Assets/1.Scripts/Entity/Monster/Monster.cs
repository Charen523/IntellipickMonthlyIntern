using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class MonsterAnimData
{
    [SerializeField] private string dieParam = "IsDie";
    public int DieParamHash { get; private set; }

    public void Initialize()
    {
        DieParamHash = Animator.StringToHash(dieParam);
    }
}

public class Monster : MonoBehaviour, IPointerClickHandler
{
    public MonsterAnimData AnimData { get; private set; }
    public MonsterData data;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D col;
    [SerializeField] private LayerMask groundLayer;

    private bool canMove = false;

    [SerializeField] private Transform hpBar;
    public int curHealth;

    private void Awake()
    {
        AnimData = new MonsterAnimData();
        AnimData.Initialize();
    }

    private void OnEnable()
    {
        if (data != null)
        {
            curHealth = data.Health;
            hpBar.localScale = new Vector3(1, 0.06f, 1);

            Vector3 newPosition = transform.position;
            newPosition.x = 10;
            transform.position = newPosition;

            canMove = false;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            Move(data.Speed);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MonsterInfoPopup popup = GameManager.Instance.MonsterInfo;
        popup.gameObject.SetActive(true);
        popup.SetInfoTxt(data);
    }

    public void SetMonsterData(string monsterKey, RuntimeAnimatorController animator)
    {
        data = DataManager.Instance.LoadData<MonsterData>(monsterKey);
        anim.runtimeAnimatorController = animator;
    }

    private void Move(float moveSpeed)
    {
        Vector3 direction = Vector3.left;
        rb.velocity = direction * moveSpeed;
    }

    public void OnDamage(int damage)
    {
        curHealth = Mathf.Max(0, curHealth - damage);
        float hp = (float)curHealth / data.Health;

        hpBar.localScale = new Vector3(hp, 0.06f, 1);

        if (curHealth == 0)
        {
            rb.velocity = Vector3.zero;
            anim.SetTrigger(AnimData.DieParamHash);
            col.enabled = false;
        }
    }

    public void Die()
    {
        col.enabled = true;
        GameManager.Instance.MonsterDeadEvent();
        GameManager.Instance.SpawnMonster();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            canMove = true;
        }
    }
}