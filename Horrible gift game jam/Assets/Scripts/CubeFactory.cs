﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class CubeFactory : MonoBehaviour
{
    public GameObject cubeOne;
    public GameObject cubeTwo;
    public GameObject cubeThree;
    public GameObject cubeFour;
    public GameObject cubeFive;
    public GameObject cubeSix;

    public static GameObject CubeOne;
    public static GameObject CubeTwo;
    public static GameObject CubeThree;
    public static GameObject CubeFour;
    public static GameObject CubeFive;
    public static GameObject CubeSix;

    public static Dictionary<int, Type> factoryDict;
    private static ObjectPool myPool;

    // Start is called before the first frame update
    void Start()
    {
        //assign cube type to static cube
        CubeOne = cubeOne;
        CubeTwo = cubeTwo;
        CubeThree = cubeThree;
        CubeFour = cubeFour;
        CubeFive = cubeFive;
        CubeSix = cubeSix;

        //initialize cube maker
        var factoryTypes = Assembly.GetAssembly(typeof(CubeMaker)).GetTypes().
            Where(myType => myType.IsClass && !myType.IsAbstract && myType.
            IsSubclassOf(typeof(CubeMaker)));

        factoryDict = new Dictionary<int, Type>();
        myPool = ObjectPool.Instance;

        foreach(var type in factoryTypes)
        {
            var tempCube = Activator.CreateInstance(type) as CubeMaker;
            factoryDict.Add(tempCube.Name, type);
        }
    }

    //use cube maker to make certain type cube at certain position with certain rotation
    public static CubeMaker MakeCube(int cubeType, Vector3 possition, Quaternion rotation)
    {
        if(factoryDict.ContainsKey(cubeType))
        {
            Type type = factoryDict[cubeType];
            var cube = Activator.CreateInstance(type) as CubeMaker;
            cube.SpawnCube(possition, rotation);
            return cube;
        }
        return null;
    }

    //Cube maker contain a function could spawn cube
    public abstract class CubeMaker
    {
        public abstract int Name { get; }
        public abstract void SpawnCube(Vector3 pos, Quaternion rot);
    }

    public class MakeCubeOne:CubeMaker
    {
        public override int Name => 1;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
          //  myPool.SpawnObject("Present 1", pos, rot);
        }
    }

    public class MakeCubeTwo : CubeMaker
    {
        public override int Name => 2;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Present 2", pos, rot);
        }
    }

    public class MakeCubeThree : CubeMaker
    {
        public override int Name => 3;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Present 3", pos, rot);
        }
    }

    public class MakeCubeFour : CubeMaker
    {
        public override int Name => 4;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Present 4", pos, rot);
        }
    }

    public class MakeCubeFive : CubeMaker
    {
        public override int Name => 5;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Present 5", pos, rot);
        }
    }
     public class MakeCubeSix : CubeMaker
    {
        public override int Name => 6;
        public override void SpawnCube(Vector3 pos, Quaternion rot)
        {
            myPool.SpawnObject("Present 6", pos, rot);
        }
    }


}