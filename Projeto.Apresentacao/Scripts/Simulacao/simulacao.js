var appTurma = angular.module('appSimulacao', []);

appTurma.controller('controllerSimulacao', function ($scope, $http) {

    $scope.mensagem = '';
    $scope.model    = {};

    $scope.simular = function () {

        $scope.mensagem = "Processando, aguarde...";

        $http.post('/Simulacao/Simular', $scope.model)
            .then(function (obj) {         
                
                $scope.mensagem = obj.data;

                $scope.consultar();

            }).catch(function (e) {

                $scope.mensagem = "Erro: " + e.data;
            });
    };

    $scope.consultar = function () {

        $http.get('/Simulacao/ConsultarSimulacao')
            .then(function (obj) {
                $scope.simulacao = obj.data;
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };

    $scope.consultarPorId = function (id) {

        $http.get('/Simulacao/ConsultarDetalhesProvasAluno?id=' + id)
            .then(function (obj) {
                $scope.detalhes = obj.data;
            })
            .catch(function (e) {
                $scope.mensagem = e.data;
            });
    };

});