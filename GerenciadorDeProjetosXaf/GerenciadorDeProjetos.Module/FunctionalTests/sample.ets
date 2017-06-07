;#DropDB GerenciadorDeProjetosEasyTest

#Application GerenciadorDeProjetos.Win
#Application GerenciadorDeProjetos.Web
#IfDef GerenciadorDeProjetos.Win

*Action About...
 
*Action OK

#EndIf

#IfDef GerenciadorDeProjetos.Web
!Action Navigation(My Details)
#EndIf
