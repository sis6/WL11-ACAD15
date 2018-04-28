					;this file will run once when the program starts.
					;please do not edit. For custom actions on starting the program please create a file on_start.lsp.

(setq PolzAdmin "sis")
(setq PolzOiz "u_oiz")
(setq polzOvl "u_ovl")
(setq lUser (getenv "USERNAME"))

(setq LProgFiles "C:\\Настройки ACad\\Programms_ugesp")

(princ (strcat "\n AppData " LProgFiles))




(setq KatAppPolz (strcat LProgFiles "\\WL11-ACAD15"))
(princ (strcat "\n KatPolz " KatAppPolz))

(setq KatAppDistrib (strcat "//VHOST3/Shares/WL_11-13/Distrib/WL11-ACAD15"))
(princ (strcat "\n Kat Distrib " katAppDistrib))
				
(setq lPutFileDistribMetka (strcat katAppDistrib "/metka.txt"))
(setq lPutFilePolzMetka (strcat KatAppPolz "/metka.txt"))



(defun LeseStrok ( iPut / lPr ret ff )
  (setq lpr (findfile iput))
  ( if ( = lpr nil)
    (Setq ret "pusto")
    (PROGN
       (setq ff (open iput "r"))
	(setq ret (READ-LINE ff))
	(close ff)
	ret
      );progn
    ) ;if
  ) ;lesestrok




       
 

(Setq lIzDistrib (lesestrok lPutFileDistribMetka))
  (princ "\n StrDistrib")
(princ lIzDistrib)

 (Setq lIzPolz (lesestrok lPutFilePolzMetka))
  (princ "\n StrPolz")
(princ lIzPolz) 

(if (= lIzDistrib lIzPolz)
  (princ  "Обновление не нужно" )
  (ALERT "Нужно обновить WL11-ACAD15" )
  ) ;if
 

;;; (princ "\n marcar ")
;;;    (Setq rez (MAPCAR 'SrawTime lfiledistrib lfilePolz))
;;;(princ "\n")
;;;       (princ rez)
       
;;;(if (/= luser nil)
;;;(progn 
;;;(setvar "FILEDIA" 0)
;;;
;;;(cond
;;;  ((wcmatch lUser (Strcat polzOvl "*")) (zagrLsp))
;;;  ((wcmatch lUser (Strcat PolzAdmin "*")) (zagrLsp))
;;;  ((wcmatch lUser (Strcat polzOiz "*")) (zagrLsp))
;;;(T nil)
;;;)					; cond
;;;
;;;(setvar "FILEDIA" 1)
;;;) ;progn
;;;) ; if
