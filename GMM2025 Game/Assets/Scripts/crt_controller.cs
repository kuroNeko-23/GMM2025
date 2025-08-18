using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class crt_controller : MonoBehaviour
{
    [SerializeField] private Volume volume;

    private ChromaticAberration ca;
    private FilmGrain fg;
    private LensDistortion ld;

    [SerializeField]
    private float maxFilmGrainIntensity;
    [SerializeField]
    private float maxLenDistortionIntensity;

    [SerializeField, Range(0f, 1f)]
    private float intensity = 0f;


    void Start()
    {
        if (volume != null)
        {
            // Get overrides from the Volume profile
            volume.profile.TryGet(out ca);
            volume.profile.TryGet(out fg);
            volume.profile.TryGet(out ld);
        }
    }

    void Update()
    {
        if (fg != null)
        {
            fg.intensity.value = intensity * maxFilmGrainIntensity;
        }
        if (ld != null)
        {
            ld.intensity.value = intensity * maxLenDistortionIntensity;
        }    
        if (ca != null)
        {
            ca.intensity.value = intensity; // CA intensity
        }
    }
}
