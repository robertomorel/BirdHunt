using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird
{

    public int life { get; set; }
    public int actLife { get; set; }
    public bool isRobot { get; set; }
    public int level { get; set; }
    public float speed { get; set; }

    public BirdController instance;

    public Bird() { }

    public Bird(bool isRobot, int level, float speed)
    {
        this.isRobot = isRobot;
        this.level = level;
        this.speed = speed;
    }

    public void Setup()
    {

        int life = this.life;

        switch (level)
        {
            case 1:
                life = 10;
                break;
            case 2:
                life = 20;
                break;
            case 3:
                life = 30;
                break;
            case 4:
                life = 50;
                break;
            case 5:
                life = 100;
                break;
            default:
                life = 10;
                break;
        }

        // -- Os birds normais sempre serão destruídos com apenas um tiro de qualquer arma
        if (!this.isRobot)
        {
            life = 10;
        }

        this.actLife = life;

    }

    public void Hit(int hitStrength)
    {
        Debug.Log("Bird foi atingido com força " + hitStrength + "!!!");
        this.actLife -= hitStrength;
        if (this.actLife < 0)
        {
            this.actLife = 0;
        }
    }

    public bool IsDead()
    {
        return (this.actLife == 0) ? true : false;
    }
}
