/*
 * Author: Stefan Sander
 * Date: 22.11.2018
 */
using System;

namespace IbanOop
{
	public class MenuStyleTwo: MenuStyleInterface
	{
		#region properties
		private int _maxElementsPerPage = 10;
		private string _elementSelected = " -> ";
		private string _elementNotSelected = "   ";
		#endregion
		
		#region accessors
		public int GetMaxElementsPerPage() {
			return this._maxElementsPerPage;
		}
		public string GetElementSelectedPrefix() {
			return this._elementSelected;
		}
		public string GetElementNotSelectedPrefix() {
			return this._elementNotSelected;
		}
		#endregion
		
		#region constructors
		#endregion
		
		#region workers
		#endregion
	}
}
