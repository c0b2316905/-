using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;

    private GameObject Player;
    private GameDirector gameDirector;

    private float rBullet;
    private float rPlayer;

    private SpriteRenderer bulletRenderer;
    private SpriteRenderer playerRenderer;

    void Start()
    {
        this.speed = 15.0f;
        Player = GameObject.Find("Player");
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        bulletRenderer = GetComponent<SpriteRenderer>();

        if (Player != null)
        {
            playerRenderer = Player.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
                rPlayer = playerRenderer.bounds.extents.y;
        }

        if (bulletRenderer != null)
        {
            rBullet = bulletRenderer.bounds.extents.y;
        }
    }

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 posBullet = transform.position;
        Vector2 posPlayer = Player.transform.position;

        float distance = Vector2.Distance(posBullet, posPlayer);
        if (distance < rBullet + rPlayer / 1.3f)
        {
            gameDirector.HitByBullet();
            Destroy(gameObject);
        }
    }
}