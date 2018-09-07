using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.IO;

namespace CommandRastDop
{
	public class clsWsp
	{
	public	static string PutPrilojnia()
		{
			string s0 = System.IO.Directory.GetParent(Application.ExecutablePath).FullName;
			//string s1 = AppDomain.CurrentDomain.BaseDirectory.;
			Microsoft.VisualBasic.ApplicationServices.AssemblyInfo lMy = new Microsoft.VisualBasic.ApplicationServices.AssemblyInfo(typeof(clsWsp).Assembly);
			string sp = lMy.DirectoryPath;
			//System.Windows.Forms.Application.StartupPath; ;

			return sp;
		}
	} //clsWsp
public	class Result
	{
	public	double chislo0, chislo1, chislo2;
     public override  string ToString()
		{
			return String.Format("per {0:f2} wt {1:f2} tr {2:f2} \n ", chislo0 , chislo1 , chislo2 );
		}
	} 

} //namespace
