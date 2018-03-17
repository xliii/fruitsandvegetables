using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TweenSelection", menuName = "Selection/Tween", order = 1)]
public class TweenSelection : Selection
{

    public float time;
    [MinMaxRange(0.3f, 1.5f)]
    public Vector2 scale;
    
    public override IEnumerator Select(Fruit fruit)
    {
        fruit.transform.localScale = Vector3.one * scale.y;
        var args = new Hashtable();
        args.Add("scale", Vector3.one * scale.x);
        args.Add("time", time);
        args.Add("easetype", iTween.EaseType.easeInOutSine);
        args.Add("looptype", iTween.LoopType.pingPong);        
        iTween.ScaleTo(fruit.gameObject, args);
        yield break;       
    }

    public override IEnumerator Deselect(Fruit fruit)
    {
        iTween.Stop(fruit.gameObject);
        fruit.transform.localScale = new Vector3(1f, 1f, 1f);
        yield break;
    }
}
