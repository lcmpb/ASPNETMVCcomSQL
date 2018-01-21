# ASPNETMVCcomSQL
Aula45 - Explicação importante sobre o padrão.
->WEB(Interfaces), não podem acessar diretamente o repositorio,de dados.
Logo este acessa a aplicação, em busca do UsuarioAplicacaoConstrutor que faz a ligação entre:
UsuarioAplicacao<->UsuarioAplicacaoADO, ADO(repositório), passa informação para aplicação,
Esta aplicação->assina uma interface com os metodos em dominio. Possui os metodos completos da aplicação,
caracteristicas como: Id,Nome,Cargo,DataDeCadastro com os requerides.
Logo a WEB tem o retorno das informações pedidas através no ligador "UsuarioAplicacaoConstrutor",
Sendo acessado com o link: "UsuarioAplicacaoConstrutor.UsuarioAplicacaoADO();", pela CONTROLLER.
