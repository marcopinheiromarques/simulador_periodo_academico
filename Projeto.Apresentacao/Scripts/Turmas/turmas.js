var appTurma = angular.module('appTurma', []);

appTurma.controller('cadastroTurmas', function ($scope, $http) {

    $scope.model = {
        qtd_turmas: 1,
        qtd_alunos_turma: 1
    };

    $scope.mensagem = '';

    $scope.inserir = function () {

        $scope.mensagem = "Processando, aguarde..."; 

        $http.post('/Turma/InserirTurmas', $scope.model)
            .then(function (obj) {

                $scope.mensagem               = obj.data;
                $scope.model.qtd_turmas       = 1;
                $scope.model.qtd_alunos_turma = 1;

                $scope.consultar();

            }).catch(function (e) {

                $scope.mensagem = "Erro: " + e.data;
            });
    };

    $scope.consultar = function () {

        $http.get('/Turma/ConsultarTurmas')
            .then(function (obj) {
                $scope.turmas = obj.data;                
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };


    $scope.consultarPorId = function (id) {

        $http.get('/Turma/ConsultarAlunosDaTurma?id=' + id)
            .then(function (obj) {
                $scope.alunos = obj.data;
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };
});