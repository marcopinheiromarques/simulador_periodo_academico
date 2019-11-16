var appTurma = angular.module('appMateria', []);

appTurma.controller('cadastroMaterias', function ($scope, $http) {

    $scope.model = {
        Nome: '',
        PesoProva1: 1,
        PesoProva2: 1,
        PesoProva3: 1 
    };

    $scope.mensagem = '';

    $scope.inserir = function () {

        $scope.mensagem = "Processando, aguarde...";

        $http.post('/Materia/InserirMateria', $scope.model)
            .then(function (obj) {

                $scope.mensagem         = obj.data;
                $scope.model.Nome       = '';
                $scope.model.PesoProva1 = 1;
                $scope.model.PesoProva2 = 1;
                $scope.model.PesoProva3 = 1;

                $scope.consultar();

            }).catch(function (e) {

                $scope.mensagem = "Erro: " + e.data;
            });
    };

    $scope.consultar = function () {

        $http.get('/Materia/ConsultarMaterias')
            .then(function (obj) {
                $scope.materias = obj.data;
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };    
});