# simulador_periodo_academico
Projeto de Simulador de Período Acadêmico - Projeto de Avaliação

Como rodar o projeto:

  1 - Na pasta Apresentacao, dentro do projeto existente nesta pasta(Projeto.Apresentacao), configure o arquivo Web.config(<connectionStrings>) que está na raiz do projeto, para o banco de dados(SqlServer) de sua escolha. Informe apenas a connectionString;
  2 - Dentro do Visual Studio, Vá no Console do Gerenciador de Pacotes selecione o projeto "Projeto.Repositorios" e rode o comando: update-database -verbose(caso dê algum erro, restaure os pacotes do nuget - botão direito na solução e escolher a opção "Restaurar Pacotes Nugget");
  3 - Verifique se o banco de dados e as tabelas foram criadas no SqlServer;
  4 - Clique com o botão direito no projeto.Apresentacao e defina como projeto de inicialização;
  5 - Clique com o botão direito no projeto.Apresentacao e vá em propriedades, menu "Web" opção "Página Específica" e coloque Home/Index;
  6 - Rodar a aplicação(caso dê algum problema, vá em Compilação -> Limpar Solução e depois Compilação -> Recompilar Solução);
  7 - Existe o menu Turmas, Matérias e Simulação(cadastrar nessa ordem para o simulador funcionar).
  
  
