using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health_Bar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealth(int health)
    {
        slider.maxValue= health;
        slider.value= health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
