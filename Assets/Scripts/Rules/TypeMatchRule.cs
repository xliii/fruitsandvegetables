using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypeMatchRule", menuName = "Rule/TypeMatch", order = 1)]
public class TypeMatchRule : MatchRule {
    
    public override bool CanMatch(Fruit a, Fruit b)
    {
        return a.Type == b.Type;
    }

    public override IEnumerator Match(Fruit a, Fruit b)
    {
        a.Destroy();
        b.Destroy();
        yield break;
    }
}
