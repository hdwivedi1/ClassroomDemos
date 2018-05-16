using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver
{
    //classes by default have a access privilege of private
    //you MUST add public to your classes

    
    public class Die
    {
        //create a new instance of the math object Random
        //this will be shared by each instance of Die
        //the instance of Random object will be created when
        //the first instance of Die is created
        private static Random _rnd = new Random();

        //class have 
        //  a) data members
        //  b) properties
        //  c) constructors
        //  d)behaviours (methods)

        //data members may be private for the class for use only
        //     within the class

        //the interface with a class is done via properties and behaviours

        //properties
        //can be fully implemented
        //   -a private data member
        //   -a public property
        private int _Sides;
        public int Sides
        {
            get
            {
                //this will return the private data memeber
                return _Sides;
            }
            private set
            {
                //the reseverd key word "value" is used to
                // obtain the incoming data value to the property
                //save the incoming data value to your private 
                //  data member
                _Sides = value;
            }
        }

        //can be auto implemented
        //  does not have a private data member
        //  the system creates an internal data storage member
        //      for the property
        //for the outside user, this property is now readonly
        //methods and code WITHIN the class still have access to set{}
        public int FaceValue { get; private set; }

        //within a property you can validate that
        //the incoming data value is "what is expected"
        private string _Color;
        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                //sample validation
                //there MUST be data within the incoming value
                // so an empty string is invalid
                if(string.IsNullOrEmpty(value))
                {
                    //incoming data value is incorrect
                    // a) you could send a error message to the outside user
                    //throw new Exception("Color must have a value");

                    //  OR
                    // b) you could allow the storage of a null value
                    //    within the string data member
                    _Color = null;
                }
                else
                {
                    _Color = value;
                }
            }
        }//eop

        //constructors
        //constructors are NOT directly call by the outside user
        //constructors are called indirectly when the outside user
        //      creates an instance of the class
        //to create an instance of the class the outside user
        //   will declare --> class variablename = new class();
        //it is the "new" that calls the constructor
        
        //you may or not may have a constructor for your class
        
        //IF you do NOT code a constructor for your class then
        //     a default system constructor is executed
        //This default system constructor initializes your locate
        //    data members to their default C# values.
        
        //If you do code a constructor for your class then
        //     YOU are responsible for all/any constructor in the class

        //"Default" constructor
        //this constructor is similar to the system constructor
        //   this constructor would be called for --> new classname();
        public Die()
        {
            //even though the Sides would be set to a value numeric
            //    within this class a more logical value would be 6
            Sides = 6;
            Color = "White";
            Roll();
        }

        //"Greedy" constructor
        //this constructor usually receives a list of parameter,
        //   one for each data member in the class
        //the constructor takes the parameter values and assigns
        //   the value to the appropriate data member
        //athis constructor would be called for --> new classname(value1, value2,...)
        public Die(int sides, string color)
        {
            Sides = sides; //the set{} of the property Sides is used
            Color = color;
            Roll();
        }

        //Behaviours
        //these are methods
        public void Roll()
        {
            //will be used to generate a new facevalue for the instance
            //an instance of the math class Random() has been coded at the
            //    top of this class
            //the method in the class Random that will be called is
            //   .Next(inclusive lowest number, exlcusive highest number)
            FaceValue = _rnd.Next(1, Sides + 1);
        }

        public void SetSides(int sides)
        {
            //let us assume only 6 to 20 sided dice are allowed
            if (sides > 5 && sides < 21)
            {
                Sides = sides;
                Roll();
            }
            else
            {
                //bad input
                throw new Exception("Invalid number of sides for the dice");
            }
        }
    }
}
