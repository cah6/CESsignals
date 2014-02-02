using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;

namespace strange.examples.signals
{
    /**
     * View in charge of keeping track of all entity systems and updating them every frame.
     */
    public class SystemManagerView : View
    {
        //lists of systems we need to update every frame
        public List<IEntitySystem> entitySystems = new List<IEntitySystem>();

        //Injecting this signal because we want to listen for it
        [Inject]
        public EntitiesChangedSignal entitiesChangedSignal { get; set; }

        /*
         * Called once mediator and view are established, add all systems in the scene here!
         */
        internal void init()
        {
            entitySystems.Add(new TestSystem());
        }

        //Every frame, call each entity system to do its update.
        void Update()
        {
            foreach (IEntitySystem es in entitySystems)
            {
                es.update(Time.deltaTime);
            }
        }

        //Go through all entity systems and update the list of entities they act on.
        public void onEntitiesChanged()
        {
            foreach (IEntitySystem es in entitySystems)
            {
                es.updateEntityList();
            }
        }
    }
}