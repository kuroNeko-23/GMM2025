using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    [Header("Reduce Sanity Rate Settings")]
    [SerializeField] private float reduceRateAmount = 5f;
    
    public SanityBarScript sanityBarScript;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the safe zone: " + gameObject.name);
            sanityBarScript.ReduceSanityRate(reduceRateAmount);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exit the safe zone: " + gameObject.name);
            sanityBarScript.ReduceSanityRate(-reduceRateAmount);
        }
        
    }
}
