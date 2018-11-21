/*
 * Author: Stefan Sander
 * Date: 01.11.2018
 * Time: 02:22
 * 
 */
using System;

namespace IbanOop
{
	public interface MenuInterface
	{
		MenuChoiceEntity[] GetMenuChoiceElements();
		string GetElementSelectedPrefix();
		string GetElementNotSelectedPrefix();
		int GetMaxElementsPerPage();
		int GetPage();
		void SetPage(int page);
		int GetPosition();
		void SetPosition(int pos);
	}
	
	public delegate void MenuChoiceCallback();
	
	public class MenuController
	{
		#region properties
		private MenuInterface _Menu;
		#endregion
		
		#region accessors
		#endregion
		
		public MenuController(MenuInterface MenuInterface)
		{
			this._Menu = MenuInterface;
		}
		
		
		public int handle() {
			bool finalSelectionDone=false;
			
			while(finalSelectionDone==false) {
				Console.Clear();
				this.output();
				finalSelectionDone = this.input();
			}
			if (this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback!=null) {
				this._Menu.GetMenuChoiceElements()[this._Menu.GetPosition()]._callback();
			}
			return this._Menu.GetPosition();
		}
		
		public bool input() {
		    ConsoleKeyInfo cki;
		    cki = Console.ReadKey(true);
		    if ((cki.Key.ToString() == "DownArrow") || (cki.Key.ToString() == "RightArrow"))
		    {
		    	this._Menu.SetPosition(this._Menu.GetPosition()+1);
		        if (this._Menu.GetPosition() > this._Menu.GetMenuChoiceElements().Length-1)
		        {
		        	this._Menu.SetPosition(0);
		        }
		    }
		    else if ((cki.Key.ToString() == "UpArrow") || (cki.Key.ToString() == "LeftArrow"))
		    {
		    	this._Menu.SetPosition(this._Menu.GetPosition()-1);
		        if (this._Menu.GetPosition() < 0)
		        {
		        	this._Menu.SetPosition(this._Menu.GetMenuChoiceElements().Length-1);
		        }
		    }
		    else if (cki.Key.ToString() == "Enter")
		    {
		    	return true;
		    }
		    while (this._Menu.GetPosition()+1 >this._Menu.GetMaxElementsPerPage()*this._Menu.GetPage()) {
		    	this._Menu.SetPage(this._Menu.GetPage()+1);
			}
			while (this._Menu.GetPosition()+1 < this._Menu.GetMaxElementsPerPage()*this._Menu.GetPage()-this._Menu.GetMaxElementsPerPage()+1) {
		    	this._Menu.SetPage(this._Menu.GetPage()-1);
			}
		    return false;
		}
		
		public void output() {
			float floatMaxPages = (float) this._Menu.GetMenuChoiceElements().Length/(float) this._Menu.GetMaxElementsPerPage();
			Utils.PrintHeader();
			for(int i=0;i<this._Menu.GetMenuChoiceElements().Length;i++) {
		    	if (this._Menu.GetMaxElementsPerPage()*this._Menu.GetPage()>i && i+1>this._Menu.GetMaxElementsPerPage()*(this._Menu.GetPage()-1))  {
					
					if (i == this._Menu.GetPosition()) {
						Console.Write(this._Menu.GetElementSelectedPrefix());
					} else {
						Console.Write(this._Menu.GetElementNotSelectedPrefix());
					}
					Console.Write(this._Menu.GetMenuChoiceElements()[i]._caption + "\n");
				}
			}
		    if (Math.Ceiling(floatMaxPages)>1) {
		   	 	Console.WriteLine("Seite " + this._Menu.GetPage().ToString() + " von " + Math.Ceiling(floatMaxPages));
		    }
		}
	}
}
