using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaoSetting : MonoBehaviour
{
    [SerializeField] GameObject goPre;
    [SerializeField] int anpha = 5;
    [SerializeField] Vector2 velocity2d;
    public int level;
    public Color color;
    // Start is called before the first frame update
    private void Start()
    {
        transform.GetComponent<SpriteRenderer>().color = color;
    }
    // Update is called once per frame
    public IEnumerator Destroy()
    {
        if(level < 2)
        {
            int x = (int)Random.Range(0, 10);
            if (x == 1 || level == 0)
            {
                float velocity = Random.Range(velocity2d.x, velocity2d.y);
                for (int i = 0; i < (int)Random.Range(2, 5); i++)
                {
                    Color cl = Random.ColorHSV();
                    for (int j = 0; j < 360; j += anpha + 20*i)
                    {
                        GameObject go = Instantiate(goPre, transform.position, Quaternion.Euler(0, 0, j));
                        PhaoSetting phaoSetting = go.GetComponent<PhaoSetting>();
                        phaoSetting.level = level + 1;
                        phaoSetting.color = cl;
                        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
                        float angleInRadians = Mathf.Deg2Rad * j;
                        Vector2 forceDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
                        /*if (j >= 40 && j <= 150)
                            velocity *= 0.8f;*/
                        AudioController.instance.Play(2, 1);
                        rb.AddForce(forceDirection * velocity / (2*i + 1));
                    }
                    yield return new WaitForSeconds(Random.Range(0.2f, 1f));
                }
            }
        }
        Destroy(gameObject, Random.Range(1, 3));
    }
}
