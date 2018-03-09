using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "AllMatchRule", menuName = "Rule/AllMatch", order = 1)]
public class AllMatchRule : MatchRule {
    
    public override bool CanMatch(Fruit a, Fruit b)
    {
        return true;
    }

    public override IEnumerator Match(Fruit a, Fruit b)
    {
        a.Destroy();
        b.Destroy();
        yield break;
    }
}
