using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    public List<Material> skyBoxs = new List<Material>();
    public float time = 30f;
    private int i;
    void Start()
    {
        StartCoroutine(SetSkyBox());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator SetSkyBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(time * ManagerModel.SkyCutSpeedTimes);
            RenderSettings.skybox = skyBoxs[i];
            if(i < skyBoxs.Count - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }
}
