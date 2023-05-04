using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingController : MonoBehaviour
{
    private bool isFishing;
    private bool canFish;
    public CharacterController cc;

    public float fishingTime = 1;

    public Fish[] fish;
    private Fish selectedFish;
    public GameObject canfishText;
    public GameObject fishingText;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canFish && !isFishing)
        {
            fishingTime = Random.Range(1, 4);
            isFishing = true;
            canfishText.SetActive(false);
            fishingText.SetActive(true);
            selectedFish = fish[Random.Range(0, fish.Length)];
            StartCoroutine("fishing");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>())
        {
            canFish = true;
            canfishText.SetActive(true);
            fishingText.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterController>())
        {
            canFish = false;
            isFishing = false;
            canfishText.SetActive(false);
            fishingText.SetActive(false);
            StopCoroutine("fishing");
        }
    }

    IEnumerator fishing()
    {
        yield return new WaitForSeconds(fishingTime);
        fishingText.SetActive(false);
        isFishing = false;
        DropItems();
    }

    void DropItems()
    {
        GameObject go = new GameObject(selectedFish.name + "Drop");
        go.tag = "VegetableDrop";
        DropController dc = go.AddComponent<DropController>();
        dc.worth = selectedFish.worthPer;

        CircleCollider2D col = go.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
        SpriteRenderer ren = go.AddComponent<SpriteRenderer>();
        ren.sprite = selectedFish.fish;
        ren.sortingOrder = 1;
        //go.transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        go.transform.position = RandomPointInRing(cc.transform.position, 1, 2);

        Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        Rigidbody2D rb = go.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.drag = 5;
        rb.AddForce(dropDirection * 2f, ForceMode2D.Impulse);

        if(canFish)
        {
            canfishText.SetActive(true);
            fishingText.SetActive(false);
        }
    }

    public Vector3 RandomPointInRing(Vector2 origin, float minRadius, float maxRadius)
    {
        var randomDirection = (Random.insideUnitCircle * origin).normalized;
        var randomDistance = Random.Range(minRadius, maxRadius);
        var point = origin + randomDirection * randomDistance;
        return point;
    }
}
