This is a sample project that uses StrangeIoC to make a framework closer to the CES (Component-Entity-System) ideal.

It is based off StrangeIoC's Signals example, stripping down some unnecessary parts (for this illustration) and adds a "systems" script folder, which implements EntitySystems. EntitySystems (ES) are instantiated and connected to the outside world via SystemManager[View, Mediator]. They contain a list of entities (GameObjects that are children of the "Entities" GameObject) that contain all components they act upon. 

In this framework, most user-made components should contain NO logic, only data. The exception is that every object can have a View/Mediator attached to it that senses when the object is clicked, collides, etc, which will send a signal to notify the rest of the application of this event.

This is a very quick implementation, mostly serving as a proof-of-concept, and could use a lot of work. However, if you think you would benefit from it, feel free to download/clone and use any part of it!
