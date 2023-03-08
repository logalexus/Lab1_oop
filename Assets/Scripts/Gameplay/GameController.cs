using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using GameObject = Models.GameObject;

public class GameController
{
    private readonly Map _map;

    public GameController(Map map)
    {
        _map = map;
    }

    public Coordinates GetObjectCoordinates(GameObject gameObject) => gameObject.Position;

    public bool CanMoveUnit(Unit unit, int x, int y)
    {
        Coordinates coordinates = new Coordinates(x, y);
        
        if (!unit.CanMoveInArea(x, y))
            return false;

        Surface surface = _map.Ground.FirstOrDefault(surface => surface.Position.Equals(coordinates));

        if (surface != null && surface is Water)
            return false;
        
        Unit otherUnit = _map.Units.FirstOrDefault(unit => unit.Position.Equals(coordinates));

        if (otherUnit != null)
            return false;

        return true;
    }

    public void MoveUnit(Unit unit, int x, int y)
    {
        if (!CanMoveUnit(unit, x, y))
            return;

        unit.Position.Set(x, y);
    }
    
    public void MoveUnit(Unit unit, Surface surface)
    {
        if (!CanMoveUnit(unit, surface.Position.X, surface.Position.Y))
            return;

        unit.Position.Set(surface.Position.X, surface.Position.Y);
    }

    public bool CanAttackUnit(Unit unit, Unit otherUnit) => unit.CanAttack(otherUnit);

    public void AttackUnit(Unit unit, Unit otherUnit) => unit.Attack(otherUnit);


}