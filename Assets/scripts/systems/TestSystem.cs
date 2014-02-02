using System;
using UnityEngine;
using System.Collections.Generic;

namespace strange.examples.signals
{
    class TestSystem : SingleEntitySystem
    {
        public TestSystem()
        {
            components = new List<Type> { typeof(TestComponent) };
            updateEntityList();
        }

        public override void update(float deltaTime, GameObject entity)
        {
            entity.transform.Rotate(Vector3.up * Time.deltaTime * 20f, Space.Self);
        }
    }
}
