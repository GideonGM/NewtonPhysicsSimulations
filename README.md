# Newtonian Physics Simulator
#### Description:
  A unity project which includes three interactive visual simulations of Newtonian models. These include a thrown object, a single pendulum, and a double pendulum.

<img width="1170" alt="Screenshot 2024-10-11 at 2 09 19 PM" src="https://github.com/user-attachments/assets/fea68366-e4f4-4b3b-80d9-ef66e6079b2c">

#### Purpose:
  In 2023, I made this project while participating in an online program where I was able to be mentored by and worked with a graduate student in physics. The purpose of the project was to demonstrate my understanding of the mathematics, while  also improving my understanding of and ability to work in the Unity engine with C#.

#### How to use:
  A compiled version of the project for Mac is attached as an application called "PhysicsSim".

  The application itself is fairly rough, as the focus was on technical demonstration rather than user interface. There is a main scene from which the three simulations can be loaded, and subsequently returned to. In each simulation there are three buttons on the top left which, from left to right, start the simulation, pause the simulation, and reverse the simulation. On the left there is a display of the current values of the variables  used in calculating the simulation, as well one to three constants below. These constants can be edited any time, save for when the simulation is reversing, by clicking on the corresponding text box and typing in the desired float value. (These text boxes are currently a bit difficult to use, try clicking on the top right corner of the box for best effect.) On the bottom left is a button to return in the home scene. In the center of the screen in a fixed camera showing a basic 3d representation of the simulation. 

  It should be noted that there is some error in the pendulum simulations which make them gain a surplus of energy over a sufficient period of time, resulting in eventually highly inaccurate models. This is not surprising given my limited grasp of calculus at the time; I consider this project archived, and doubt that I will be going back to fix whatever mathematical or computational error causes this.
