using System;
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
    public MonsterData data { get; private set; }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D col;

    [SerializeField] private Transform hpBar;
    public int curHealth;

    [SerializeField] private GameObject InfoPanel;

    private void Awake()
    {
        AnimData.Initialize();
    }

    private void OnEnable()
    {
        if (data != null)
        {
            curHealth = data.Health;
            hpBar.localScale = new Vector3(1, 0.06f, 1);
        }
    }

    private void Update()
    {
        Move(data.Speed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        InfoPanel.SetActive(true);
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
        curHealth = Mathf.Max(0, damage);
        hpBar.localScale = new Vector3(curHealth / data.Health, 0.06f, 1);

        if (curHealth == 0)
        {
            GameManager.Instance.OnMonsterDead();
            anim.SetTrigger(AnimData.DieParamHash);
            col.enabled = false;
        }
    }

    public void Die()
    {
        col.enabled = true;
        gameObject.SetActive(false);
    }
}