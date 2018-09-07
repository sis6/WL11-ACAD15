using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using BazDwg;
using Microsoft.VisualBasic;
using ProfilBaseDwg;
using Rashet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandRastDop
{
	class clsWspDwg
	{
		public static DwgTr DwgTrassa;
		private static void KrivDwgS(Collection Clkriv, double SdwigX = 0, double sdwigY = 0)
		{
			Point3dCollection colPoint3 = new Point3dCollection();
			foreach (double[] oneTchk in Clkriv)
			{
				//Dim wWis As Double = .WisotaNad(oneTchk(0), oneTchk(1))


				//Dim xdwg As Double = .DwgXpoRast(oneTchk(0) + SdwigX)

				//Dim hdwg As Double = .DwgYpoOtm(oneTchk(1) + sdwigY)

				//colPoint3.Add(New Point3d(xdwg, hdwg, 0))

			}
			ObjectIdCollection colprim = new ObjectIdCollection();
			ObjectId objid = BazDwg.MakeEntities.CreateSpline(colPoint3);
			colprim.Add(objid);
			Kommand.changeColor(objid, 6);
			Kommand.changeSloj(objid, DwgParam.SlSlujbn);
			ObjectId objIdG = BazDwg.MakeNeGraf.InsertWGroup(colprim, "GbKrivS", "Крив");
		}
		public static void WiwGabKrivAnkUch(Rashet.wlAnkUch ankUch, double Sigma = -1, double gamma = -1)
		{
			if (Sigma < 0)
				Sigma = ankUch.gpGabRej.Sigma;
			if (gamma < 0)
				gamma = ankUch.gpGabRej.Gamma;
			dwgKrivProvis ProvisGab = new dwgKrivProvis(ankUch.NameAnkPr + "GabKriv", 6, DwgTrassa );
			ProvisGab.NameKr = "габаритная";
			ProvisGab.SdwigY = -ankUch.Gabarit;
			ProvisGab.TchkKriv = ankUch.GetKrivProvisPr(Sigma, gamma);
		}
		public static void WiwGabKrivAnkUchNameColor(wlAnkUch ankUch, string iName, int iColor)
		{
			dwgKrivProvis ProvisGab = new dwgKrivProvis(ankUch.NameAnkPr + "GabKriv", iColor,DwgTrassa );
			ProvisGab.NameKr = iName;
			ProvisGab.SdwigY = -ankUch.Gabarit;
			ProvisGab.TchkKriv = ankUch.GetKrivProvisPr(ankUch.gpGabRej.Sigma, ankUch.gpGabRej.Gamma );
		}
		public static  void WiwKrivProvisTrAnkUch(wlAnkUchTr ankUch)
		{
			dwgKrivProvis Provistrosa = new dwgKrivProvis(ankUch.NameAnkPr + "ProvisTrosa", 4, DwgTrassa);
			Provistrosa.NameKr = ankUch.RejTrMaxNagr.Info;
			Provistrosa.TchkKriv = ankUch.GetKrivProvis();
		}
		public static void WiwKrivProvisAnkUch(wlAnkUch ankUch, double Sigma = -1, double gamma = -1, modRasstOp.Fazi iFaza = modRasstOp.Fazi.faz0)
		{
			if (Sigma < 0)
				Sigma = ankUch.gpGabRej.Sigma;
			if (gamma < 0)
				gamma = ankUch.gpGabRej.Gamma;
			dwgKrivProvis ProvisProv = new dwgKrivProvis(ankUch.NameAnkPr + modRasstOp.wlOpRasst.NameFaz(iFaza), 7 + (long)iFaza, DwgTrassa );
			ProvisProv.NameKr = modRasstOp.wlOpRasst.NameFaz(iFaza);
			ProvisProv.TchkKriv = ankUch.GetKrivProvisPr(Sigma, gamma, iFaza);
		}


		
	}
	public class dwgKrivProvis
	{
		private Collection wTchkKriv;
		private string wNameGroup;
		private long wColor;
		public string NameKr = "+";
		DwgTr wDwgTr;
		double SdwigX { get; set; }
	public	double SdwigY { get; set; }
	public	Collection TchkKriv
		{
			get => wTchkKriv;
			set
			{
				wTchkKriv = value ;
				KrivDwg();
			}
		}
		private double[] RastDoProfil(clsPrf.clsTrass iTrassa)
		{
			double MinP;
			double maxP;
			double tDost = -1;
			MinP = 10000;
			maxP = -10000;
			foreach (double[] oneTchk in wTchkKriv)
			{
				double wWis = iTrassa.WisotaNad(oneTchk[0], oneTchk[1]);
				if (wWis < MinP)
				{
					MinP = wWis;
					tDost = oneTchk[0];
				}
				if (wWis > maxP)
				{
					maxP = wWis;
				}
			}
			double[] mas = {
			tDost,
			MinP
		};
			return mas;
		}
		private double[] RastDoProfil(clsPrf.clsTrass iTrassa, double iOrtosdwig)
		{
			double MinP;
			double maxP;
			double tDost = -1;
			MinP = 10000;
			maxP = -10000;
			foreach (double[] oneTchk in wTchkKriv)
			{
				double wWis = iTrassa.WisotaNad(oneTchk[0], oneTchk[1], iOrtosdwig);
				if (wWis < MinP)
				{
					MinP = wWis;
					tDost = oneTchk[0];
				}
				if (wWis > maxP)
				{
					maxP = wWis;
				}
			}
			double[] mas = {
			tDost,
			MinP
		};
			return mas;
		}
		private void KrivDwg( )
		{
			Point2dCollection colPoint2 = new Point2dCollection();
			foreach (double[] oneTchk in wTchkKriv)
			{
				double xdwg = wDwgTr.DwgXpoRast(oneTchk[0] + SdwigX);

				double hdwg = wDwgTr.DwgYpoOtm(oneTchk[1] + SdwigY);

				colPoint2.Add(new Point2d(xdwg, hdwg));

			}
			BazDwg.MakeNeGraf.DeleteIzGroup(wNameGroup);
			ObjectIdCollection colprim = new ObjectIdCollection();
			ObjectId objid = MakeEntities.CreateLwPolyline(colPoint2);
			colprim.Add(objid);
			int lntchk = (int)colPoint2.Count / 2;
			ObjectId ltext = dwgText.CreateMText(new Point3d(colPoint2[lntchk].X, colPoint2[lntchk].Y, 0), NameKr, 40, 2);
			colprim.Add(ltext);
			BazDwg.Kommand.changeColor(objid, wColor);
			BazDwg.Kommand.changeColor(ltext, wColor);
			BazDwg.Kommand.changeSloj(objid, DwgParam.SlSlujbn);
			BazDwg.Kommand.changeSloj(ltext, DwgParam.SlSlujbn);
			ObjectId objIdG = BazDwg.MakeNeGraf.InsertWGroup(colprim, wNameGroup, "Крив");
		}
	public	dwgKrivProvis(string iName, long iColor , DwgTr iDwgTrass )
		{
			wDwgTr = iDwgTrass;
			wNameGroup = BazDwg.dwgSlowar.DopustImjSlowaraj(iName);
			wColor = iColor;
			SdwigX = 0;
			SdwigY = 0;
		}
	}


	
}
