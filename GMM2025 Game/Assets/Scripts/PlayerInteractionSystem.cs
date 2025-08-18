using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    [SerializeField] private float maxDistance = 10f;
    public SanityBarScript sanityBarScript;
    

    void Update()
    {
        // Ray from screen center
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            GameObject hitObj = hit.collider.gameObject;

            // Check interaction input once
            if (Input.GetKeyDown(KeyCode.E))
            {
                string tag = hitObj.tag;

                if (tag == "Prop") // Assuming "Prop" is the tag for sanity-increasing objects
                {
                    sanityBarScript.IncreaseSanity(10f/ 100f);
                    Debug.Log("Prop object detected: " + hitObj.name);
                }
                else if (tag == "PropToDestroy")
                {
                    Debug.Log("PropToDestroy object detected: " + hitObj.name);
                    Destroy(hitObj);
                }
            }
        }
    }
}
