using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Customization;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using BazDwg;
using modRasstOp;
using ProfilBaseDwg;
using Rashet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[assembly: CommandClass(typeof(CommandRastDop.CommandRasst))]
namespace CommandRastDop
{
    public class CommandRasst : IExtensionApplication
	{
		const string NameCui = "\\Rasst_Dop.cuix";
		private Rashet.wlAnkUchTr wAnkUch;
		private modRasstOp.wlRasst wRasst; 
		private void LoadMyCui(string cuiFile)
		{
			Document doc = Application.DocumentManager.MdiActiveDocument;
			string mainCui = Application.GetSystemVariable("MENUNAME") + ".cuix";
			CustomizationSection cs = new CustomizationSection(mainCui);

			PartialCuiFileCollection pcfc = cs.PartialCuiFiles;
			if (pcfc.Contains(cuiFile))
			{
				doc.Editor.WriteMessage("\nCustomization file \"" + cuiFile + "\" already loaded.");
				return;
			}


			object oldCmdEcho = Application.GetSystemVariable("CMDECHO");
			object oldFileDia = Application.GetSystemVariable("FILEDIA");

			Application.SetSystemVariable("CMDECHO", 0);
			Application.SetSystemVariable("FILEDIA", 0);

			doc.SendStringToExecute(
			  "_.cuiload "
			  + "\""
			  + cuiFile
			  + "\""
			  + " ",
			  false, false, false
			);
			doc.SendStringToExecute(
			  "(setvar \"FILEDIA\" "
			  + oldFileDia.ToString()
			  + ")(princ) ",
			  false, false, false
			);
			doc.SendStringToExecute(
			  "(setvar \"CMDECHO\" "
			  + oldCmdEcho.ToString()
			  + ")(princ) ",
			  false, false, false
			);
		}
		private void ReadTrassRasstIzSlowar()
		{
			string lnamelin = "";
			string lnameRab = "";
			int lunom = 0;
			LeseSreib.clsLeseSrejbRasstDwg.IzwlechDannOLini(LeseSreib.ModIsp.KorSlDann, ref lnamelin, ref lnameRab, ref lunom);

			wRasst = new modRasstOp.wlRasst(new ProfilBaseDwg.DwgTr(lnamelin, lnameRab, lunom));
			var dnDwg = new LeseSreib.clsLeseSrejbRasstDwg(LeseSreib.ModIsp.KorSlDann, wRasst);
			if (!dnDwg.Izwlech()) wRasst = null; 
			if (wRasst == null )
			{
				BazDwg.SystemKommand.Soob(" Rasst not loaded");
			}
		}

		// функция инициализации (выполняется при загрузке плагина)
		public void Initialize()
		{

			BazDwg.SystemKommand.Soob("Начало работы CommandRastDop");
			string s = clsWsp.PutPrilojnia() ;
			LoadMyCui(s + NameCui);
		//	ReadTrassRasstIzSlowar(); 

		}

		// функция, выполняемая при выгрузке плагина
		public void Terminate()
		{
			BazDwg.SystemKommand.Soob("Конец работы ВЛ18Т");
		}

