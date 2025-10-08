using Unity.VisualScripting;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";
    [SerializeField] private Transform originPoint;

    public int id;
    public int val;

    [SerializeField] GameObject manager;
    [SerializeField] Game_Manager gm;

    private Sprite _sprite;


    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        manager = GameObject.FindWithTag("Game_Manager");
        gm = manager.GetComponent<Game_Manager>();
    }

    private void Start()
    {
        if (id == Game_Manager.instance.data.idReponse)
        {
            val = 700;
        }
        else
        {
            val = 0;
        }

        if (id == 1)
            _sprite = Game_Manager.instance.data.Reponse1;
        else if (id == 2)
            _sprite = Game_Manager.instance.data.Reponse2;
        else
            _sprite = Game_Manager.instance.data.Reponse3;

        gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    void OnMouseDown()
    {
        if (gm.phaseReponse)
        {
            offset = transform.position - MouseWorldPosition();
        }
        
    }

    void OnMouseDrag()
    {
        if (gm.phaseReponse)
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }

    void OnMouseUp()
    {
        if (gm.phaseReponse)
        {
        collider2d.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit2D hitInfo;

        if (hitInfo = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            Solution solut = hitInfo.collider.GetComponent<Solution>();
            
            if (solut == null)
            {
                collider2d.enabled = true;
                return;
            }
            else
            {
                if (hitInfo.transform.tag == destinationTag)
                {
                    transform.position = hitInfo.transform.position + new Vector3(0, 0, -0.01f);

                        ScoreManager.instance.UpdateScore(val);
                    
                    
                }
                
                
            }

            
        }
        collider2d.enabled = true;
        }
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}