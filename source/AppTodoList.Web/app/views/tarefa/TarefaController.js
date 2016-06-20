(function () {
    'use strict';
    var urlService = 'http://localhost:50075/api';

    angular.module('appTodoList').controller('TarefaController', TarefaController);

    TarefaController.$inject = ['$scope', '$routeParams', '$http', '$rootScope', '$location', 'action', 'APP_SETTINGS'];
    
    function TarefaController($scope, $routeParams, $http, $rootScope, $location, action, APP_SETTINGS) {
        var vm = this;

        vm.activate = activate;
        vm.tarefas = [];
        vm.categorias = [];
        vm.usuarios = [];

        vm.tarefa = {
            id: 0,
            titulo: "",
            descricao: "",
            finalizada: false,
            dataCriacao: "",
            categoriaId: "",
            usuarioId: "",
            prioridade: 10,
            categoria: {},
            usuario: {}
        };

        if (action === 'list') {
            GetTarefas();
            GetCategorias();
            GetUsuarios();
        }          

        if (action === 'details') {
            GetTarefa($routeParams.id);
        }

        function activate() { }

        function GetTarefa(id) {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/tarefas/' + id)
            .success(function (data, status, headers, config) {
                vm.tarefa = data;
            });
        }

        function GetTarefas() {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/tarefas')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (tarefa) {
                    vm.tarefas.push(tarefa);
                });
            });
        }
       
        function GetCategorias() {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/categorias')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (cat) {
                    vm.categorias.push(cat);
                });
            });
        }

        function GetUsuarios() {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/usuarios')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (us) {
                    vm.usuarios.push(us);
                });
            });
        }

        function LimparTarefa() {
            vm.tarefa = {
                id: 0,
                titulo: "",
                descricao: "",
                finalizada: false,
                cataCriacao: "",
                categoriaId: "",
                usuarioId: "",
                prioridade: 10,
                categoria: {},
                usuario: {}
            };
        }

        $scope.SelecionarTarefa = function (id) {
            angular.forEach(vm.tarefas, function (tarefa) {
                if (tarefa.id == id) {
                    vm.tarefa = tarefa;
                    console.log(tarefa);
                }
            });
        };

        $scope.SalvarTarefa = function () {
            var data = vm.tarefa;

            if (data.id == 0) {
                $http.post(APP_SETTINGS.SERVICE_URL + 'api/tarefas', data)
                .success(function (result) {
                    toastr.success("Tarefa cadastrado com sucesso", "Nova tarefa");
                    vm.tarefas.push(result);
                    LimparTarefa();
                });
            } else {
                $http.put(APP_SETTINGS.SERVICE_URL + 'api/tarefas', data)
                .success(function () {
                    toastr.success("Tarefa alterada com sucesso", "Alteração");
                    LimparTarefa();
                });
            }
        };


        $scope.FinalizarTarefa = function(){
            var data = vm.tarefa;

            if (data.id > 0) {                
                data.finalizada = true;
                $http.put(APP_SETTINGS.SERVICE_URL + 'api/tarefas', data)
                .success(function (result) {
                    toastr.success("Tarefa finalizada com sucesso!", "Sucesso");
                    $scope.go('/');
                });
            }
        };

        $scope.ApagarTarefa = function () {
            var cid = vm.tarefa.id;

            if (cid == 0) {
                toastr.error("Selecione uma Tarefa", "Erro");
                return false;
            }

            $http.delete(APP_SETTINGS.SERVICE_URL + 'api/tarefas?tarefaId=' + cid)
                .success(function () {
                    angular.forEach(vm.tarefas, function (trf) {
                        if (trf.id == cid) {
                            var index = vm.tarefas.indexOf(trf);
                            vm.tarefas.splice(index, 1);
                            toastr.success("Tarefa excluída com sucesso!", "Sucesso");
                            LimparTarefa();
                        }
                    });
                });
        };

        $scope.NovaTarefa = function () {
            LimparTarefa();
        }

        $scope.go = function (path) {
            $location.path(path);
        };
    }
})();
