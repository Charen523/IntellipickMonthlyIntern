using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public int arrowDmg;
    private Vector3 endPos;

    private bool isShoot = false;

    private void Update()
    {
        if (isShoot)
        {
            rb.velocity = Vector2.right * 10;
            if (transform.position == endPos)
            {
                ResetArrow();
            }
        }
    }

    public void GetAttackSign(Vector3 start, int damage)
    {
        isShoot = true;
        rb.position = start;
        endPos = new Vector3(10, start.y, 0);
    }

    private void ResetArrow()
    {
        isShoot = false;
        transform.position = endPos;
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameManager.Instance.curMonster.OnDamage(arrowDmg);
            ResetArrow();
        }
    }
}