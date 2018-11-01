/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 02:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	public delegate void MenuChoiceCallback();
	
	public class Menu
	{
		#region properties
		private int _selectedItemId=0;
		private MenuChoiceStruct[] _elements;
		private string _elementSelected = "[X] ";
		private string _elementNotSelected = "[ ] ";
		#endregion
		
		#region accessors
		public int selectedItemId
        {
            get
            {
                return this._selectedItemId;
            }
            set
            {
                _selectedItemId = value;
            }
        }
		public string elementNotSelected
        {
            get
            {
                return this._elementNotSelected;
            }
            set
            {
                _elementNotSelected = value;
            }
        }
		
		public string elementSelected
        {
            get
            {
                return this._elementSelected;
            }
            set
            {
                _elementSelected = value;
            }
        }
		
		private MenuChoiceStruct[] elements
        {
            get
            {
                return this._elements;
            }
            set
            {
                _elements = value;
            }
        }
		#endregion
		
		public Menu(MenuChoiceStruct[] elements)
		{
			_elements = elements;
		}
		
		public int handle() {
			bool finalSelectionDone=false;
			
			while(finalSelectionDone==false) {
				Console.Clear();
				this.output();
				finalSelectionDone = this.input();
			}
			if (this.elements[this.selectedItemId]._callback!=null) {
				this.elements[this.selectedItemId]._callback();
			}
			return this.selectedItemId;
		}
		
		public bool input() {
		    ConsoleKeyInfo cki;
		    cki = Console.ReadKey(true);
		    if ((cki.Key.ToString() == "DownArrow") || (cki.Key.ToString() == "RightArrow"))
		    {
		        this.selectedItemId++;
		        if (this.selectedItemId > this.elements.Length-1)
		        {
		            this.selectedItemId = 0;
		        }
		    }
		    else if ((cki.Key.ToString() == "UpArrow") || (cki.Key.ToString() == "LeftArrow"))
		    {
		        this.selectedItemId--;
		        if (this.selectedItemId < 0)
		        {
		            this.selectedItemId =  this.elements.Length-1;
		        }
		    }
		    else if (cki.Key.ToString() == "Enter")
		    {
		    	return true;
		    }
		    return false;
		}
		
		public void output() {
			Utils.PrintHeader();
			for(int i=0;i<this.elements.Length;i++) {
				if (i == this.selectedItemId) {
					Console.Write(this.elementSelected);
				} else {
					Console.Write(this.elementNotSelected);
				}
				Console.Write(this.elements[i]._caption + "\n");
			}
		}
	}
}
