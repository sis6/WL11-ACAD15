					;this file will run once when the program starts.
					;please do not edit. For custom actions on starting the program please create a file on_start.lsp.
(setq NameGruppTiz "TIZ_PROFIL")
(setq NameGruppTiz3d "TIZ_PLAN_3D")
(setq NameGruppEw "EW_RASSTAHOWKA")
(setq NameGruppEw3d "EW_RASCHET_PLAN")
(setq NameGruppGiz "GIZ_PROFIL_RASST")

(setq PolzAdmin "sis")
(setq PolzOiz "u_oiz")
(setq polzOvl "u_ovl")
(setq lUser (getenv "USERNAME"))
(princ lUser)
(princ "\n")
(setq LProgFiles (getenv "AppData"))



(setq KatPril (strcat LProgFiles "\\Autodesk\\ApplicationPlugins\\WL11-ACAD15\\ISP"))
(setq KatMenu (strcat LProgFiles "\\Autodesk\\ApplicationPlugins\\WL11-ACAD15"))
(setq NetSborka (strcat katPril "\\CommandUpr.dll"))
(princ katPril)
(princ (strcat "\n Kat menu "  katMenu))

(defun FileMenu	(nameGrupp)
  (princ (strcat "\n fKat menu "  katMenu))
   (princ (strcat "\n fNameGrupp "  nameGrupp))
  (strcat KatMenu "\\" nameGrupp ".cuix")

)					;filemenu
					;POP1_Rasst
;;PL_3DRASCHET
;;
(defun ImjGrupp (nameGrupp)
(Cond
 ((= namegrupp NameGruppTiz) "TIZ_PROFIL.POP1_Prof")   ;+TIZ_PROFIL.POP1_Prof
    ((= namegrupp NameGruppTiz3d)    "TIZ_PLAN_3D.POP1_Plan" )        ;"TIZ_PLAN_3D.POP1_Plan" 
    ((= namegrupp NameGruppEw) "EW_RASSTAHOWKA.POP1_Rasst")   ;+EW_RASSTAHOWKA.POP1_Rasst
    ((= namegrupp NameGruppEw3d) "EW_RASCHET_PLAN.PL_3DRASCHET"       )
) ;cond
) 
(defun PozMenu (NameGrupp)

  (cond
    ((= namegrupp NameGruppTiz) "P16=+TIZ_PROFIL.POP1_Prof")   ;+TIZ_PROFIL.POP1_Prof
    ((= namegrupp NameGruppTiz3d)
     "P16=+TIZ_PLAN_3D.POP1_Plan"                ;TIZ_PROFIL.POP1_Prof
    )
    ((= namegrupp NameGruppEw) "p13=+EW_RASSTAHOWKA.POP1_Rasst")   ;+EW_RASSTAHOWKA.POP1_Rasst
    ((= namegrupp NameGruppEw3d)
     "p16=+EW_RASCHET_PLAN.PL_3DRASCHET"                     ;EW_RASSTAHOWKA.POP1_Rasst
    )
  )					;cond

)					; pozmenu

(defun IsMenu (NameGrupp / lprow)
  (setq lprow (menuGroup NameGrupp))

  (if (= lprow nil)
    (Princ (strcat "\n Net " NameGrupp))
    (Princ (strcat "\n Est " lprow))

  )
)					; isMenu

(defun ZagrMenu	(NameGrupp / lprow lwsp)
  (setq lprow (menuGroup NameGrupp))

  (if (= lprow nil)
    (progn
      (princ (strcat "\n ZagrNameGrupp "  NameGrupp))
      (command "menuload" (FileMenu NameGrupp))
	 (setq  lwsp  (pozmenu NameGrupp))
	  (princ (strcat "\n Pozmenu menucmd   "  lwsp))
     (menucmd lwsp )
	 (princ)
	; (menucmd (strcat (imjGrupp NameGrupp) "=*")) 
	; (menucmd (strcat (imjGrupp NameGrupp) "="))
	; (menucmd (strcat "TIZ_PLAN_3D.POP1_Plan" "=*")) 
    )					; progn
  )					;if
)					; ZagrMenu

(setvar "FILEDIA" 0)

(ismenu NameGruppTiz)
(ismenu NameGruppTiz3d)

(ismenu NameGruppEw)
(ismenu NameGruppEw3d)
(ismenu NameGruppGiz)

(defun ZagrSis ()
  (ZagrMenu NameGruppTiz3d)
  (ZagrMenu NameGruppTiz)


  (ZagrMenu NameGruppEw)
  (ZagrMenu NameGruppEw3d)
)					; zagrsis

(defun ZagrOVL ()

  (ZagrMenu NameGruppEw)
  (ZagrMenu NameGruppEw3d)
)					; zagrOvl

(defun ZagrOiz ()
  (ZagrMenu NameGruppTiz3d)
  (ZagrMenu NameGruppTiz)


  
)					; zagrOiz



(command "netload" NetSborka)
(cond
  ((wcmatch lUser (Strcat polzOvl "*")) (zagrOvl))
  ((wcmatch lUser (Strcat PolzAdmin "*")) (zagrSis))
  ((wcmatch lUser (Strcat polzOiz "*")) (zagrOiz))

)		

(setvar "FILEDIA" 1)
