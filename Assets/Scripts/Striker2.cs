using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker2 : MonoBehaviour
{
    CircleCollider2D coll;
    Rigidbody2D rb;
    Transform trans;
    Vector2 startpos;
    Vector2 dir;
    Vector3 mousePos;
    Vector3 mousePos2;
    public Slider slider;
    public LineRenderer lineRenderer;
    bool striked = false;
    bool positionSet = false;
    public GameObject board;
    bool no = true;
    Transform arrowTrans;
    public GameObject arrowDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trans = transform;
        startpos = transform.position;
        arrowTrans = arrowDir.transform;
        coll = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puck" || collision.gameObject.tag == "queen")
        {
            no = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        no = true;
    }

    public void Strike()
    {
        float x = 0;

        if (positionSet && rb.velocity.magnitude == 0)
        {
            x = Vector2.Distance(transform.position, mousePos);
        }

        dir = (Vector2)(mousePos2 - transform.position);
        dir.Normalize();
        rb.AddForce(dir * x * 300);
        striked = true;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = false;
        arrowDir.SetActive(false);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 inverseMousePos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);
        mousePos2 = Camera.main.ScreenToWorldPoint(inverseMousePos);
        mousePos2.y = mousePos2.y + 3;
        if (trans.position.x != 0)
        {
            mousePos2.x = mousePos2.x + (trans.position.x * 2);
        }

        if (mousePos2.y > 2.66f)
        {
            mousePos2.y = 2.66f;
        }
        if (mousePos2.y < -0.521f)
        {
            mousePos2.y = -0.521f;
        }
        if (mousePos2.x < -2.67f)
        {
            mousePos2.y = -2.67f;
        }
        if (mousePos2.x > 2.05f)
        {
            mousePos2.x = 2.05f;
        }


        if (!striked && !positionSet)
        {
            coll.isTrigger = true;
            trans.position = new Vector2(slider.value, startpos.y);
        }
        if (Input.GetMouseButtonUp(0) && rb.velocity.magnitude == 0 && positionSet)
        {
            Strike();

        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0)&&no)
            {
                if (!positionSet)
                {
                    positionSet = true;
                    coll.isTrigger = false;
                }
            }
        }

        if (positionSet && rb.velocity.magnitude == 0)
        {
            arrowDir.SetActive(true);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, trans.position);
            lineRenderer.SetPosition(1, mousePos2);
            float angle = angleBtwn2Points(arrowTrans.position, mousePos2);
            arrowTrans.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        }
        if (rb.velocity.magnitude < .1f && rb.velocity.magnitude != 0)
        {
            SetStriker();
            board.GetComponent<gameManager>().count++;
        }

    }

    public void SetStriker()
    {
        rb.velocity = Vector2.zero;
        striked = false;
        positionSet = false;
        lineRenderer.enabled = true;
    }

    float angleBtwn2Points(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
