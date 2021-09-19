using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer sp;
    private Color startColor; 
    private float widthStep; //Change in width each hit
    public int maxDurability = 10;
    public int durability;
    public int colorOffsetModifier = 5;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        startColor = sp.color;
        widthStep = transform.localScale.x / maxDurability;
        durability = maxDurability;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If hit by ball, reduce durability
        if(collision.gameObject.tag == "Ball")
        {
            durability--;

            //Modify Color to be darker/more transparent
            Color currentColor = sp.color;
            sp.color = startColor * ((float) (durability + colorOffsetModifier) / (maxDurability + colorOffsetModifier));

            //Reduce Width
            transform.localScale = transform.localScale - Vector3.right * widthStep;
            
            if(durability <= 0)
            {
                gameObject.SetActive(false);
            }
        }   
    }
}
