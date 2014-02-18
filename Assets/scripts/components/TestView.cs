using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace strange.examples.signals
{
    /**
     * The only components with code attached to the GameObject should be a view like this (possibly with an associated mediator).
     */
    public class TestView : View
    {
        [Inject]
        public EntitiesChangedSignal entitiesChangedSignal { get; set; }

        void OnMouseDown()
        {
            Debug.Log("clicking the text");

            //put the new entity in the world
            GameObject prefabToMake = (GameObject)Resources.Load("textField");
            GameObject newEntity = (GameObject)GameObject.Instantiate(prefabToMake, this.transform.position - 2*(Vector3.up), Quaternion.identity);
            newEntity.transform.parent = GameObject.Find("Entities").transform;

            entitiesChangedSignal.Dispatch();
        }
    }
}
