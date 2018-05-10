﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsDriver
{
    //classes by default have an access privilege of private
    //you must add public to your classes

    class Die
    {
        //create a new instance of the math object Random
        //this will be shared by each instance of Die
        //the instance of Random object will be created when
        //the first instance of Die is created (static allows everything to use it)
        private static Random _rnd = new Random();

        //classes have
        // A) data members
        // B) properties
        // C) constructors
        // D) behaviors (methods)

        //data members may be private for the class for use only 
        //  within the class

        //the interface with a class is done via properties, and behaviors

        //properties can be fully implemented
        // - a private data member
        // - a public property
        private int _Sides;
        public int Sides
        {
            get
            {
                //this will return the private data member
                return _Sides;
            }
            set
            {
                //the reserved keyword "value" is used to 
                //  obtain the incoming data value to the property
                //save the incoming data value to your private 
                //  data member
                _Sides = value;

            }
        }

        //can be auto implemented
        //  does not have a private data member 
        // the system creates an internal data storage member 
        //  for the property
        public int FaceValue { get; set; }

    }
}
