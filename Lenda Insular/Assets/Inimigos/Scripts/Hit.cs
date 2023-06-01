using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject TxtHitPrefab;
    private GameObject clone;
    private float moveSpeed = 1f;
    private float destroyDelay = 2f;
    void Start()
    {
        TxtHitPrefab.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
            clone = Instantiate(TxtHitPrefab, transform.position, Quaternion.identity);
            clone.SetActive(true);

            clone.transform.rotation = transform.rotation; // Define a rotação do clone igual à rotação do objeto pai

            StartCoroutine(MoveCloneUp());
            Destroy(clone, destroyDelay);
        
    }

    private IEnumerator MoveCloneUp()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = clone.transform.position;
        Vector3 targetPosition = initialPosition + Vector3.up;

        Quaternion initialRotation = clone.transform.rotation; // Salva a rotação inicial do clone
        Quaternion targetRotation = transform.rotation; // Utiliza a rotação do objeto pai como rotação alvo

        while (elapsedTime < destroyDelay)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / destroyDelay;
            clone.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            clone.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t); // Utiliza Slerp para interpolar a rotação

            yield return null;
        }
    }

}