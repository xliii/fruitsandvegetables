using System;
using System.Collections.Generic;
using UnityEngine;

public class HintProvider
{
    private Board board;

    public HintProvider(Board board)
    {
        this.board = board;
    }

    public List<Fruit> getHint()
    {
        List<Fruit> list = new List<Fruit>();
        var start = DateTime.Now.Ticks;
        var total = The.Width * The.Height;
        for (int i = 0; i < total - 1; i++)
        {
            for (int j = i + 1; j < total; j++)
            {
                var from = board.Get(i);
                if (from == null) continue;
                var to = board.Get(j);
                if (to == null) continue;
                
                var match = The.MatchRule.CanMatch(from, to);
                if (match)
                {
                    LogSuccess(start);
                    list.Add(from);
                    list.Add(to);
                    return list;
                }
            }
        }
        
        LogFailure(start);
        return new List<Fruit>();               
    }

    private void LogSuccess(long start)
    {
        var elapsed = new TimeSpan(DateTime.Now.Ticks - start);
        Debug.LogFormat("Hint found in {0}ms", elapsed.Milliseconds);
    }
    
    private void LogFailure(long start)
    {
        var elapsed = new TimeSpan(DateTime.Now.Ticks - start);
        Debug.LogFormat("Hint not found in {0}ms", elapsed.Milliseconds);
    }
}
