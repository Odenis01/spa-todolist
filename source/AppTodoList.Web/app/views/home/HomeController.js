(function () {
    'use strict';

    angular.module('appTodoList').controller('HomeController', HomeController);

    HomeController.$inject = ['$scope', '$http', 'action', 'APP_SETTINGS'];

    function HomeController($scope, $http, action, APP_SETTINGS) {
        var vm = this;

        vm.activate = activate;
        vm.titulo = 'Controle de tarefas';
        vm.tarefas = [];

        function activate() { }

        if (action === 'list') {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/tarefas')
            .success(function (data, status, headers, config) {                
                angular.forEach(data, function (tarefa) {
                    vm.tarefas.push(tarefa);
                });
            });
        }

        if (action === 'afazer') {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/tarefas/afazer')
            .success(function (data, status, headers, config) {
                angular.forEach(data, function (tarefa) {
                    vm.tarefas.push(tarefa);
                });
            });
        }

        if (action === 'feitos') {
            $http.get(APP_SETTINGS.SERVICE_URL + 'api/tarefas/feitos')
           .success(function (data, status, headers, config) {
               angular.forEach(data, function (tarefa) {
                   vm.tarefas.push(tarefa);
               });
           });
        }       
    }
})();
