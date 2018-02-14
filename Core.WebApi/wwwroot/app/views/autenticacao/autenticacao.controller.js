'use strict';

angular.module('TesteCedro')
    .controller('autenticacaoController', ['$scope', '$state', 'autenticacaoService', function ($scope, $state, autenticacaoService) {
        var vm = this;
        vm.scope = $scope;

        //Obter token
        vm.autentica = function () {

            var dados = {};
            dados.Usuario = vm.entidade.usuario;
            dados.Senha = vm.entidade.senha;

            localStorage.removeItem('tokenCore');

            autenticacaoService.save(dados, function (data) {

                localStorage.setItem('tokenCore', data.Token);
                $state.go('views.Home');
            });
        };
    }]);