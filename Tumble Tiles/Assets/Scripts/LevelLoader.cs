using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public RaycastHit2D raycastHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var screenRay = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            RaycastHit2D hit = Physics2D.GetRayIntersection(screenRay);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
