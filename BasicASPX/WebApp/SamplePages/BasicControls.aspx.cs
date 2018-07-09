using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        public static List<DDLClass> DataCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this method will execute on EACH and EVERY post back
            //to this page.
            //this method will execute on the first display of this page
            //To determine if the page is new or postback use IsPostBack property

            //this method is often used as a general method to reset
            //fields or controls at the start of the page processing
            //The label MessageLabel is used to display messages to the user
            //Old messages should be remove from this control on each pass

            //How does one reference a control on the .aspx form
            //To reference a form control, use the control ID name
            //EACH control is an object. THEREFORE alter a PROPERTY value.
            MessageLabel.Text = "";

            //Determine if this is the first display of the page
            //  and if so, load data into the dropdownlist
            if (!Page.IsPostBack)
            {
                //Create an instance of List<T> for my "fake database" data
                DataCollection = new List<DDLClass>();

                //add data to the collection, one entry at a time
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(3, "DMIT1508"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(4, "DMIT2018"));

                //usually lists are sorted
                //The List<T> has a .Sort() behaviour (method)
                //(x,y) represents any two entries in the data collection at any point in time
                // the lamda symbol => basically means "do the following"
                //.CompareTo() is a method that will compare to items and return the result
                //   of comparing two items. The result is interpreted by the Sort() to
                //   to determine if the order needs to be changed.
                // x vs y is ascending
                // y vs x is descending
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //place the collection into the dropdownlist
                //a) assign the collection to the control (ID=CollectionList)
                CollectionList.DataSource = DataCollection;

                //b)assign the value and display portions of the dropdownlist
                //     to specify properties of the data class
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);
                CollectionList.DataValueField = nameof(DDLClass.ValueField);

                //c)Bind the data to the collection (physical attachment)
                CollectionList.DataBind();

                //d)You may wish to add a prompt line at the beginning of the
                //     list of data within the dropdownlist
                CollectionList.Items.Insert(0, "select...");
            }
        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            //grab the contents of various controls and manipulate the content
            // of other controls
            //controls have certain properties that can be accessed to obtaining
            // and assigning values

            //Textbox  Property: Text
            string submitchoice = TextBoxNumberChoice.Text;

            if (string.IsNullOrEmpty(submitchoice))
            {
                MessageLabel.Text = "You did not enter a number between 1 and 4.";
            }
            else
            {
                //RadioButtonList Property: SelectedIndex, SelectedValue, SelectedItem
                //SelectedIndex returns the physical line index number
                //SelectedValue returns the data value associated with the physical line **
                //SelectedItem returns the data display associated with the physical line
                RadioButtonListChoice.SelectedValue = submitchoice;

                //CheckBox: Property: Checked (boolean)
                if (submitchoice.Equals("2") || submitchoice.Equals("4"))
                {
                    //show check mark in control
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    //no check mark in control
                    CheckBoxChoice.Checked = false;
                }

                //DropDownList : Property :SelectedValue (preferred)
                //                        :SelectedIndex
                CollectionList.SelectedValue = submitchoice;

                //Label (Literal) Property : Text
                //demostrate using SelectedIndex, SelectedValue and SelectedItem
                // to obtain data off the dropdownlist
                //The data will be concatentated into a single string
                DisplayDataReadOnly.Text = CollectionList.SelectedItem.Text
                      + " at index " + CollectionList.SelectedIndex.ToString()
                      + " having a value of " + CollectionList.SelectedValue;

            }
        }

        protected void LinkButtonSubmitChoice_Click(object sender, EventArgs e)
        {
            //when you have a prompt line in your dropdownlist, you should
            //   test for it and do appropriate code to handle the situation
            if (CollectionList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Please selected a course.";
            }
            else
            {
                //DDL Property: SelectedValue, SelectedIndex, SelectedItem
                string ddlselection = CollectionList.SelectedValue;
                TextBoxNumberChoice.Text = ddlselection;
                RadioButtonListChoice.SelectedValue = ddlselection;
                //CheckBox: Property: Checked (boolean)
                if (ddlselection.Equals("2") || ddlselection.Equals("4"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }
                DisplayDataReadOnly.Text = CollectionList.SelectedItem.Text
                       + " at index " + CollectionList.SelectedIndex.ToString()
                       + " having a value of " + CollectionList.SelectedValue;
            }
            

        }

       
    }
}