using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody2D rb;

    [SerializeField] Tilemap tilemap;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(tilemap.size);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

            TileBase tile = tilemap.GetTile(cellPos);

            tilemap.SetTileFlags(cellPos, TileFlags.None);
            tilemap.SetColor(cellPos, Color.red);

            Debug.Log("positie" + cellPos);


        }



        float move = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Horizontal");

        transform.Rotate(0, 0, -rot *3);

        rb.MovePosition(rb.position + (Vector2)transform.right * move * speed * Time.fixedDeltaTime);
    }
}
