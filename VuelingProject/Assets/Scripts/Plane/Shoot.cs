using UI;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public GameObject points;
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(points);
            UIManager.Instance.currency += 20;
            UIManager.Instance.currencyDisplayer.text = "Money: " + UIManager.Instance.currency;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
