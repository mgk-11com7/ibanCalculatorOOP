/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:22
 * 
 */
using System;

namespace IbanOop
{
	public interface MenuEntityInterface
	{
		MenuChoiceEntity[] GetMenuChoiceElements();
	}
	
	public delegate void MenuChoiceCallback();
	
	public class MenuController
	{
		#region properties
		private const int _maxElementsPerPage = 10;
		private int _page = 1;
		private int _pos = 0;
		private MenuChoiceEntity[] _elements;
		private string _elementSelected = "[X] ";
		private string _elementNotSelected = "[ ] ";
		#endregion
		
		#region accessors
		public int maxElementsPerPage
        {
            get
            {
                return _maxElementsPerPage;
            }
        }
		public int page
        {
            get
            {
                return this._page;
            }
            set
            {
                _page = value;
            }
        }
		public int pos
        {
            get
            {
                return this._pos;
            }
            set
            {
                _pos = value;
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
		
		public MenuChoiceEntity[] elements
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
		
		public MenuController(MenuEntityInterface MenuEntityInterface)
		{
			this._elements = MenuEntityInterface.GetMenuChoiceElements();
		}
		
		
		public int handle() {
			bool finalSelectionDone=false;
			
			while(finalSelectionDone==false) {
				Console.Clear();
				this.output();
				finalSelectionDone = this.input();
			}
			if (this.elements[this.pos]._callback!=null) {
				this.elements[this.pos]._callback();
			}
			return this.pos;
		}
		
		public bool input() {
		    ConsoleKeyInfo cki;
		    cki = Console.ReadKey(true);
		    if ((cki.Key.ToString() == "DownArrow") || (cki.Key.ToString() == "RightArrow"))
		    {
		        this.pos++;
		        if (this.pos > this.elements.Length-1)
		        {
		            this.pos = 0;
		        }
		    }
		    else if ((cki.Key.ToString() == "UpArrow") || (cki.Key.ToString() == "LeftArrow"))
		    {
		        this.pos--;
		        if (this.pos < 0)
		        {
		            this.pos =  this.elements.Length-1;
		        }
		    }
		    else if (cki.Key.ToString() == "Enter")
		    {
		    	return true;
		    }
			while (pos+1 >this.maxElementsPerPage*page) {
	        	this._page++;
			}
			while (pos+1 < this.maxElementsPerPage*page-this.maxElementsPerPage+1) {
	        	this._page--;
			}
		    return false;
		}
		
		public void output() {
			float floatMaxPages = (float) this.elements.Length/(float) this.maxElementsPerPage;
			Utils.PrintHeader();
			for(int i=0;i<this.elements.Length;i++) {
		    	if (this.maxElementsPerPage*page>i && i+1>this.maxElementsPerPage*(page-1))  {
					
					if (i == this.pos) {
						Console.Write(this.elementSelected);
					} else {
						Console.Write(this.elementNotSelected);
					}
					Console.Write(this.elements[i]._caption + "\n");
				}
			}
		    if (Math.Ceiling(floatMaxPages)>1) {
		   	 	Console.WriteLine("Seite " + page.ToString() + " von " + Math.Ceiling(floatMaxPages));
		    }
		}
	}
}
