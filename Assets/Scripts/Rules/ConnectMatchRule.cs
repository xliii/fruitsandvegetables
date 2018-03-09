using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ConnectMatchRule", menuName = "Rule/ConnectMatch", order = 1)]
public class ConnectMatchRule : MatchRule
{
    [Range(1, 3)]
    public int maxTurns;

    public bool typeMatch;

    private readonly List<Vector2Int> EMPTY = new List<Vector2Int>();

    public override IEnumerator Match(Fruit a, Fruit b)
    {
        var path = GetPath(a.GetPosition(), b.GetPosition());
        if (path.Count == 0)
        {
            Debug.LogErrorFormat("Path {0} -> {1} not found", a, b);
            yield break;
        }
        
        //Debug.Log(string.Join(", ", Array.ConvertAll(path.ToArray(), pos => pos.ToString())));
        a.Deselect();
        b.Deselect();
        The.Line.Draw(path);
        yield return new WaitForSeconds(0.2f);
        a.Destroy();
        b.Destroy();
        The.Line.Clear();
    }

    public override bool CanMatch(Fruit a, Fruit b)
    {
        if (typeMatch && a.Type != b.Type) return false;

        return GetPath(a.GetPosition(), b.GetPosition()).Count > 0;
    }

    private List<Vector2Int> GetPath(Vector2Int from, Vector2Int to)
    {
        for (var i = 1; i <= maxTurns; i++)
        {
            var path = GetPath(from, to, i);
            if (path.Count > 0)
            {
                return path;
            }
        }

        return EMPTY;
    }

    private bool HasPath(Vector2Int from, Vector2Int to, int turns)
    {
        return GetPath(from, to, turns).Count > 0;
    }

    private List<Vector2Int> GetPath(Vector2Int from, Vector2Int to, int turns)
    {
        switch (turns)
        {
            case 1: return GetPath1(from, to);
            case 2: return GetPath2(from, to);
            case 3: return GetPath3(from, to);
            default: throw new Exception(string.Format("Cannot calculate path for {0} turns", turns));
        }
    }

    public bool hasLOS(Vector2Int from, Vector2Int to)
    {
        if (from.x == to.x)
        {
            if (from.y > to.y)
            {
                Swap(ref from, ref to);
            }

            for (var y = from.y + 1; y < to.y; y++)
            {
                if (The.Board.Get(from.x, y) != null) return false;
            }
        } else if (from.y == to.y)
        {
            if (from.x > to.x)
            {
                Swap(ref from, ref to);
            }

            for (var x = from.x + 1; x < to.x; x++)
            {
                if (!Empty(x, from.y))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private List<Vector2Int> GetPath1(Vector2Int from, Vector2Int to)
    {                
        if (!HV(from, to))
        {
            //Diagonal
            return EMPTY;
        }

        if (!hasLOS(from, to))
        {
            return EMPTY;
        }        

        return CreatePath(from, to);
    }

    private List<Vector2Int> GetPath2(Vector2Int from, Vector2Int to)
    {
        //a.x - b.y
        var a = new Vector2Int(from.x, to.y);
        if (Empty(a) && HasPath(from, a, 1) && HasPath(a, to, 1))
        {
            return CreatePath(from, a, to);
        }
        
        //b.x - a.y
        var b = new Vector2Int(to.x, from.y);
        if (Empty(b) && HasPath(from, b, 1) && HasPath(b, to, 1))
        {
            return CreatePath(from, b, to);
        }

        return EMPTY;
    }
    
    private List<Vector2Int> GetPath3(Vector2Int from, Vector2Int to)
    {
        var pos = from.Left();
        while (Empty(pos))
        {
            var path = GetPath2(pos, to);
            if (path.Count > 0)
            {
                path.Insert(0, from);
                return path;
            }
            pos = pos.Left();
            if (The.Board.OutOfBounds(pos)) break;
        }       

        pos = from.Right();
        while (Empty(pos))
        {
            var path = GetPath2(pos, to);
            if (path.Count > 0)
            {
                path.Insert(0, from);
                return path;
            }
            pos = pos.Right();
            if (The.Board.OutOfBounds(pos)) break;
        }
        
        pos = from.Up();
        while (Empty(pos))
        {
            var path = GetPath2(pos, to);
            if (path.Count > 0)
            {
                path.Insert(0, from);
                return path;
            }
            pos = pos.Up();
            if (The.Board.OutOfBounds(pos)) break;
        }
        
        pos = from.Down();
        while (Empty(pos))
        {
            var path = GetPath2(pos, to);
            if (path.Count > 0)
            {
                path.Insert(0, from);
                return path;
            }
            pos = pos.Down();
            if (The.Board.OutOfBounds(pos)) break;
        }
        
        return EMPTY;
    }

    private bool Empty(int x, int y)
    {
        return The.Board.Get(x, y) == null;
    }

    private bool Empty(Vector2Int pos)
    {
        return Empty(pos.x, pos.y);
    }

    private List<Vector2Int> CreatePath(params Vector2Int[] nodes)
    {
        return nodes.ToList();
    }
    
    //Horizontal or Vertical alignment
    private bool HV(Vector2Int a, Vector2Int b)
    {
        return a.x == b.x || a.y == b.y;
    }

    private void Swap(ref Vector2Int a, ref Vector2Int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