		// эта функция будет вызываться при выполнении в AutoCAD команды «TestCommand»
		[CommandMethod("TestCommandRasst")]
		public void TestCommandRasst()
		{
			BazDwg.SystemKommand.Soob ("TestCommandRasst");
		}
		wlOpRasst WibrOp;
		private string SwedObOpore(modRasstOp.wlOpRasst iOp)
		{
			string Soob = "Имя участка трассы " + iOp.rstUch.NameUch + "\n"  +
				"Выбрана опора " + iOp.NumName + " Раст " + iOp.RastOtNachala + " Pik " +  iOp.Piketaj + " Имя Типа " + iOp.UserTipOp  + "\n";

						
			return Soob;
		}
		public void WibrAnkUch1()
		{
			
			if (wRasst == null)
			{
				
				ReadTrassRasstIzSlowar();
			}
			string Soob = "wibrAnkUch1" + "\n";
			
			
			double r = 0.1;
		
			WibrOp = wRasst.wibratOporuDo(r);
			wlOpRasst lAnkOpDo;
			wlOpRasst lAnkOpPosle;
			if (WibrOp == null)
			{
				Soob += "подходящей  опоры не существует" + "\n";
				BazDwg.SystemKommand.Soob(Soob);
			}
			else
			{
				Soob += SwedObOpore(WibrOp);
				lAnkOpDo = wRasst.PredAnk(WibrOp);
				if (lAnkOpDo == null)
				{
					Soob += "подходящей анкерной опоры  до точки выбора не существует\n";
				}
				else
				{
					Soob += "начало анкер. участка\n" + SwedObOpore(lAnkOpDo);
				}
				lAnkOpPosle = wRasst.SledAnk(WibrOp);
				if (lAnkOpPosle == null)
				{
					Soob += "подходящей анкерной опоры  после точки выбора не существует\n";
				}
				else
				{
					Soob += "конец  анкер. участка\n" + SwedObOpore(lAnkOpPosle);
				}
				if (lAnkOpDo == null | lAnkOpPosle == null)
				{
					Application.ShowAlertDialog("Анкерный участок не создан\n" + Soob);
				}
				else
				{
					wAnkUch = new wlAnkUchTr(lAnkOpDo, lAnkOpPosle);
					if (wAnkUch.Nagr == null)
					{
						Application.ShowAlertDialog(this.ToString() + " wibrAnkUchProfil " + " не хватает даанных для расчетов на " + wAnkUch.NameAnkPr);
						return;
					}
					ProfilBaseDwg.dwgObrazOporRasst opDwg;
					if (lAnkOpDo.EtaOporaW_PredUchastke == null)
					{
						if (lAnkOpDo.Obraz == null)
						{
							opDwg = new dwgObrazOporRasst(lAnkOpDo);
						}
						else
						{
							opDwg = (dwgObrazOporRasst)lAnkOpDo.Obraz;
						}
					}
					else
					{
						if (lAnkOpDo.EtaOporaW_PredUchastke.Obraz == null)
						{
							opDwg = new dwgObrazOporRasst(lAnkOpDo.EtaOporaW_PredUchastke);
						}
						else
						{
							opDwg = (dwgObrazOporRasst)lAnkOpDo.EtaOporaW_PredUchastke.Obraz;
						}
					}
					rstUslRascheta objRusl = new rstUslRascheta(wAnkUch);
					objRusl.StrPred = opDwg.StrDan;
					wAnkUch.PrivedZentrTaj = objRusl.PrivedZentrTajesti;
					wAnkUch.PrivedZentrTajT = objRusl.PrivedZentrTajestiTr;
					//	DobawitMenuUch();
					BazDwg.Kommand.createNewLayer(DwgParam.SlSlujbn);
					clsWspDwg.DwgTrassa = (DwgTr)wRasst.Trassa;
					clsWspDwg.WiwGabKrivAnkUch(wAnkUch);
					clsWspDwg.WiwKrivProvisAnkUch(wAnkUch);
				}
			}
		}//WibrAnkUch
		[CommandMethod("WibrAnkUch")]
		public void WibrAnkUch()
		{
			Point3dCollection Twibr;
			if (wRasst == null)
			{
				
				ReadTrassRasstIzSlowar();
			}
			string Soob = "wibrAnkUchProfil" + "\n";
			Twibr = Kommand.GetPointOtPolz();
			Point3d t = Twibr[0];
			Soob += "   на черт " + t.X;
			double r =((ProfilBaseDwg.DwgTr) wRasst.Trassa).RastPoDwgX(t.X);
			Soob += " на трасе " + t.X + "\n";
			WibrOp = wRasst.wibratOporuDo(r);
			wlOpRasst lAnkOpDo;
			wlOpRasst lAnkOpPosle;
			if (WibrOp == null)
			{
				Soob += "подходящей  опоры не существует"+ "\n";
				BazDwg.SystemKommand.Soob(Soob);
			}
			else
			{
				Soob += SwedObOpore(WibrOp);
				lAnkOpDo = wRasst.PredAnk(WibrOp);
				if (lAnkOpDo == null)
				{
					Soob += "подходящей анкерной опоры  до точки выбора не существует\n" ;
				}
				else
				{
					Soob += "начало анкер. участка\n"  + SwedObOpore(lAnkOpDo);
				}
				lAnkOpPosle = wRasst.SledAnk(WibrOp);
				if (lAnkOpPosle == null)
				{
					Soob += "подходящей анкерной опоры  после точки выбора не существует\n" ;
				}
				else
				{
					Soob += "конец  анкер. участка\n" +  SwedObOpore(lAnkOpPosle);
				}
				if (lAnkOpDo == null | lAnkOpPosle == null)
				{
					Application.ShowAlertDialog("Анкерный участок не создан\n" +  Soob);
				}
				else
				{
					wAnkUch = new wlAnkUchTr(lAnkOpDo, lAnkOpPosle);
					if (wAnkUch.Nagr == null)
					{
						Application.ShowAlertDialog(this.ToString() + " wibrAnkUchProfil " + " не хватает даанных для расчетов на " + wAnkUch.NameAnkPr);
						return;
					}
					ProfilBaseDwg.dwgObrazOporRasst opDwg;
					if (lAnkOpDo.EtaOporaW_PredUchastke == null)
					{
						if (lAnkOpDo.Obraz == null)
						{
							opDwg = new dwgObrazOporRasst(lAnkOpDo);
						}
						else
						{
							opDwg = (dwgObrazOporRasst)lAnkOpDo.Obraz;
						}
					}
					else
					{
						if (lAnkOpDo.EtaOporaW_PredUchastke.Obraz == null)
						{
							opDwg = new dwgObrazOporRasst(lAnkOpDo.EtaOporaW_PredUchastke);
						}
						else
						{
							opDwg = (dwgObrazOporRasst)lAnkOpDo.EtaOporaW_PredUchastke.Obraz;
						}
					}
					rstUslRascheta objRusl = new rstUslRascheta(wAnkUch);
					objRusl.StrPred = opDwg.StrDan;
					wAnkUch.PrivedZentrTaj = objRusl.PrivedZentrTajesti;
					wAnkUch.PrivedZentrTajT = objRusl.PrivedZentrTajestiTr;
				//	DobawitMenuUch();
					BazDwg.Kommand.createNewLayer(DwgParam.SlSlujbn);
					BazDwg.Kommand.OchistSlojMod(DwgParam.SlSlujbn); 
					clsWspDwg.DwgTrassa = (DwgTr)wRasst.Trassa; 
					clsWspDwg.WiwGabKrivAnkUch(wAnkUch);
					clsWspDwg.WiwKrivProvisAnkUch(wAnkUch);
				}
			}
		}//WibrAnkUch
		[CommandMethod("RaschetNRej")]
		public void RaschetNRej()
		{
			if (wAnkUch == null)
			{
				Application.ShowAlertDialog("RaschetNRej:не выбран анкерный участок\n Выбираем первый");
				WibrAnkUch1(); 		
			}
			else
			{
				SystemKommand.SoobEditor("Raschet: выбран анкерный участок " + wAnkUch.NameAnkPr);
			}
			Rashet.rstUslRascheta objUsl = new Rashet.rstUslRascheta(wAnkUch);
			
		
			string StrRez = "Расчеты  по " + wAnkUch.NameAnkPr + "\n"  ;
			double lGabProlet = wAnkUch.GabProlet.DlinaProleta;
			List<Result> lSpRez = new List<Result>() ;
			int step = ((int)(lGabProlet / 100)) * 10; 
			for(int ls = step; ls < lGabProlet; ls += step )
			{
				Rejm lish = new Rejm("исх", wAnkUch.Nagr.G1, -5, 200);
                 tshprolet lProlet = wlAnkUchBase.RaschetPoPrivedenomuProletu(wAnkUch.gpIshRej, wAnkUch.gpGabRej , wAnkUch.Nagr.Provod, ls);
				Result lw = new Result() ;
				lw.chislo0 = lProlet.Sigma0;
				lw.chislo1 = lProlet.StrelaMax;
				lw.chislo2 = ls;
				lSpRez.Add(lw);
				StrRez += lw.ToString(); 

			}

			Application.ShowAlertDialog(StrRez);  
		}


		
	}  //class
} //namespace
