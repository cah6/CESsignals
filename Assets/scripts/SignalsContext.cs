/// If you're new to Strange, start with MyFirstProject.
/// If you're interested in how Signals work, return here once you understand the
/// rest of Strange. This example shows how Signals differ from the default
/// EventDispatcher.
/// All comments from MyFirstProjectContext have been removed and replaced by comments focusing
/// on the differences 

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace strange.examples.signals
{
	public class SignalsContext : MVCSContext
	{

		public SignalsContext (MonoBehaviour view) : base(view)
		{
		}

		public SignalsContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
		{
		}
		
		// Unbind the default EventCommandBinder and rebind the SignalCommandBinder
		protected override void addCoreComponents()
		{
			base.addCoreComponents();
			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}
		
		// Override Start so that we can fire the StartSignal 
		override public IContext Start()
		{
			base.Start();
			StartSignal startSignal= (StartSignal)injectionBinder.GetInstance<StartSignal>();
			startSignal.Dispatch();
			return this;
		}
		
		protected override void mapBindings()
		{
            //we'll interact with entity systems through this manager and its mediator
            mediationBinder.Bind<SystemManagerView>().To<SystemManagerMediator>();
			
            //signal that will fire once everything is set up
			commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();

            //signal to fire when our entity list is updated
            injectionBinder.Bind<EntitiesChangedSignal>().ToSingleton();
		}
	}
}

