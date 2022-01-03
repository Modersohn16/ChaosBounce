using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {

    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private SpawnHelper helper;
    [SerializeField]
    private MainController main;

    #region Rounds

    /*
    level 1 - 50
    Spawn Brick (42% chance)
    Spawn Rhombus (14% chance)
    Spawn Pyramid (29% chance)
    Spawn Fire / Downer / Shrinker (15% chance)
    */
    public void Round1to50(Vector3 pos)
    {
        var outcome = Random.Range(1, 8);

        if (outcome == 1 || outcome == 2 || outcome == 3)
            helper.SpawnBrick(pos);

        if (outcome == 4)
            helper.SpawnRhombus(pos);

        if (outcome == 5 || outcome == 6)
            helper.SpawnPyramid(pos);

        if (outcome == 7)
        {
            var outcome2 = Random.Range(1, 4);

            if (outcome == 1)
                helper.SpawnShrinker(pos);

            if (outcome == 2)
                helper.SpawnDowner(pos);

            if (outcome == 3)
                helper.SpawnFire(pos);
        }
    }

    /*
    level 51 - 100
    Spawn Brick (25% chance)
    Spawn Rhombus (25% chance)
    Spawn RotPyramid (12,5% chance)
    Spawn Hex (12,5% chance)
    Spawn LineKiller / Grower / Shrinker (12,5% chance)
    */
    public void Round51to100(Vector3 pos)
    {
        var outcome = Random.Range(1, 9);

        if (outcome == 1 || outcome == 2)
            helper.SpawnBrick(pos);

        if (outcome == 3 || outcome == 4)
            helper.SpawnRhombus(pos);

        if (outcome == 5)
            helper.SpawnRotPyramid(pos);

        if (outcome == 6)
            helper.SpawnHex(pos);

        if (outcome == 7)
            helper.SpawnMiniWall(pos);

        if (outcome == 8)
        {
            var outcome2 = Random.Range(1, 4);

            if (outcome2 == 1)
                helper.SpawnLineKiller(pos);

            if (outcome2 == 2)
                helper.SpawnGrower(pos);

            if (outcome2 == 3)
                helper.SpawnShrinker(pos);
        }
    }

    /*
    level 101 - 150
    Spawn Ball 
    Spawn Rhombus 
    Spawn RotPyramid 
    Spawn Hex
    Spawn Doubler / Downer / MiniWall
    Spawn Fire / Slowy / Rotator / TripleShot / HandGrenade
    */
    public void Round101to150(Vector3 pos)
    {
        var outcome = Random.Range(1, 6);

        //Enemies
        if (outcome == 1 || outcome == 2 || outcome == 3)
        {
            var outcomeEnemy = Random.Range(1, 5);

            if (outcomeEnemy == 1)
                helper.SpawnBall(pos);

            if (outcomeEnemy == 2)
                helper.SpawnRhombus(pos);

            if (outcomeEnemy == 3)
                helper.SpawnHex(pos);

            if (outcomeEnemy == 4)
                helper.SpawnRotPyramid(pos);
        }
        //Debris
        if (outcome == 4)
        {
            var outcomeDebris = Random.Range(1, 4);

            if (outcomeDebris == 1)
                helper.SpawnDoubler(pos);

            if (outcomeDebris == 2)
                helper.SpawnDowner(pos);

            if (outcomeDebris == 3)
                helper.SpawnMiniWall(pos);
        }
        //power/random
        if (outcome == 5)
        {
            var outcomePowers = Random.Range(1, 6);

            if (outcomePowers == 1)
                helper.SpawnFire(pos);

            if (outcomePowers == 2)
                helper.SpawnSlowy(pos);

            if (outcomePowers == 3)
                helper.SpawnRotator(pos);

            if (outcomePowers == 4)
                helper.SpawnTripleShot(pos);

            if (outcomePowers == 5)
                helper.SpawnHandGrenade(pos);
        }
    }

    /*
    level 101 - 150
    Spawn Joker (new)
    Spawn Rhombus 
    Spawn RotPyramid 
    Spawn Hex
    Spawn DownPyramid
    Spawn Pentagram
    Spawn Pyramid
    Spawn Doubler / Downer / MiniWall / BlackOut (new)
    Spawn MapKiller (new) / FlippyFloop (new) / Rotator / TripleShot / BigGrenade (new) / Electricity (new)
    */
    public void Round151to200(Vector3 pos)
    {
        var outcome = Random.Range(1, 6);

        //Enemies
        if (outcome == 1 || outcome == 2 || outcome == 3)
        {
            var outcomeEnemy = Random.Range(1, 7);

            if (outcomeEnemy == 1)
                helper.SpawnJoker(pos);

            if (outcomeEnemy == 2)
                helper.SpawnRhombus(pos);

            if (outcomeEnemy == 3)
                helper.SpawnHex(pos);

            if (outcomeEnemy == 4)
                helper.SpawnRotPyramid(pos);

            if (outcomeEnemy == 5)
            {
                var outcome2 = Random.Range(1, 6);

                if (outcome2 == 1 || outcome2 == 2 || outcome2 == 3 || outcome2 == 4)
                    helper.SpawnDownPyramid(pos);

                if(outcome2 == 5)
                    helper.SpawnPentagram(pos);
            }

            if (outcomeEnemy == 6)
                helper.SpawnPyramid(pos);
        }
        //Debris
        if (outcome == 4)
        {
            var outcomeDebris = Random.Range(1, 5);

            if (outcomeDebris == 1)
                helper.SpawnDoubler(pos);

            if (outcomeDebris == 2)
                helper.SpawnDowner(pos);

            if (outcomeDebris == 3)
                helper.SpawnMiniWall(pos);

            if (outcomeDebris == 4 && !main.BlackOUT)
                helper.SpawnBlackOut(pos);
        }
        //power/random
        if (outcome == 5)
        {
            var outcomePowers = Random.Range(1, 7);

            if (outcomePowers == 1)
                helper.SpawnTripleShot(pos);

            if (outcomePowers == 2)
                helper.SpawnMapKiller(pos);

            if (outcomePowers == 3)
                helper.SpawnFlippyFloop(pos);

            if (outcomePowers == 4)
                helper.SpawnRotator(pos);

            if (outcomePowers == 5)
                helper.SpawnElectricity(pos);

            if (outcomePowers == 6)
                helper.SpawnBigGrenade(pos);
        }
    }

    /*
    level 201 - 250
    Spawn Ball 
    Spawn Rhombus 
    Spawn RotPyramid 
    Spawn Hex
    Spawn GrowingBrick (new)
    Spawn Pyramid
    Spawn Doubler / GrowingDowner / MiniWall / Ooze (new)
    Spawn Slowy / Plasma (new) / Shrinker / Rotator / Grower / Electricity
    */
    public void Round201to250(Vector3 pos)
    {
        var outcome = Random.Range(1, 6);

        //Enemies
        if (outcome == 1 || outcome == 2 || outcome == 3)
        {
            var outcomeEnemy = Random.Range(1, 7);

            if (outcomeEnemy == 1)
                helper.SpawnBall(pos);

            if (outcomeEnemy == 2)
                helper.SpawnRhombus(pos);

            if (outcomeEnemy == 3)
                helper.SpawnHex(pos);

            if (outcomeEnemy == 4)
                helper.SpawnRotPyramid(pos);

            if (outcomeEnemy == 5)
                helper.SpawnGrowingBrick(pos);

            if (outcomeEnemy == 6)
                helper.SpawnPyramid(pos);
        }
        //Debris
        if (outcome == 4)
        {
            var outcomeDebris = Random.Range(1, 5);

            if (outcomeDebris == 1)
                helper.SpawnDoubler(pos);

            if (outcomeDebris == 2)
                helper.SpawnGrowingDowner(pos);

            if (outcomeDebris == 3)
                helper.SpawnMiniWall(pos);

            if (outcomeDebris == 4)
                helper.SpawnOoze(pos);
        }
        //power/random
        if (outcome == 5)
        {
            var outcomePowers = Random.Range(1, 7);

            if (outcomePowers == 1)
                helper.SpawnSlowy(pos);

            if (outcomePowers == 2)
                helper.SpawnPlasma(pos);

            if (outcomePowers == 3)
                helper.SpawnShrinker(pos);

            if (outcomePowers == 4)
                helper.SpawnRotator(pos);

            if (outcomePowers == 5)
                helper.SpawnGrower(pos);

            if (outcomePowers == 6)
                helper.SpawnElectricity(pos);
        }
    }

    public void Round251to300(Vector3 pos)
    {
        var outcome = Random.Range(1, 6);

        //Enemies
        if (outcome == 1 || outcome == 2 || outcome == 3)
        {
            var outcomeEnemy = Random.Range(1, 9);

            if (outcomeEnemy == 1)
                helper.SpawnBall(pos);

            if (outcomeEnemy == 2)
                helper.SpawnRhombus(pos);

            if (outcomeEnemy == 3)
                helper.SpawnHex(pos);

            if (outcomeEnemy == 4)
                helper.SpawnGrowingBrick(pos);

            if (outcomeEnemy == 5)
                helper.SpawnPentagram(pos);

            if (outcomeEnemy == 6)
                helper.SpawnRotPyramid(pos);

            if (outcomeEnemy == 7)
                helper.SpawnDownPyramid(pos);

            if (outcomeEnemy == 8)
                helper.SpawnJoker(pos);
        }
        //Debris
        if (outcome == 4)
        {
            var outcomeDebris = Random.Range(1, 7);

            if (outcomeDebris == 1)
                helper.SpawnTenfolder(pos);

            if (outcomeDebris == 2)
                helper.SpawnDowner(pos);

            if (outcomeDebris == 3)
                helper.SpawnMiniWall(pos);

            if (outcomeDebris == 4 && !main.BlackOUT)
                helper.SpawnBlackOut(pos);

            if (outcomeDebris == 5)
                helper.SpawnOoze(pos);

            if (outcomeDebris == 6)
                helper.SpawnRotMiniWall(pos);
        }
        //power/random
        if (outcome == 5)
        {
            var outcomePowers = Random.Range(1, 7);

            if (outcomePowers == 1)
                helper.SpawnPlasma(pos);

            if (outcomePowers == 2)
                helper.SpawnLineKiller(pos);

            if (outcomePowers == 3)
                helper.SpawnFlippyFloop(pos);

            if (outcomePowers == 4)
                helper.SpawnRotatorPlus(pos);

            if (outcomePowers == 5)
                helper.SpawnGrower(pos);

            if (outcomePowers == 6)
                helper.SpawnSlowy(pos);
        }
    }

    public void RoundInfinity(Vector3 pos)
    {
        var outcome = Random.Range(1, 6);

        //Enemies
        if (outcome == 1 || outcome == 2 || outcome == 3)
        {
            var outcomeEnemy = Random.Range(1, 11);

            if (outcomeEnemy == 1)
                helper.SpawnBall(pos);

            if (outcomeEnemy == 2)
                helper.SpawnRhombus(pos);

            if (outcomeEnemy == 3)
                helper.SpawnHex(pos);

            if (outcomeEnemy == 4)
                helper.SpawnGrowingBrick(pos);

            if (outcomeEnemy == 5)
                helper.SpawnPentagram(pos);

            if (outcomeEnemy == 6)
                helper.SpawnRotPyramid(pos);

            if (outcomeEnemy == 7)
                helper.SpawnDownPyramid(pos);

            if (outcomeEnemy == 8)
                helper.SpawnBrick(pos);

            if (outcomeEnemy == 9)
                helper.SpawnPyramid(pos);

            if (outcomeEnemy == 10)
                helper.SpawnJoker(pos);
        }
        //Debris
        if (outcome == 4)
        {
            var outcomeDebris = Random.Range(1, 9);

            if (outcomeDebris == 1)
                helper.SpawnDoubler(pos);

            if (outcomeDebris == 2)
                helper.SpawnDowner(pos);

            if (outcomeDebris == 3)
                helper.SpawnMiniWall(pos);

            if (outcomeDebris == 4 && !main.BlackOUT)
                helper.SpawnBlackOut(pos);

            if (outcomeDebris == 5)
                helper.SpawnOoze(pos);

            if (outcomeDebris == 6)
                helper.SpawnGrowingDowner(pos);

            if (outcomeDebris == 7)
                helper.SpawnTenfolder(pos);

            if (outcomeDebris == 7)
                helper.SpawnRotMiniWall(pos);
        }
        //power/random
        if (outcome == 5)
        {
            var outcomePowers = Random.Range(1, 11);

            if (outcomePowers == 1)
                helper.SpawnLineKiller(pos);

            if (outcomePowers == 2)
                helper.SpawnGrower(pos);

            if (outcomePowers == 3)
                helper.SpawnSlowy(pos);

            if (outcomePowers == 5)
                helper.SpawnShrinker(pos);

            if (outcomePowers == 6)
                helper.SpawnFire(pos);

            if (outcomePowers == 7)
                helper.SpawnRotator(pos);

            if (outcomePowers == 8)
                helper.SpawnHandGrenade(pos);

            if (outcomePowers == 9)
                helper.SpawnBigGrenade(pos);

            if (outcomePowers == 10)
            {
                var outcome2 = Random.Range(1, 7);

                if (outcome2 == 1)
                    helper.SpawnPlasma(pos);

                if (outcome2 == 2)
                    helper.SpawnTripleShot(pos);

                if (outcome2 == 3)
                    helper.SpawnMapKiller(pos);

                if (outcome2 == 4)
                    helper.SpawnRotatorPlus(pos);

                if (outcome2 == 5)
                    helper.SpawnFlippyFloop(pos);

                if (outcome2 == 6)
                    helper.SpawnElectricity(pos);
            }
        }
    }

    #endregion
}