using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace strange.examples.signals
{
    public class SystemManagerMediator : Mediator
    {
        //reference to the view this is mediating
        [Inject]
        public SystemManagerView view { get; set; }

        //Injecting this one because we want to listen for it
        [Inject]
        public EntitiesChangedSignal entitiesChangedSignal { get; set; }

        public override void OnRegister()
        {
            //Listen out for this Signal to fire
            entitiesChangedSignal.AddListener(onEntitiesChanged);

            view.init();
        }

        //Clean up signal listeners.
        public override void OnRemove()
        {
            entitiesChangedSignal.RemoveListener(onEntitiesChanged);
            Debug.Log("Mediator OnRemove");
        }

        //Called whenever a EntityChangedSignal is fired, gets the view to update the entity list
        private void onEntitiesChanged()
        {
            view.onEntitiesChanged();
        }
    }
}
