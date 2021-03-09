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
There are arguably 4 distinct types of factories in this group of patterns.

### Factory Method

The Factory Method pattern is useful when you need a common interface for creating objects but want to defer
instantiation to sub-classes.

Define an interface for creating an object, but let subclasses decide which class to instantiate.
 Factory Method lets a class defer instantiation to subclasses

<figure>
  <img
  src="FactoryMethod.png"
  alt="Factory Method Diagram">
  <figcaption>Factory Method Diagram</figcaption>
</figure>

### Abstract Factory

Factory of factories

### Static Factory

static class hosting factory methods

### Factory (Simple)

Just about any other kind of implementation can be considered a basic or simple factory. Since this is a catch-all
category there could be many interpretations, most of which likely don't conform to an actual factory pattern above.



The main application method is doing everything including prompting the user, processing their input, and replying with the necessary information.
- Extract user interface code to it's own method
- Extract input handling to it's own method
- Create meal abstractions to reduce code duplication and create the start of an organized codebase  
  - Option A: Interface
  - Option B: Abstract Class       
  - **Which would you choose?**

## Step 2: Refactor to Ensure Easier Conversion to Factory

### Extract User Interface code

![Lesson1.UIRefactor](UIRefactor.png "")

### Extract Input Handling

![Input Handling](InputHandling.png)

### Abstraction

![Refactor Abstraction](RefactorAbstraction.png)

## Step 3: Create Factory