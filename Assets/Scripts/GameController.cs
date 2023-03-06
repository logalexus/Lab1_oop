using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using GameObject = Models.GameObject;

/// <summary>
/// Контроллер хода игры.
/// </summary>
public class GameController
{
    private readonly Map _map;

    /// <inheritdoc />
    public GameController(Map map)
    {
        _map = map;
    }

    /// <summary>
    /// Получить координаты объекта.
    /// </summary>
    /// <param name="gameObject">Координаты объекта, которые необходимо получить.</param>
    /// <returns>Координата x, координата y.</returns>
    public Coordinates GetObjectCoordinates(GameObject gameObject) => gameObject.Position;

    /// <summary>
    /// Может ли юнит передвинуться в указанную клетку.
    /// </summary>
    /// <param name="unit">Юнит.</param>
    /// <param name="x">Координата X клетки.</param>
    /// <param name="y">Координата Y клетки.</param>
    /// <returns>
    /// <see langvalue="true" />, если юнит может переместиться
    /// <see langvalue="false" /> - иначе.
    /// </returns>
    public bool CanMoveUnit(Unit unit, int x, int y)
    {
        Coordinates coordinates = new Coordinates(x, y);
        
        if (!unit.CanMoveInArea(x, y))
            return false;

        Surface surface = _map.Ground.FirstOrDefault(surface => surface.Position.Equals(coordinates));

        if (surface != null && surface is Water && surface.Position == unit.Position)
            return false;
        
        Unit otherUnit = _map.Units.FirstOrDefault(unit => unit.Position.Equals(coordinates));

        if (otherUnit != null && otherUnit.Position == unit.Position)
            return false;

        return true;
    }

    /// <summary>
    /// Передвинуть юнита в указанную клетку.
    /// </summary>
    /// <param name="unit">Юнит.</param>
    /// <param name="x">Координата X клетки.</param>
    /// <param name="y">Координата Y клетки.</param>
    public void MoveUnit(Unit unit, int x, int y)
    {
        if (!CanMoveUnit(unit, x, y))
            return;

        unit.Position.Set(x, y);
    }

    /// <summary>
    /// Проверить, может ли один юнит атаковать другого.
    /// </summary>
    /// <param name="unit">Юнит, который собирается совершить атаку.</param>
    /// <param name="otherUnit">Юнит, который является целью.</param>
    /// <returns>
    /// <see langvalue="true" />, если атака возможна
    /// <see langvalue="false" /> - иначе.
    /// </returns>
    public bool CanAttackUnit(Unit unit, Unit otherUnit) => unit.CanAttack(otherUnit);


    /// <summary>
    /// Атаковать указанного юнита.
    /// </summary>
    /// <param name="unit">Юнит, который собирается совершить атаку.</param>
    /// <param name="otherUnit">Юнит, который является целью.</param>
    public void AttackUnit(Unit unit, Unit otherUnit) => unit.Attack(otherUnit);


}