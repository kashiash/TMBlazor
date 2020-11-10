;#DropDB TMXafEasyTest

#Application TMXafWin
#Application TMXafWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef TMXafWin

*Action About...
 
*Action OK

#EndIf

#IfDef TMXafWeb
*Action Navigation(My Details)
#EndIf
