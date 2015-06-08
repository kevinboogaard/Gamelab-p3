using UnityEngine;
using System.Collections;

public class ChangeTailArt : MonoBehaviour {

    public Sprite tailSprite;
    public Sprite bodySprite;
    private SpriteRenderer spriterenderer;

    void Awake() {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeArt(bool tail) {
        if (tail == true) {
            spriterenderer.sprite = tailSprite;
            Invoke("ChangeBack", 0.3f);
        }
        else {
            spriterenderer.sprite = bodySprite;
        }
    }
    void ChangeBack() {
        ChangeArt(false);
    }
}
