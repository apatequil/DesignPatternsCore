# Design Patterns Core - Factories
## What is a Factory?

Factories in the context of design patterns closely reflect their real life counterparts: hence the name. A factory
is functional code which is responsible for *creating* objects <u>which might not be known ahead of time</u>. This places
factories in the Creational family of Design Patterns.

The main benefit of the factory pattern is that is can create easily extensible and elegant code capable of
very complex output. The concept is implemented in nearly all software ranging from office applications to
video games. Many software toolkits employ the pattern for scaffolded items such as Visual Studio's ability
to easily add pre-build objects to the solution (e.g. add new controller).

## Types of Factories
There are arguably 2 distinct types of factories in this group. The Factory Method pattern and the Abstract Factory
pattern. Below briefly explains each one, when to use them, as well as when to choose one over the other.

### Factory Method

The Factory Method pattern is useful when you need a common interface for creating objects but want to defer
instantiation to sub-classes.

Define an interface for creating an object, but let subclasses decide which class to instantiate.
 Factory Method lets a class defer instantiation to subclasses

![Introduction](FactoryMethod.png "")
Factory Method Diagram


### Abstract Factory

Factory of factories



