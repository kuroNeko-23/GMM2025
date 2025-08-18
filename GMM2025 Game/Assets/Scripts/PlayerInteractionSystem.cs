using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    GameObject hitObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if( hit.collider.CompareTag("Prop"))
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Prop object detected: " + hit.collider.name);
                }
            }
            
            if (hit.collider.CompareTag("PropToDestroy"))
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Prop object detected: " + hit.collider.name);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
