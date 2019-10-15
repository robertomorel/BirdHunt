using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    public int id { get; set; }
    public int power { get; set; }
    public int bulletCount { get; set; }
    public int isActive { get; set; }
    public float fireRate { get; set; }
    public GunController instance { get; set; }

    public Gun() { }
}
