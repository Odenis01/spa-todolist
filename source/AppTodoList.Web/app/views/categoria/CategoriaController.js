(function () {
    'use strict';
        
    angular.module('appTodoList').controller('CategoriaController', CategoriaController);

    CategoriaController.$inject = ['$scope', '$http', 'APP_SETTINGS'];

    function CategoriaController($scope, $http, APP_SETTINGS) {
        var vm = this;

        vm.activate = activate;
        vm.categorias = [];
        vm.categoria = {
            id: 0,
            descricao: ""
        };

        function activate() { }

        GetCategorias();

        $scope.SalvarCategoria = function () {            
            var data = vm.categoria;

            if (data.id == 0) {
                $http.post(APP_SETTINGS.SERVICE_URL + 'api/categorias', data)
                .success(function (result) {
                    toastr.success("Categoria cadastrada com sucesso", "Nova Categoria");
                    vm.categorias.push(result);
                    LimparCategoria();
                });
            } else {
                $http.put(APP_SETTINGS.SERVICE_URL + 'api/categorias', data)
                .success(function () {
                    toastr.success("Categoria alterada com sucesso", "Alteração");
                    ResetCategory();
                });
            }
        };

        $scope.SelecionarCategoria = function (id) {
            angular.forEach(vm.categorias, function (cat) {
                if (cat.id == id) {
                    vm.categoria = cat;
                }
            });
        };

        $scope.ApagarCategoria = function () {
            var cid = vm.categoria.id;

            if (cid == 0) {
                toastr.error("Selecione uma categoria", "Erro");
                return false;
            }

            $http.delete(APP_SETTINGS.SERVICE_URL + 'api/categorias?categoriaId=' + cid)
                .success(function () {
                    angular.forEach(vm.categorias, function (cat) {
                        if (cat.id == cid) {
                            var index = vm.categorias.indexOf(cat);
                            vm.categorias.splice(index, 1);
                            toastr.success("Categoria excluída com sucesso!", "Sucesso");
                            LimparCategoria();
                        }
                    });
                });
        };

        $scope.NovaCategoria = function () {
            LimparCategoria();
        }

        function GetCategorias() {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/categorias')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (cat) {
                    vm.categorias.push(cat);
                });
            });
        }

        function LimparCategoria() {
            vm.categoria = {
                id: 0,
                descricao: ""
            };
        }
    }
})();
