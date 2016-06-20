(function () {
    'use strict';
    
    angular.module('appTodoList').controller('UsuarioController', UsuarioController);

    UsuarioController.$inject = ['$scope', '$http', 'APP_SETTINGS'];

    function UsuarioController($scope, $http, APP_SETTINGS) {
        var vm = this;

        vm.activate = activate;
        vm.usuarios = [];
        vm.usuario = {
            id: 0,
            nome: "",
            email: ""
        };

        function activate() { }
        GetUsuarios();

        $scope.SalvarUsuario = function () {
            var data = vm.usuario;

            if (data.id == 0) {
                alert('sss' + APP_SETTINGS.SERVICE_URL);
                $http.post(APP_SETTINGS.SERVICE_URL + 'api/usuarios', data)
                .success(function (result) {
                    toastr.success("Usuário cadastrada com sucesso", "Novo Usuário");
                    vm.usuarios.push(result);
                    LimparUsuario();
                });
            } else {
                alert('ccc' + APP_SETTINGS.SERVICE_URL);
                $http.put(APP_SETTINGS.SERVICE_URL + 'api/usuarios', data)
                .success(function () {
                    toastr.success("Usuário alterada com sucesso", "Alteração");
                    LimparUsuario();
                });
            }
        };

        $scope.SelecionarUsuario = function (id) {
            angular.forEach(vm.usuarios, function (us) {
                if (us.id == id) {
                    vm.usuario = us;
                }
            });
        };

        $scope.ApagarUsuario = function () {
            var cid = vm.usuario.id;

            if (cid == 0) {
                toastr.error("Selecione uma usuário", "Erro");
                return false;
            }

            $http.delete(APP_SETTINGS.SERVICE_URL + 'api/usuario?usuarioId=' + cid)
                .success(function () {
                    angular.forEach(vm.usuarios, function (us) {
                        if (us.id == cid) {
                            var index = vm.usuarios.indexOf(us);
                            vm.usuarios.splice(index, 1);
                            toastr.success("Usuário excluído com sucesso!", "Sucesso");
                            LimparUsuario();
                        }
                    });
                });
        };

        $scope.NovoUsuario = function () {
            LimparUsuario();
        }

        function GetUsuarios() {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/usuarios')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (us) {
                    vm.usuarios.push(us);
                });
            });
        }

        function LimparUsuario() {
            vm.usuario = {
                id: 0,
                nome: "",
                email:""
            };
        }
    }
})();
