﻿/*
 * Created by SharpDevelop.
 * User: derStoffel
 * Date: 01.11.2018
 * Time: 02:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace IbanOop
{
	class Program
	{
		#region constructors
		public static void Main(string[] args)
		{
			IbanController ibanCtrl = new IbanController();
			ibanCtrl.Menu();
		}
		#endregion
	}
}