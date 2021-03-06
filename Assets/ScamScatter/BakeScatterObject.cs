﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

#if (UNITY_EDITOR)

namespace ScamScatter
{
    public class BakeScatterObject : ScriptableWizard
    {
        public GameObject objectToBakeSplit;
        public int targetPartCount = 50;
        public float TargetArea = 0.4f;
        public float NewThicknessMin = 0.3f;
        public float NewThicknessMax = 0.35f;

        [MenuItem("Procedural/BakeScamScatterObject")]
        static void CreateWizard()
        {
            DisplayWizard<BakeScatterObject>("Bake ScamScatter object");
        }

        public void OnWizardCreate()
        {
            var newObject = new GameObject {name = "BakedScamScatter_" + objectToBakeSplit.name};
            ScamScatter.Scatter.Run(
                new ScatterCommands
                {
                    new ScatterCommand(objectToBakeSplit, newObject.transform)
                    {
                        Destroy = false,
                        TargetPartCount = targetPartCount,
                        TargetArea = TargetArea,
                        NewThicknessMin = NewThicknessMin,
                        NewThicknessMax = NewThicknessMax
                    }
                });
        }

    }

}

#endif
