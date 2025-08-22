# Lab-10-Polymorphic-Drawing-Factory



Lab 10 - Design Patterns Drawing App
General Learning Objectives

Use a modern operating system and utilities.

Use an integrated development environment to develop a program.

Solve problems and develop programs using the control structures of sequence, selection, and repetition, following a disciplined approach.

Objectives
Consider some design challenges and the idea of "design patterns" to help solve them.
Practice polymorphism.
Step 1: Setup Basic Environment and Copy Code From Previous Drawing Lab
Accept the GitHub Classroom Assignment.
Clone the associated repo.
Copy and add your working code from the Polymorphic Drawing lab into your new repo folder.
Step 2: Read and Understand This Overview

In this lab you will start with your working Polymorphic Drawing code from an earlier lab and turn it into a program that will let users select elements from a list of options in order to interactively build a drawing. Our main focus in this lab will be to use a couple of design patterns so that developers can easily support additional shape types without needing to increase the complexity of the driver program.

Each shape type from the previous lab implements the Display() method which is responsible for using the specific member variables of that shape to display the instance on the screen. This allowed us to represent a drawing as a collection of generic shape objects without needing to keep track of what information those shapes contained or how they would be displayed. Regardless of the specific shape type, polymorphism allowed the abstract call to Display() on each instance to appropriately invoke the correct specialized drawing method.

However, invoking the constructor still depends on the specific type, and the required information for that type. For example, the Circle constructor requires a center and radius while the Rectangle constructor requires a top, left, height, and width. How can we allow the user to create a variety of shape types in a maintainable, extensible way that doesn't become cluttered and error-prone?

The Factory Method Pattern

How can we separate the code that builds the object (i.e. the main driver) from the creation logic? One solution is known as the factory method pattern.

The idea is to define an interface that includes a factory method that doesn't require type-specific parameters and yet can create the desired instance. In our case, our factory method will be responsible for asking the user for any required information as well as calling the appropriate constructor with that information.

Step 3: Create the Factory Interface
Create a new interface called IGraphic2DFactory with the following members:
A readonly, string-valued property Name which should be a string describing what type of graphic will be built (e.g. "Circle"). This will be displayed to the user in a menu so that they can select the type of shape they want to build.
A method Create() that requires no parameters and returns an object of type IGraphic2D. For example, for the CircleFactory this method would ask the user for the x-value of the center, the y-value of the center, and the radius of the circle. (Optionally, you could ask for the foreground and background colors).
Step 4: Implement Main
The main driver should start with a greeting to the user describing that the drawing program will iteratively allow the user to either draw or modify and existing drawing.
There should be the following local variables:
List<IGraphic2DFactory> availableShapeTypes which should be initialized with a list of instances of the available factories. (For now, that list should be empty since we haven't made any concrete factory types yet!)
List<IGraphic2D> builtShapes which should be initialized to an empty list representing a blank drawing.
The main menu should display the following options with associated numbers and allow the user to select by entering the corresponding number:
Display drawing should clear the screen, use AbstractGraphic2D.Display(List<IGraphic2D>) to render the current drawing, and then wait for the user to press enter (Console.ReadLine() is fine).
Add graphic should loop over the factories in availableShapeTypes and display the index and the Name, allow the user to enter an index, call the Create() method on the selected factory, and then add the resulting graphic to the builtShapes list.
Remove graphic should display the number of graphic objects in the current drawing, allow the user specify an index to remove, and then remove that graphic object from the builtShapes list.
Exit exit the program.
Step 5: Implement the concrete factories
Create classes RectangleFactory and CircleFactory that each implement the IGraphic2DFactory interface as described above.
Make sure that your main driver works properly.
Step 6: Optional enhancements to functionality and design

Consider how you would implement the following:

Extend your drawing app to support 10 additional shape types. How many files would you have change?
Allow the user to specify foreground and background colors for AbstractGraphic2D shapes without duplicating that code for each concrete subclass.
Enforce that there can only be one instance of each of the Factory classes. Anyone thinking the Singleton pattern here? ;-)
Add the option to edit an object's properties (again, not requiring the main-driver to know details about individual shape types).
Add the option to reorder the graphic components of the current drawing.
Add the option to display the list of available shape types in a variety of orders. For example, sort by name; sort by category; sort by complexity; sort by frequency of use, etc.
Create a Blazor-based version of the project.
Grading

Make sure the final version of your code is all added, committed, and pushed to github.

You may work in groups of two or three to complete this project, however, each individual will need to submit a repository.  Each individual should include comments in their code indicating which portions of the code they contributed to the final project. 

Grading must be done in person or via Teams with a TA or instructor.

Getting a TA or instructor to sign-off on your lab before you leave is the easiest and best way to get the best grade possible.

 
