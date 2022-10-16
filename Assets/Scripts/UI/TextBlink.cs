using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TextBlink : MonoBehaviour
{
   Text _lbl; 
   public float BlinkFadeInTime = 0.5f; 
   public float BlickStayTime = 0.8f; 
   public float BlinkFadeOutTime = 0; 
   private float _timeChecker = 0; 
   private Color _color; 

    void Start()
    {
        _lbl = GetComponent<Text>();
        _color = _lbl.color; 
    }

    // Update is called once per frame
    void Update()
    {
        _timeChecker += Time.deltaTime; 
        if(_timeChecker < BlinkFadeInTime)
        {
            _lbl.color = new Color(_color.r, _color.g, _color.b, _timeChecker/BlinkFadeInTime);
        }
        else if (_timeChecker< BlinkFadeInTime +BlickStayTime)
        {
            _lbl.color = new Color (_color.r, _color.g, _color.b, 1);
        }
        else if (_timeChecker < BlinkFadeInTime +BlickStayTime +BlinkFadeOutTime)
        {
            _lbl.color = new Color(_color.r, _color.g, _color.b, 1-(_timeChecker - (BlinkFadeInTime+BlickStayTime))/BlinkFadeOutTime);
        }
        else
        {
            _timeChecker = 0; 
        }
    }
}
