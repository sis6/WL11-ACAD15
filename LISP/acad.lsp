;;;     Copyright (C) 2003 by UgEnergoSet
;;;
;;;
;;;
;;;
;;;  функци автоматически загружаемые при загрузке меню  
; запуск программ опора геология и т. д

;(princ  "\n on_start")


(setq PolzAdmin "sis")
(setq PolzOiz "u_oiz")
(setq polzOvl "u_ovl")
(setq lUser (getenv "USERNAME"))


(setq AppLspZagr "\\UserA.lsp")
(setq AppLspProv "\\ProwObnowA.lsp")


(setq LProgFiles (getenv "AppData"))
(princ (strcat "\n AppData " LProgFiles))
;(alert "pfuh")
(setq KatAppPolz (strcat LProgFiles "\\Autodesk\\ApplicationPlugins\\WL11-ACAD15"))
(princ (strcat "\n KatPolz " KatAppPolz))
;(alert "pfuh")
 (setq PutLspZagr  (Strcat katAppPolz ApplspZagr  ))

 (setq PutLspProv (Strcat katAppPolz ApplspProv ))

;(alert "pfuh")
(defun LoadFun ()
(load PutLspProv)
(load  PutLspZagr) 
) ; loadfun 


(cond
  ((wcmatch lUser (Strcat polzOvl "*")) (loadfun  ))
  ((wcmatch lUser (Strcat PolzAdmin "*")) (loadfun))
  ((wcmatch lUser (Strcat polzOiz "*")) (loadfun))
(T nil)
)					; cond



;(alert "pfuh")






