﻿/*
 * Author: Stefan Sander
 * Date: 21.11.2018
 */
using System;

namespace IbanOop
{
	public class MenuIOHandler
	{
		#region properties
		#endregion
		
		#region accessors
		#endregion
		
		#region constructors
			public MenuIOHandler()
			{
			}
		#endregion
		
		#region workers
		public static bool input(MenuInterface menu) {
			MenuChoice[] elements = menu.GetMenuChoiceElements();
			int maxElementsPerPage = menu.GetMaxElementsPerPage();
			int page = menu.GetPage();
			int pos = menu.GetPosition();
			string elementSelectedPrefix = menu.GetElementSelectedPrefix();
			string elementNotSelectedPrefix = menu.GetElementNotSelectedPrefix();
		    ConsoleKeyInfo cki;
		    cki = Console.ReadKey(true);
		    if ((cki.Key.ToString() == "DownArrow") || (cki.Key.ToString() == "RightArrow"))
		    {
		    	pos++;
		        if (pos > elements.Length-1)
		        {
		        	pos=0;
		        }
		    }
		    else if ((cki.Key.ToString() == "UpArrow") || (cki.Key.ToString() == "LeftArrow"))
		    {
		    	pos--;
		        if (pos < 0)
		        {
		        	pos = elements.Length-1;
		        }
		    }
		    else if (cki.Key.ToString() == "Enter")
		    {
	    		menu.SetPosition(pos);
				menu.SetPage(page);
		    	return true;
		    }
		    while (pos+1 >maxElementsPerPage*page) {
		    	page++;
			}
			while (pos+1 < maxElementsPerPage*page-maxElementsPerPage+1) {
		    	page--;
			}
		    
			menu.SetPosition(pos);
			menu.SetPage(page);
	    	return false;
		}
			
		public static void output(MenuInterface menu) {
			MenuChoice[] elements = menu.GetMenuChoiceElements();
			int maxElementsPerPage = menu.GetMaxElementsPerPage();
			int page = menu.GetPage();
			int pos = menu.GetPosition();
			string elementSelectedPrefix = menu.GetElementSelectedPrefix();
			string elementNotSelectedPrefix = menu.GetElementNotSelectedPrefix();
			float floatMaxPages = (float) elements.Length/(float) maxElementsPerPage;
			OutputUtilities.PrintHeader();
		    Console.WriteLine("Nutzen Sie die Pfeiltasten zum Navigieren und Enter zum Auswählen\n");
			for(int i=0;i<elements.Length;i++) {
		    	if (maxElementsPerPage*page>i && i+1>maxElementsPerPage*(page-1))  {
					
					if (i == pos) {
						Console.Write(elementSelectedPrefix);
					} else {
						Console.Write(elementNotSelectedPrefix);
					}
					Console.Write(elements[i]._caption + "\n");
				}
			}
		    if (Math.Ceiling(floatMaxPages)>1) {
		   	 	Console.WriteLine("\nSeite " + page.ToString() + " von " + Math.Ceiling(floatMaxPages));
		    }
		}
		#endregion
		
		#region workers
		#endregion
	}
}
