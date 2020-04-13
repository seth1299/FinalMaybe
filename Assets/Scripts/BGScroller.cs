using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    private float scrollSpeedClone;

    private Vector3 startPosition;

    bool boo = false;

    public GameObject obj;
    public GameObject starfield;
    public GameObject starfield2;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(AdvanceToNextLevel());
        scrollSpeedClone = scrollSpeed;
    }

    void Update()
    {
       boo = obj.GetComponent<GameController>().GetGameOver();
        
      float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }

    IEnumerator AdvanceToNextLevel()
    {
        
        while (true)
        {
            if (boo == true)
            {

                scrollSpeed = -70;

                yield return new WaitForSeconds(3.0f);

                scrollSpeed = scrollSpeedClone;

                starfield.SetActive(true);

                starfield2.SetActive(false);

                break;
            }
            else
            {
                yield return new WaitForSeconds(0.00001f);
            }
        }

    }

}
