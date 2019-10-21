using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    private Camera cam;

    public float transitionTime = 20.0f;
    private float initialLife;
    public float valueLife;
    public BirdController obj;

    public GameObject bar;

    void Start()
    {
        this.cam = Camera.main;

        this.initialLife = this.obj.bird.actLife;
        this.valueLife = this.obj.bird.actLife;    
    }

    void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(-this.cam.transform.forward);

        if (this.valueLife != this.obj.bird.actLife) {
            if (this.valueLife > this.obj.bird.actLife) {
                this.valueLife -= (this.transitionTime * Time.deltaTime);

                this.valueLife = Mathf.Clamp(this.valueLife, this.obj.bird.actLife, this.initialLife); 
            } else if (this.valueLife < this.obj.bird.actLife) {
                this.valueLife += (this.transitionTime * Time.deltaTime);

                this.valueLife = Mathf.Clamp(this.valueLife, this.valueLife, this.obj.bird.actLife); 
            }

            float fillAmount = this.valueLife * 100 / this.initialLife / 100;
            
            if(fillAmount <= 0) {
                this.bar.transform.localScale = new Vector3(0, 1, 1);
            } else {
                this.bar.transform.localScale = new Vector3(fillAmount, 1, 1);
            }
        }    
    }
}